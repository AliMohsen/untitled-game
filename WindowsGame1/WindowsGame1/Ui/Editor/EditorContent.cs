using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TheGameOfForever.Ui.Editor
{
    class EditorContent
    {
        private static ContentManager contentManager = Game1.content;
        public static Texture2D blank = contentManager.Load<Texture2D>("basictextures\\blank");
        public static Texture2D circle100 = contentManager.Load<Texture2D>("basictextures\\circle100");
        public static Texture2D yellowBullet = contentManager.Load<Texture2D>("basictextures\\yellowBullet");
        public static Texture2D alone = contentManager.Load<Texture2D>("basictextures\\alone");
        //public static Texture2D whiteCorner5x5 = contentManager.Load<Texture2D>("whiteCorner5x5");
    }
}
