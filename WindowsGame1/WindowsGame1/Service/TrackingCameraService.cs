using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;

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
        { }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            TrackingCameraObserver observer = (TrackingCameraObserver)gameState;
            gameState.getCamera().setWorldPosition(new Vector2(
                MathHelper.SmoothStep(
                    observer.getLocationToTrack().X,
                    gameState.getCamera().getWorldPosition().X, 0.8f),
                MathHelper.SmoothStep(
                    observer.getLocationToTrack().Y,
                    gameState.getCamera().getWorldPosition().Y, 0.8f)));
            gameState.getCamera().setRotation(observer.getRotationToTrack());
        }
    }
}
