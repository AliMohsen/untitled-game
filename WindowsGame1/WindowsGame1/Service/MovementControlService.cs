using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.GameState;
using TheGameOfForever.Control;

namespace TheGameOfForever.Service
{
    public class MovementControlService : AbstractGameService
    {
        public MovementControlService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(CollisionHitBox));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            IControl control = DefaultControl.Instance;
            int entityId = ((MovementState)gameState).getEntityId();
            Entity entity = entityManager.getEntity(entityId);
            if (entity.hasComponent<LocationComponent>())
            {
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();
                // Need controller input.
                Vector2 moveInDirection = Vector2.Zero;
                if (control.isLLeftHeld())
                {
                    moveInDirection += new Vector2(-1, 0);
                }
                if (control.isLRightHeld())
                {
                    moveInDirection += new Vector2(1, 0);
                }
                if (control.isLDownHeld())
                {
                    moveInDirection += new Vector2(0, 1);
                }
                if (control.isLUpHeld())
                {
                    moveInDirection += new Vector2(0, -1);
                }
                locationComponent.setCurrentLocation(locationComponent.getCurrentLocation() + moveInDirection);
                if (moveInDirection != Vector2.Zero)
                {
                    ((MovementState)gameState).setHasMovement(true);
                }

                if (control.isActionAPressed())
                {
                    ((MovementState)gameState).endMovement();
                }
            }
        }

        /// <summary>
        /// Check on map and against other entities whether it can move.
        /// </summary>
        /// <param name="location"></param>
        private bool checkMovePossible(Vector2 location)
        {
            foreach (int entityId in entityIds)
            {
                Entity entity = entityManager.getEntity(entityId);
                // check if collides
                if (true)
                {
                    continue;
                }
                return false;
            }
            //We need to check map item collisions as well.
            return true;
        }
    }
}
