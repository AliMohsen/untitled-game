using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Draw
{
    public class DrawHelper
    {
        public static void spriteBatchBeginGame(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, 
                GameStateManager.getCamera().getCameraTransformMatrix());
        }

        public static void spriteBatchBeginUI(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
        }

        public static void drawBetween(Vector2 start, Vector2 end, SpriteBatch spriteBatch, Color color, float width)
        {
            Vector2 between = start - end;
            float angle = (float)Math.Atan2(between.Y, between.X);
            // add 1 for single points and due to the way   
            // the origin is set up  
            float distance = between.Length() + 1.0f;

            SpriteBatchWrapper.DrawGame(EditorContent.blank, end, null, color, angle, new Vector2(0, 0.5f),
                new Vector2(distance, width), SpriteEffects.None, 1);
        }
    }
}
