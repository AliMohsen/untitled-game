using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public class EngageState : AbstractGameState
    {
        private int entityId;

        public EngageState(int entityId, GameStateManager gameStateManager) 
            : base(gameStateManager)
        {
            this.entityId = entityId;
            addService(gameStateManager.getService<UnitDrawService>());
            addService(gameStateManager.getService<UnitFireService>());
        }

        public void disengage()
        {
            this.removeState();
        }

        public int getEntityId()
        {
            return entityId;
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
