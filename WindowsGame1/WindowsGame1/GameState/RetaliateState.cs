using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public class RetaliateState : AbstractGameState, RetaliationService.Observer, TakeDamageService.Observer
    {
        public RetaliateState(GameStateManager gameStateManager) 
            : base(gameStateManager)
        {
            addService(gameStateManager.getService<RetaliationService>());
            addService(gameStateManager.getService<UnitDrawService>());
            addService(gameStateManager.getService<ProjectileService>());
            addService(gameStateManager.getService<TakeDamageService>());
            addService(gameStateManager.getService<MapDrawService>());
            addService(gameStateManager.getService<StatusDrawService>());
            addService(gameStateManager.getService<ProjectileCollisionService>());
            addService(gameStateManager.getService<TrackingCameraService>());
        }

        public override bool isPropagateUpdate()
        {
            return false;
        }

        public override bool isPropagateDraw()
        {
            return false;
        }

        public void retaliationComplete()
        {
            removeState();
        }

        public void handleEndRetaliation()
        {
            gameStateManager.removeState(this);
        }

        public void handleUnitDeath()
        {
            this.addStateOnTopOfThis(new DeathState(gameStateManager));
        }
    }
}
