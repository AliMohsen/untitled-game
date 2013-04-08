using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.GameState;

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

    }
}
