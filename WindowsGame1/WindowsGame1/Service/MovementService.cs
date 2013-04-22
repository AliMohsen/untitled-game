﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.GameState;
using TheGameOfForever.Control;
using TheGameOfForever.Geometry;
using TheGameOfForever.Draw;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Service
{
    public class MovementService : AbstractGameService
    {
        public interface MovementServiceObserver
        {
            void endMovement();
            void engageUnit();
        }

        public MovementService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(Selected), typeof(MovementTime)); // 0
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            MovementServiceObserver observer = (MovementServiceObserver)gameState;
            IControl control = DefaultControl.Instance;
            int id = entityIds[0].getLast();

            Entity entity = entityManager.getEntity(id);
            if (entity.hasComponent<LocationComponent>())
            {
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();
                MovementComponent movementComponent = entity.getComponent<MovementComponent>();
                MovementTime movementTime = entity.getComponent<MovementTime>();

                // Need controller input.
                Vector2 moveInDirection = Vector2.Zero;
                if (control.isLLeftHeld())
                {
                    moveInDirection += new Vector2(1, 0);
                }
                if (control.isLRightHeld())
                {
                    moveInDirection += new Vector2(-1, 0);
                }
                if (control.isLDownHeld())
                {
                    moveInDirection += new Vector2(0, -1);
                }
                if (control.isLUpHeld())
                {
                    moveInDirection += new Vector2(0, 1);
                }

                if (moveInDirection != Vector2.Zero) moveInDirection.Normalize();
                moveInDirection = moveInDirection * movementComponent.getBaseMovementSpeed(gameTime);

                if (control.isRLeftHeld())
                {
                    locationComponent.setFacingRadians(locationComponent.getFacingRadians()
                        - movementComponent.getTurningSpeed(gameTime));
                }
                if (control.isRRightHeld())
                {
                    locationComponent.setFacingRadians(locationComponent.getFacingRadians()
                        + movementComponent.getTurningSpeed(gameTime));
                }
                if (movementTime.getMillisToMove() > 0)
                {
                    moveInDirection = GeometryHelper.rotateVec(moveInDirection, locationComponent.getFacingRadians());
                    locationComponent.setCurrentLocation(locationComponent.getCurrentLocation() + moveInDirection);
                }

                if (movementTime.getFullMillisToMove() == movementTime.getMillisToMove() && moveInDirection != Vector2.Zero
                    || movementTime.getFullMillisToMove() != movementTime.getMillisToMove())
                {
                    movementTime.decrementMillisToMove(gameTime.ElapsedGameTime.Milliseconds);
                }

                if (entity.hasComponent<TrackingComponent>())
                {
                    entity.getComponent<TrackingComponent>()
                        .setTrackingLocation(locationComponent.getCurrentLocation())
                        .setTrackingRotation(locationComponent.getFacingRadians());

                }

                if (control.isActionAPressed())
                {
                    movementTime.incrementMovedAmount();
                    entity.removeComponent<TrackingComponent>();
                    observer.endMovement();
                }

                if (control.isActionBPressed())
                {
                    observer.engageUnit();
                }
            }
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            int id = entityIds[0].getLast();
            Entity entity = entityManager.getEntity(id);
            MovementTime movementTime = entity.getComponent<MovementTime>();

            float fractionLeftToMove = movementTime.getMillisToMove() / (float)movementTime.getFullMillisToMove();
//            spriteBatch.End();

//            DrawHelper.spriteBatchBeginUI(spriteBatch);
            SpriteBatchWrapper.DrawUI(EditorContent.blank, new Rectangle(10, 10, 200, 5), Color.DarkGray);
            SpriteBatchWrapper.DrawUI(EditorContent.blank, new Rectangle(10, 11, (int)(200 * fractionLeftToMove), 2), Color.LightBlue);
//            spriteBatch.End();

//            DrawHelper.spriteBatchBeginGame(spriteBatch);

        }
    }
}