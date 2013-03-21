using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    /// <summary>
    /// Represents a single movement phase, state discarded when the player ends the movement state or runs out of time.
    /// </summary>
    public class MovementState : AbstractGameState
    {
        Boolean startedMoving = false;
        private int entityId;
        private float millisActive = 0;

        public MovementState(int entityId, GameStateManager gameStateManager) : base(gameStateManager)
        {
            this.entityId = entityId;
            gameServices.Add(gameStateManager.getService<MovementControlService>());
        }

        public int getEntityId()
        {
            return entityId;
        }

        public void setHasMovement(bool moved)
        {
            startedMoving |= moved;
        }

        public bool isMoving()
        {
            return startedMoving;
        }

        public override bool isPropagateUpdate()
        {
            // Do not allow other states to run underneath this one.
            return false;
        }

        public override bool isPropagateDraw()
        {
            // Do not allow other states to draw underneath this one.
            return false;
        }
    }
}
