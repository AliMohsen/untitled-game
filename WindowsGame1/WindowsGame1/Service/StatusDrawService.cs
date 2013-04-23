using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Draw;
using TheGameOfForever.Ui.Font;
using TheGameOfForever.Geometry;

namespace TheGameOfForever.Service
{
    public class StatusDrawService : AbstractGameService
    {
        public StatusDrawService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(StatusDrawComponent), typeof(LocationComponent));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            foreach (int entityId in entityIds[0])
            {
                Entity entity = entityManager.getEntity(entityId);
                StatusDrawComponent statusDrawComponent = entity.getComponent<StatusDrawComponent>();
                for (int i = 0; i < statusDrawComponent.getCount(); i++)
                {
                    statusDrawComponent.getMillisLeft()[i] -= gameTime.ElapsedGameTime.Milliseconds;
                    if (statusDrawComponent.getMillisLeft()[i] <= 0)
                    {
                        statusDrawComponent.removeAt(i);
                    }
                }
            }
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            foreach (int entityId in entityIds[0])
            {
                Entity entity = entityManager.getEntity(entityId);
                StatusDrawComponent statusDrawComponent = entity.getComponent<StatusDrawComponent>();
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();

                for (int i = 0; i < statusDrawComponent.getCount(); i++)
                {
                    Tuple<string, Color, long, long> entry = statusDrawComponent.getEntry(i);
                    DrawStringHelper.drawStringGame(spriteBatch, entry.Item1, "mentone", 10, entry.Item2 * MathHelper.SmoothStep(0, 1.5f, 
                        (float)statusDrawComponent.getMillisLeft()[i] / statusDrawComponent.millisToDisplays[i]),
                        locationComponent.getCurrentLocation() + 
                        GeometryHelper.rotateVec(
                        new Vector2(15, 15 + 
                            MathHelper.SmoothStep(35, 0, (float)statusDrawComponent.getMillisLeft()[i]/statusDrawComponent.millisToDisplays[i])),
                                       gameState.getCamera().getRotation()), gameState.getCamera().getRotation() + (float) Math.PI);

                }
            }

        }
    }
}
