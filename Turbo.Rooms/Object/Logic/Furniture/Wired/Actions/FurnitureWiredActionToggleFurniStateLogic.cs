﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.Core.Game.Rooms.Object.Logic.Wired;

namespace Turbo.Rooms.Object.Logic.Furniture.Wired.Actions
{
    public class FurnitureWiredActionToggleFurniStateLogic : FurnitureWiredActionLogic
    {
        public override bool CanTrigger(IWiredArguments wiredArguments = null)
        {
            if (!base.CanTrigger(wiredArguments)) return false;

            return true;
        }
    }
}
