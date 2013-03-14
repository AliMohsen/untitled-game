using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Ui.Layer
{
    interface ILayer
    {
        bool stopUpdatePropagation();
        bool stopDrawPropagation();

        void draw(SpriteBatch spriteBatch);
        void update(GameTime gameTime);
    }
}
