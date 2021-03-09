﻿using Turbo.Core.Navigator.Constants;

namespace Turbo.Packets.Incoming.Navigator
{
    public record CreateFlatMessage : IMessageEvent
    {
        public string FlatName { get; init; }
        public string FlatDescription { get; init; }
        public string FlatModelName { get; init; }

        public int CategoryID { get; init; }
        public int MaxPlayers { get; init; }
        public RoomTradeSetting TradeSetting { get; init; }
    }
}
