﻿namespace Turbo.Packets.Incoming.Room.Furniture
{
    public record SetMannequinFigureMessage : IMessageEvent
    {
        public int FurniId { get; init; }
    }
}
