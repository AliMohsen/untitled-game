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
                gameState.getCamera().setDesiredZoom(1f);
                TrackingComponent tracking = entityManager.getEntity(entityIds[0].getLast())
                    .getComponent<TrackingComponent>();
                gameState.getCamera().setDesiredWorldPosition(tracking.getTrackingLocation());
                gameState.getCamera().setDesiredTrackingRotation(tracking.getTrackingRotation());
            }
            else
            {
                gameState.getCamera().setDesiredZoom(0.75f);
                gameState.getCamera().setDesiredRotation(0);
                gameState.getCamera().setDesiredWorldPosition(Vector2.Zero);
            }
        }
    }
}
