using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Turbo.Core.Database.Dtos;
using Turbo.Core.Game;
using Turbo.Core.Game.Rooms;
using Turbo.Core.Game.Rooms.Mapping;
using Turbo.Core.Game.Rooms.Object;
using Turbo.Core.Utilities;
using Turbo.Database.Entities.Room;
using Turbo.Database.Repositories.Player;
using Turbo.Database.Repositories.Room;
using Turbo.Rooms.Factories;
using Turbo.Rooms.Mapping;
using static System.Formats.Asn1.AsnWriter;

namespace Turbo.Rooms
{
    public class RoomManager : Component, IRoomManager
    {
        private static readonly SemaphoreSlim _roomLock = new(1, 1);

        private readonly ILogger<IRoomManager> _logger;
        private readonly IRoomRepository _roomRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRoomModelRepository _roomModelRepository;
        private readonly IRoomFactory _roomFactory;

        private readonly ConcurrentDictionary<int, IRoom> _rooms = new();
        private readonly IDictionary<int, IRoomModel> _models = new Dictionary<int, IRoomModel>();

        private int _remainingTryDisposeTicks = DefaultSettings.RoomTryDisposeTicks;

        public RoomManager(
            ILogger<IRoomManager> logger,
            IRoomRepository roomRepository,
            IPlayerRepository playerRepository,
            IRoomModelRepository roomModelRepository,
            IRoomFactory roomFactory)
        {
            _logger = logger;
            _roomRepository = roomRepository;
            _playerRepository = playerRepository;
            _roomModelRepository = roomModelRepository;
            _roomFactory = roomFactory;
        }

        protected override async Task OnInit()
        {
            await LoadModels();
        }

        protected override async Task OnDispose()
        {
            await RemoveAllRooms();
        }

        public async Task<IRoom> GetRoom(int id)
        {
            return await GetOfflineRoom(id);
        }

        public IRoom GetOnlineRoom(int id)
        {
            if (_rooms.TryGetValue(id, out var room))
            {
                room.CancelDispose();

                return room;
            }

            return null;
        }

        public async Task<IRoom> GetOfflineRoom(int id)
        {
            await _roomLock.WaitAsync();

            try
            {
                var room = GetOnlineRoom(id);

                if (room != null) return room;

                var roomEntity = await _roomRepository.FindAsync(id);

                if (roomEntity == null) return null;

                room = _roomFactory.Create(roomEntity);

                room.RoomDetails.PlayerName = (await _playerRepository.FindUsernameAsync(roomEntity.PlayerEntityId))?.Name ?? ""; ;

                return await AddRoom(room);
            }

            finally
            {
                _roomLock.Release();
            }
        }

        public async Task<IRoom> AddRoom(IRoom room)
        {
            if (room == null) return null;

            var existing = GetOnlineRoom(room.Id);

            if (existing != null)
            {
                if (room != existing) await room.DisposeAsync();

                return existing;
            }

            if (_rooms.TryAdd(room.Id, room)) return room;

            await room.DisposeAsync();

            return null;
        }

        public async Task RemoveRoom(int id)
        {
            var room = GetOnlineRoom(id);

            if (room == null) return;

            if (_rooms.TryRemove(new KeyValuePair<int, IRoom>(room.Id, room)))
            {
                await room.DisposeAsync();
            }
        }

        public async Task RemoveAllRooms()
        {
            if (_rooms.Count == 0) return;

            foreach (int id in _rooms.Keys)
            {
                await RemoveRoom(id);
            }
        }

        public void TryDisposeAllRooms()
        {
            foreach (var room in _rooms.Values)
            {
                room.TryDispose();
            }
        }

        public async Task<IRoomModel> GetModel(int id)
        {
            if (_models.TryGetValue(id, out IRoomModel model))
            {
                return model;
            }

            return null;
        }

        public IRoomModel GetModelByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || _models.Count == 0) return null;

            foreach (IRoomModel roomModel in _models.Values)
            {
                if (roomModel == null || !roomModel.Name.Equals(name)) continue;

                return roomModel;
            }

            return null;
        }

        private async Task LoadModels()
        {
            _models.Clear();

            var entities = await _roomModelRepository.FindAllAsync();

            entities.ForEach(x =>
            {
                IRoomModel roomModel = new RoomModel(x);

                _models.Add(roomModel.Id, roomModel);
            });

            _logger.LogInformation("Loaded {0} room models", _models.Count);
        }

        public Task Cycle()
        {
            if (_remainingTryDisposeTicks == 0)
            {
                TryDisposeAllRooms();

                _remainingTryDisposeTicks = DefaultSettings.RoomTryDisposeTicks;
            }

            if (_remainingTryDisposeTicks > -1) _remainingTryDisposeTicks--;

            return Task.WhenAll(_rooms.Values.Select(room => Task.Run(async () => await room.Cycle())));
        }
    }
}
