using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Component;
using TheGameOfForever.Entities;
using TheGameOfForever.Ui.Editor;
using TheGameOfForever.Ui.Font;

namespace TheGameOfForever.Service
{
    public class MapDrawService : AbstractGameService
    {
        public MapDrawService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(MapElementComponent), typeof(VertexListComponent));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {}

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            foreach (int id in entityIds[0])
            {
                float area = 0;
                float centerX = 0;
                float centerY = 0;
                List<Vector2> points = entityManager.getEntity(id).getComponent<VertexListComponent>().getPoints();
                for (int i = 0; i < points.Count; i++)
                {
                    Vector2 start = points[i];
                    Vector2 end;

                    if (i + 1 == points.Count)
                    {
                        end = points[0];
                    }
                    else
                    {
                        end = points[i + 1];
                    }

                    float areaToAdd = start.X * end.Y - end.X * start.Y;
                    centerX += (start.X + end.X) * areaToAdd;
                    centerY += (start.Y + end.Y) * areaToAdd;
                    area += areaToAdd;

                    drawBetween(start, end, spriteBatch);
                }
                area /= 2;
                if (area != 0)
                {
                    centerX /= 6 * area;
                    centerY /= 6 * area;
                }
                DrawStringHelper.drawString(spriteBatch, "Map\nitem", "mentone", 10, Color.Purple, new Vector2(centerX, centerY), 
                    VerticalAlignment.CENTERED, HorizontalAlignment.CENTERED);
            }

            base.draw(gameTime, gameState, spriteBatch);
        }

        private void drawBetween(Vector2 start, Vector2 end, SpriteBatch spriteBatch)
        {
            Vector2 between = start - end;
            float angle = (float)Math.Atan2(between.Y, between.X);
            // add 1 for single points and due to the way   
            // the origin is set up  
            float distance = between.Length() + 1.0f;
            spriteBatch.Draw(EditorContent.blank, end, null, Color.Black, angle, new Vector2(0, 0.5f),
                new Vector2(distance, 2), SpriteEffects.None, 1);
            spriteBatch.Draw(EditorContent.blank, end, null, Color.Orange, angle, new Vector2(0, 0.5f),
                new Vector2(2, 2), SpriteEffects.None, 1);
            spriteBatch.Draw(EditorContent.blank, end, null, Color.Orange, angle, new Vector2(0.5f),
                 new Vector2(2, 2), SpriteEffects.None, 1);
        }
    }
}
