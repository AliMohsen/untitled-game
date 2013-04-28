using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public class EngageState : AbstractGameState, TakeDamageService.Observer, UnitFireService.Observer
    {
        public EngageState(GameStateManager gameStateManager) 
            : base(gameStateManager)
        {
            addService(gameStateManager.getService<UnitDrawService>());
            addService(gameStateManager.getService<UnitFireService>());
            addService(gameStateManager.getService<ProjectileService>());
            addService(gameStateManager.getService<TakeDamageService>());
            addService(gameStateManager.getService<MapDrawService>());
            addService(gameStateManager.getService<StatusDrawService>());
            addService(gameStateManager.getService<ProjectileCollisionService>());
            addService(gameStateManager.getService<TrackingCameraService>());
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

        public void handleUnitDeath()
        {
            this.addStateOnTopOfThis(new DeathState(gameStateManager));
        }

        public void handleFinishedFiring()
        {
            this.changeState(new RetaliateState(gameStateManager));
        }
    }
}
