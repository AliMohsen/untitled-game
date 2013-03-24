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
    public class MovementService : AbstractGameService
    {
        public interface MovementServiceObserver
        {
            void endMovement();
            void setHasMovement(bool hasMovement);
            void setEntityLocation(Vector2 entityLocation);
            int getEntityId();
        }

        public MovementService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(CollisionHitBox));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            MovementServiceObserver observer = (MovementServiceObserver)gameState;
            IControl control = DefaultControl.Instance;
            int entityId = observer.getEntityId();
            Entity entity = entityManager.getEntity(entityId);
            if (entity.hasComponent<LocationComponent>())
            {
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();
                // Need controller input.
                Vector2 moveInDirection = Vector2.Zero;
                if (control.isLLeftHeld())
                {
                    //moveInDirection += new Vector2(-1, 0);
                    moveInDirection += new Vector2(-26f * gameTime.ElapsedGameTime.Milliseconds/1000f, 0);
                }
                if (control.isLRightHeld())
                {
                    //moveInDirection += new Vector2(1, 0);
                    moveInDirection += new Vector2(26f * gameTime.ElapsedGameTime.Milliseconds / 1000f, 0);
                }
                if (control.isLDownHeld())
                {
                    //moveInDirection += new Vector2(0, 1);
                    moveInDirection += new Vector2(0, 26f * gameTime.ElapsedGameTime.Milliseconds / 1000f);
                }
                if (control.isLUpHeld())
                {
                    //moveInDirection += new Vector2(0, -1);
                    moveInDirection += new Vector2(0, -26f * gameTime.ElapsedGameTime.Milliseconds / 1000f);
                }
                locationComponent.setCurrentLocation(locationComponent.getCurrentLocation() + moveInDirection);
                if (moveInDirection != Vector2.Zero)
                {
                    observer.setHasMovement(true);
                }

                if (control.isActionAPressed())
                {
                    observer.endMovement();
                }
                observer.setEntityLocation(locationComponent.getCurrentLocation());
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
