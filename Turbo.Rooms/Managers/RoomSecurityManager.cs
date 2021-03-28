﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Turbo.Core.Game.Players;
using Turbo.Core.Game.Rooms;
using Turbo.Core.Game.Rooms.Constants;
using Turbo.Core.Game.Rooms.Managers;
using Turbo.Core.Game.Rooms.Object;
using Turbo.Core.Game.Rooms.Object.Constants;
using Turbo.Core.Game.Rooms.Object.Logic;
using Turbo.Core.Packets.Messages;
using Turbo.Packets.Outgoing.Room.Engine;

namespace Turbo.Rooms.Managers
{
    public class RoomSecurityManager : IRoomSecurityManager
    {
        private IRoom _room;

        private IDictionary<int, string> _rights;

        public RoomSecurityManager(IRoom room)
        {
            _room = room;

            _rights = new Dictionary<int, string>();
        }

        public async ValueTask InitAsync()
        {

        }

        public async ValueTask DisposeAsync()
        {

        }

        public bool IsOwner(IPlayer player)
        {
            if (IsStrictOwner(player)) return true;

            if (player.HasPermission("any_room_owner")) return true;

            return false;
        }

        public bool IsStrictOwner(IPlayer player)
        {
            if (_room.RoomDetails.PlayerId == player.Id) return true;

            return false;
        }

        public bool HasRights(IPlayer player)
        {
            if (IsOwner(player)) return true;

            if (player.HasPermission("any_room_rights")) return true;

            if (_rights.ContainsKey(player.Id)) return true;

            return false;
        }

        public void RefreshRights(IRoomObject roomObject)
        {
            bool isOwner = false;
            RoomRightsType rightsType = RoomRightsType.None;

            if(roomObject.RoomObjectHolder is IPlayer player)
            {
                if(IsOwner(player))
                {
                    isOwner = true;
                    rightsType = RoomRightsType.Moderator;
                }

                else if(HasRights(player))
                {
                    rightsType = RoomRightsType.Rights;
                }

                // composer 780 roomrights

                player.Session.Send(new RoomEntryInfoMessage
                {
                    RoomId = _room.Id,
                    Owner = isOwner
                });

                // composer 339 room owner
            }

            if(roomObject.Logic is IMovingAvatarLogic avatarLogic)
            {
                avatarLogic.AddStatus(RoomObjectAvatarStatus.FlatControl, rightsType.ToString());
            }
        }

        public void SendOwnersComposer(IComposer composer)
        {
            foreach(IRoomObject roomObject in _room.RoomUserManager.RoomObjects.Values)
            {
                if(roomObject.RoomObjectHolder is IPlayer player)
                {
                    if (!IsOwner(player)) continue;

                    player.Session.Send(composer);
                }
            }
        }

        public void SendRightsComposer(IComposer composer)
        {
            foreach (IRoomObject roomObject in _room.RoomUserManager.RoomObjects.Values)
            {
                if (roomObject.RoomObjectHolder is IPlayer player)
                {
                    if (!HasRights(player)) continue;

                    player.Session.Send(composer);
                }
            }
        }
    }
}
