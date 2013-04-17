
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame4
{
    public static class begin
    {
        private static GraphicsDevice graphics;

        public static void setGraphics(GraphicsDevice g)
        {
            graphics = g;
        }

        public static void Alpha(SpriteBatch sprite)
        {
            sprite.Begin(SpriteBlendMode.AlphaBlend,
                        SpriteSortMode.Immediate,
                        SaveStateMode.SaveState,
                        Camera2d.get_transformation(graphics));
        }

        public static void Additive(SpriteBatch sprite)
        {
            sprite.Begin(SpriteBlendMode.Additive,
                        SpriteSortMode.Immediate,
                        SaveStateMode.SaveState,
                        Camera2d.get_transformation(graphics));
        }

            

    }
}
