using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Ui.Layer
{
    public class SaveLoadLayer : ILayer
    {
        BasicButton saveButton;
        BasicButton loadButton;

        public SaveLoadLayer(UiService uiService)
        {
            saveButton = new BasicButton(uiService, new Rectangle(1030, 30, 100, 20), "Save");
            loadButton = new BasicButton(uiService, new Rectangle(1150, 30, 100, 20), "Load");
        }

        public bool stopUpdatePropagation()
        {
            return false;
        }

        public bool stopDrawPropagation()
        {
            return false;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            saveButton.draw(spriteBatch);
            loadButton.draw(spriteBatch);
        }

        public void update(GameTime gameTime)
        {
            
        }
    }
}
