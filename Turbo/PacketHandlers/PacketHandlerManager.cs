﻿using Turbo.Core.PacketHandlers;

namespace Turbo.Main.PacketHandlers
{
    public class PacketHandlerManager : IPacketHandlerManager
    {
        private readonly IAuthenticationMessageHandler _authenticationMessageHandler;
        private readonly ICatalogMessageHandler _catalogMessageHandler;
        private readonly IInventoryMessageHandler _inventoryMessageHandler;
        private readonly INavigatorMessageHandler _navigatorMessageHandler;
        private readonly IRoomActionMessageHandler _roomActionMessageHandler;
        private readonly IRoomAvatarMessageHandler _roomAvatarMessageHandler;
        private readonly IRoomEngineMessageHandler _roomEngineMessageHandler;
        private readonly IRoomFurnitureMessageHandler _roomFurnitureMessageHandler;
        private readonly IRoomSessionMessageHandler _roomSessionMessageHandler;
        private readonly IRoomSettingsMessageHandler _roomSettingsMessageHandler;
        private readonly IUserMessageHandler _userMessageHandler;

        public PacketHandlerManager(
            IAuthenticationMessageHandler authenticationMessageHandler,
            ICatalogMessageHandler catalogMessageHandler,
            IInventoryMessageHandler inventoryMessageHandler,
            INavigatorMessageHandler navigatorMessageHandler,
            IRoomActionMessageHandler roomActionMessageHandler,
            IRoomAvatarMessageHandler roomAvatarMessageHandler,
            IRoomEngineMessageHandler roomEngineMessageHandler,
            IRoomFurnitureMessageHandler roomFurnitureMessageHandler,
            IRoomSessionMessageHandler roomSessionMessageHandler,
            IRoomSettingsMessageHandler roomSettingsMessageHandler,
            IUserMessageHandler userMessageHandler)
        {
            _authenticationMessageHandler = authenticationMessageHandler;
            _catalogMessageHandler = catalogMessageHandler;
            _inventoryMessageHandler = inventoryMessageHandler;
            _navigatorMessageHandler = navigatorMessageHandler;
            _roomActionMessageHandler = roomActionMessageHandler;
            _roomAvatarMessageHandler = roomAvatarMessageHandler;
            _roomEngineMessageHandler = roomEngineMessageHandler;
            _roomFurnitureMessageHandler = roomFurnitureMessageHandler;
            _roomSessionMessageHandler = roomSessionMessageHandler;
            _roomSettingsMessageHandler = roomSettingsMessageHandler;
            _userMessageHandler = userMessageHandler;
        }
    }
}
