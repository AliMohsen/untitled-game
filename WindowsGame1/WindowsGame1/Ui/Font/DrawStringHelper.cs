using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TheGameOfForever.Draw;

namespace TheGameOfForever.Ui.Font
{
    public class DrawStringHelper
    {
        public static void drawString(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, float rotationRadians)
        {
            drawString(sprite, text, fontName, size, color, position, rotationRadians, VerticalAlignment.RIGHTALIGN, HorizontalAlignment.BELOW);
        }

        public static void drawStringGame(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, float rotationRadians)
        {
            drawStringGame(sprite, text, fontName, size, color, position, rotationRadians, VerticalAlignment.RIGHTALIGN, HorizontalAlignment.BELOW);
        }

        public static void drawStringUI(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position)
        {
            drawStringUI(sprite, text, fontName, size, color, position, VerticalAlignment.RIGHTALIGN, HorizontalAlignment.BELOW);
        }

        public static void drawStringCustom(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, Matrix transform)
        {
            drawStringCustom(sprite, text, fontName, size, color, position, VerticalAlignment.RIGHTALIGN, HorizontalAlignment.BELOW, transform);
        }
        
        public static void drawString(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, float rotationRadians, VerticalAlignment alignment, HorizontalAlignment horizontalAlignment)
        {
            SpriteFont font = FontFactory.getInstance().getFont(fontName).getSize(size);
            switch (alignment)
            {
                case VerticalAlignment.LEFTALIGN:
                    position = new Vector2(position.X - font.MeasureString(text).X, position.Y);
                    break;
                case VerticalAlignment.RIGHTALIGN:
                    break;
                case VerticalAlignment.CENTERED:
                    position = new Vector2(position.X - (font.MeasureString(text).X / 2), position.Y);
                    break;
            }
            switch (horizontalAlignment)
            {
                case HorizontalAlignment.ABOVE:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y);
                    break;
                case HorizontalAlignment.BELOW:
                    break;
                case HorizontalAlignment.CENTERED:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y / 2);
                    break;
            }
            sprite.DrawString(font, text, new Vector2((int)position.X, (int)position.Y), color);
        }

        public static void drawStringGame(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, float rotationRadians, VerticalAlignment alignment, HorizontalAlignment horizontalAlignment)
        {
            SpriteFont font = FontFactory.getInstance().getFont(fontName).getSize(size);
            switch (alignment)
            {
                case VerticalAlignment.LEFTALIGN:
                    position = new Vector2(position.X - font.MeasureString(text).X, position.Y);
                    break;
                case VerticalAlignment.RIGHTALIGN:
                    break;
                case VerticalAlignment.CENTERED:
                    position = new Vector2(position.X - (font.MeasureString(text).X / 2), position.Y);
                    break;
            }
            switch (horizontalAlignment)
            {
                case HorizontalAlignment.ABOVE:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y);
                    break;
                case HorizontalAlignment.BELOW:
                    break;
                case HorizontalAlignment.CENTERED:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y / 2);
                    break;
            }
            SpriteBatchWrapper.DrawStringGame(font, text, new Vector2((int)position.X, (int)position.Y), rotationRadians, color);
        }

        public static void drawStringUI(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, VerticalAlignment alignment, HorizontalAlignment horizontalAlignment)
        {
            SpriteFont font = FontFactory.getInstance().getFont(fontName).getSize(size);
            switch (alignment)
            {
                case VerticalAlignment.LEFTALIGN:
                    position = new Vector2(position.X - font.MeasureString(text).X, position.Y);
                    break;
                case VerticalAlignment.RIGHTALIGN:
                    break;
                case VerticalAlignment.CENTERED:
                    position = new Vector2(position.X - (font.MeasureString(text).X / 2), position.Y);
                    break;
            }
            switch (horizontalAlignment)
            {
                case HorizontalAlignment.ABOVE:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y);
                    break;
                case HorizontalAlignment.BELOW:
                    break;
                case HorizontalAlignment.CENTERED:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y / 2);
                    break;
            }
            SpriteBatchWrapper.DrawStringUI(font, text, new Vector2((int)position.X, (int)position.Y), color);
        }

        public static void drawStringCustom(SpriteBatch sprite, String text, String fontName, int size, Color color,
            Vector2 position, VerticalAlignment alignment, HorizontalAlignment horizontalAlignment, Matrix transform)
        {
            SpriteFont font = FontFactory.getInstance().getFont(fontName).getSize(size);
            switch (alignment)
            {
                case VerticalAlignment.LEFTALIGN:
                    position = new Vector2(position.X - font.MeasureString(text).X, position.Y);
                    break;
                case VerticalAlignment.RIGHTALIGN:
                    break;
                case VerticalAlignment.CENTERED:
                    position = new Vector2(position.X - (font.MeasureString(text).X / 2), position.Y);
                    break;
            }
            switch (horizontalAlignment)
            {
                case HorizontalAlignment.ABOVE:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y);
                    break;
                case HorizontalAlignment.BELOW:
                    break;
                case HorizontalAlignment.CENTERED:
                    position = new Vector2(position.X, position.Y - font.MeasureString(text).Y / 2);
                    break;
            }
            SpriteBatchWrapper.DrawStringCustom(font, text, new Vector2((int)position.X, (int)position.Y), color, transform);
        }
    }

    public enum VerticalAlignment
    {
        LEFTALIGN,
        RIGHTALIGN,
        CENTERED
    }

    public enum HorizontalAlignment
    {
        CENTERED,
        ABOVE,
        BELOW
    }
}
