using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turbo.Core.Packets.Messages;

namespace Turbo.Packets.Incoming.Catalog
{
    public record GetDirectClubBuyAvailableMessage : IMessageEvent
    {
        public int Days { get; init; }
    }
}