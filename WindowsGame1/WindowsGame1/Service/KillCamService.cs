using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Draw;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Service
{
    public class KillCamService : AbstractGameService
    {
        public KillCamService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(DeadComponent));
        }

        public override void update(GameTime gameTime, GameState.AbstractGameState gameState)
        {
            foreach (int id in entityIds[0])
            {
                gameState.getCamera().setDesiredZoom(1.5f);
                LocationComponent tracking = entityManager.getEntity(id)
                    .getComponent<LocationComponent>();
                if (tracking != null)
                {
                    gameState.getCamera().setDesiredWorldPosition(tracking.getCurrentLocation());
                }
                return;
            }
        }
    }
}
