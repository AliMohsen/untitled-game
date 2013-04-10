﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public class EngageState : AbstractGameState
    {
        public EngageState(GameStateManager gameStateManager) 
            : base(gameStateManager)
        {
            addService(gameStateManager.getService<UnitDrawService>());
            addService(gameStateManager.getService<UnitFireService>());
        }

        public void disengage()
        {
            this.removeState();
        }

        public override bool isPropagateUpdate()
        {
            return false;
        }

        public override bool isPropagateDraw()
        {
            return false;
        }
    }
}
