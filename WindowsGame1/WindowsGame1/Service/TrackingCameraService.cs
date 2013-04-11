using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using TheGameOfForever.Component;

namespace TheGameOfForever.Service
{

    public class TrackingCameraService : AbstractGameService
    {
        public interface TrackingCameraObserver
        {
            Vector2 getLocationToTrack();
            float getRotationToTrack();
        }

        public TrackingCameraService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(TrackingComponent));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            if (entityIds[0].count() != 0)
            {
                TrackingComponent tracking = entityManager.getEntity(entityIds[0].getLast())
                    .getComponent<TrackingComponent>();
                gameState.getCamera().setWorldPosition(new Vector2(
                    MathHelper.SmoothStep(
                        tracking.getTrackingLocation().X,
                        gameState.getCamera().getWorldPosition().X, 0.8f),
                    MathHelper.SmoothStep(
                        tracking.getTrackingLocation().Y,
                        gameState.getCamera().getWorldPosition().Y, 0.8f)));
                gameState.getCamera().setRotation(tracking.getTrackingRotation());
            }
            else
            {
                gameState.getCamera().setWorldPosition(new Vector2(
                    MathHelper.SmoothStep(
                        0,
                        gameState.getCamera().getWorldPosition().X, 0.8f),
                    MathHelper.SmoothStep(
                        0,
                        gameState.getCamera().getWorldPosition().Y, 0.8f)));
                gameState.getCamera().setRotation(0);
            }
        }
    }
}
