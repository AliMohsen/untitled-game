using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TheGameOfForever.Component.Map;
using TheGameOfForever.View.Camera;
using Microsoft.Xna.Framework.Input;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Ui.Layer
{
    /// <summary>
    /// UI battle layer, shows the battle map.
    /// </summary>
    public class BattleLayer : ILayer
    {
        private Map map = new Map();
        private ICamera camera = new Basic2DCamera();

        public BattleLayer()
        {

            camera.setMap(map);
        }

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
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null, camera.getCameraTransformMatrix());
            spriteBatch.Draw(EditorContent.blank, new Rectangle(10, 30, (int)Map.getWorldWidth(), (int)Map.getWorldHeight()), Color.Gray);
            spriteBatch.End();
            spriteBatch.Begin();
        }

        public void update(GameTime gameTime)
        {
            /*
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 worldPosition = camera.getWorldPosition();
            if (keyboardState.IsKeyDown(Keys.A))
            {
                worldPosition += new Vector2(-1, 0);
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                worldPosition += new Vector2(0, -1);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                worldPosition += new Vector2(0, 1);
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                worldPosition += new Vector2(1, 0);
            }
            camera.setWorldPosition(worldPosition);
             */
        }
    }
}
