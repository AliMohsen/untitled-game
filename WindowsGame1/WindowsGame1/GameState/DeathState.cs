using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public class DeathState : AbstractGameState, DeathService.Observer
    {
        public DeathState(GameStateManager gameStateManager) 
            : base(gameStateManager)
        {
            addService(gameStateManager.getService<UnitDrawService>());
            addService(gameStateManager.getService<MapDrawService>());
            addService(gameStateManager.getService<StatusDrawService>());
            addService(gameStateManager.getService<KillCamService>());
            addService(gameStateManager.getService<DeathService>());
        }

        public override bool isPropagateUpdate()
        {
            return false;
        }

        public override bool isPropagateDraw()
        {
            return false;
        }

        public void noMoreDead()
        {
            removeState();
        }
    }
}
