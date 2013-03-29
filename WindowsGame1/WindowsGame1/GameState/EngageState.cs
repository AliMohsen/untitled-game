using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    class EngageState : AbstractGameState
    {
        private int controlId;

        public EngageState(int entityId, GameStateManager gameStateManager) 
            : base(gameStateManager)
        {
            this.controlId = entityId;
            gameServices.Add(gameStateManager.getService<UnitFireService>());
        }

        public void disengage()
        {
            this.removeState();
        }

        public int getControlId()
        {
            return controlId;
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
