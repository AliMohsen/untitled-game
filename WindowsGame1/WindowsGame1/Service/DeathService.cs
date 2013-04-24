using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Ui.Editor;
using TheGameOfForever.Draw;
using Microsoft.Xna.Framework;
using TheGameOfForever.Ui.Font;

namespace TheGameOfForever.Service
{
    public class DeathService : AbstractGameService
    {
        public interface Observer
        {
            void noMoreDead();
        }

        public DeathService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(DeadComponent));
        }

        public override void update(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState gameState)
        {
            if (entityIds[0].count() == 0)
            {
                ((Observer)gameState).noMoreDead();
                return;
            }

            foreach (int id in entityIds[0])
            {
                Entity entity = entityManager.getEntity(id);
                DeadComponent dead = entity.getComponent<DeadComponent>();
                dead.decrementKillScreenTime(gameTime.ElapsedGameTime.Milliseconds);
                if (dead.getkillScreenTime() <= 0)
                {
                    entityManager.removeEntity(id);
                }
                return;
            }
        }
        Random rand = new Random();
        public override void draw(GameTime gameTime, GameState.AbstractGameState gameState, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {

            if (entityIds[0].count() != 0)
            {
                foreach (int id in entityIds[0])
                {
                    Entity entity = entityManager.getEntity(id);
                    DeadComponent dead = entity.getComponent<DeadComponent>();
                    float towards = (1 - (float) dead.getkillScreenTime() / 4000) * 1.2f;

                    float shakeX = (float) (rand.NextDouble() * 6 * towards);
                    float shakeY = (float) (rand.NextDouble() * 6 * towards);
                    DrawStringHelper.drawStringUI(spriteBatch, "R I P", "mentone", 24, Color.Red * towards, 
                        new Vector2(500, 220), VerticalAlignment.CENTERED, HorizontalAlignment.CENTERED);
                    SpriteBatchWrapper.DrawUI(EditorContent.alone, new Vector2(500, 320) + new Vector2(shakeX,shakeY) , EditorContent.alone.Bounds, Color.White * towards, 0,
                        new Vector2(EditorContent.alone.Width / 2, EditorContent.alone.Height / 2), 0.6f * towards > 0.5 ? (towards * 0.5f + 1) : 0.5f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 1);
                    return;
                }
            }
        }
    }
}
