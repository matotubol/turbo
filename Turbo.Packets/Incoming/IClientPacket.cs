﻿namespace Turbo.Packets.Incoming
{
    public interface IClientPacket
    {
        string PopString();
        int PopInt();
        bool PopBoolean();
        short PopShort();
        double PopDouble();
        long PopLong();
        int RemainingLength();
        int Header { get; }
    }
}
