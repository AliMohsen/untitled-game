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
using TheGameOfForever.Ui.Editor.Input;
using TheGameOfForever.Ui.Font;

namespace TheGameOfForever.Ui.Layer
{
    /// <summary>
    /// UI battle layer, shows the battle map.
    /// </summary>
    public class BattleLayer : ILayer
    {
        private Map map = new Map();
        private ICamera2D camera = new Basic2DCamera();

        private Vector2 screenOffset = new Vector2(10, 30);
        private Vector2 currentMousePosition;

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

        private Vector2 calculateMousePositionOnMap()
        {
            return new Vector2(MouseService.getX() - screenOffset.X,
                MouseService.getY() - screenOffset.Y);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null, camera.getCameraTransformMatrix());
            spriteBatch.Draw(EditorContent.blank, new Rectangle((int) screenOffset.X, (int) screenOffset.Y, 
                (int)Map.getWorldWidth(), (int)Map.getWorldHeight()), Color.LightGray);
            DrawStringHelper.drawString(spriteBatch, 
                "Loc[Metres]: (" + (int) (currentMousePosition.X / 5) + ", " + (int) (currentMousePosition.Y / 5) + ")", "mentone", 10,
                Color.Black, new Vector2(screenOffset.X, screenOffset.Y + Map.getWorldHeight() - 17));
            spriteBatch.End();
            spriteBatch.Begin();
        }

        public void update(GameTime gameTime)
        {
            currentMousePosition = calculateMousePositionOnMap();
        }
    }
}
