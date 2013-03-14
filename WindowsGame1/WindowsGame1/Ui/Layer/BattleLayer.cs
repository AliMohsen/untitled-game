using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TheGameOfForever.Component.Map;

namespace TheGameOfForever.Ui.Layer
{
    /// <summary>
    /// UI battle layer, shows the battle map.
    /// </summary>
    private class BattleLayer : ILayer
    {
        private Map map;

        Boolean focus = false;

        public bool stopUpdatePropagation()
        {
            return focus;
        }

        public bool stopDrawPropagation()
        {
            return false;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
