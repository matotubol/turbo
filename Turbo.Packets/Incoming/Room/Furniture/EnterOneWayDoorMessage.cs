﻿namespace Turbo.Packets.Incoming.Room.Furniture
{
    public record EnterOneWayDoorMessage : IMessageEvent
    {
        public int ObjectId { get; init; }
    }
}
