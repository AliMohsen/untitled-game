using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.GameState
{
    /// <summary>
    /// Represents a single movement phase, state discarded when the player ends the movement state or runs out of time.
    /// </summary>
    public class MovementState : AbstractGameState, TrackingCameraService.TrackingCameraObserver,
        MovementService.MovementServiceObserver
    {
        Boolean startedMoving = false;
        private int entityId;
        private float millisActive = 0;
        private Vector2 entityLocation;
        private float entityRotation;
        long millisToMove;

        public MovementState(int entityId, GameStateManager gameStateManager) : base(gameStateManager)
        {
            this.entityId = entityId;
            addService(gameStateManager.getService<UnitDrawService>());
            addService(gameStateManager.getService<MovementService>());
            addService(gameStateManager.getService<TrackingCameraService>());
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

        public void endMovement()
        {
            this.removeState();
        }

        public Vector2 getLocationToTrack()
        {
            return entityLocation;
        }

        public void setEntityLocation(Vector2 entityLocation)
        {
            this.entityLocation = entityLocation;
        }

        public void engageUnit()
        {
            addStateOnTopOfThis(new EngageState(entityId, gameStateManager));
        }


        public void setEntityRotation(float rotation)
        {
            this.entityRotation = rotation;
        }


        public float getRotationToTrack()
        {
            return entityRotation;
        }


        public bool getHasMovement()
        {
            return startedMoving;
        }

        public long getMillisToMove()
        {
            return millisToMove;
        }

        public void setMillisToMove(long millis)
        {
            millisToMove = millis;
        }
    }
}
