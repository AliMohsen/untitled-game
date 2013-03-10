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
        //public static Texture2D whiteCorner5x5 = contentManager.Load<Texture2D>("whiteCorner5x5");
    }
}
