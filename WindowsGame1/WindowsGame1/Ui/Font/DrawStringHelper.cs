using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Ui.Font
{
    public class DrawStringHelper
    {

        public static void drawString(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position)
        {
            drawString(sprite, text, fontName, size, color, position, Alignment.RIGHTALIGN);
        }

        public static void drawString(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, Alignment alignment)
        {
            SpriteFont font = FontFactory.getInstance().getFont(fontName).getSize(size);
            switch (alignment)
            {
                case Alignment.LEFTALIGN:
                    position = new Vector2(position.X - font.MeasureString(text).X, position.Y);
                    break;
                case Alignment.RIGHTALIGN:
                    break;
                case Alignment.CENTERED:
                    position = new Vector2(position.X - (font.MeasureString(text).X / 2), position.Y);
                    break;
            }
            sprite.DrawString(font, text, position, color);
        }
    }

    public enum Alignment
    {
        LEFTALIGN,
        RIGHTALIGN,
        CENTERED
    }
}
