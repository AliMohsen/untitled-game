using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TheGameOfForever.Ui.Font
{
    /// <summary>
    /// Contains the sizes for a given font name.
    /// Able to programatically lazy-load a size given the size, style and spacing.
    /// </summary>
    public class BasicFontCollection : IFontCollection
    {
        private static String FONT_LOCATION = "fonts//";

        private Dictionary<FontKey, SpriteFont> fontMap = new Dictionary<FontKey, SpriteFont>();
        private Dictionary<FontKey, SpriteFont> fontMapBold = new Dictionary<FontKey, SpriteFont>();
        private Dictionary<FontKey, SpriteFont> fontMapItalics = new Dictionary<FontKey, SpriteFont>();

        private String fontName;

        private static int[] initialSizes = new int[]
        {
            10,
            12,
            14,
            16,
            20,
            24,
            30
        };

        public BasicFontCollection(String fontName, ContentManager contentManager)
        {
            this.fontName = fontName;
        }

        private SpriteFont getFont(FontKey key, Dictionary<FontKey, SpriteFont> dict)
        {
            if (!dict.ContainsKey(key))
            {
                SpriteFont fontToAdd = Game1.content.Load<SpriteFont>(FONT_LOCATION + fontName + key.size);
                dict.Add(new FontKey(key.size, key.style), fontToAdd);
                return fontToAdd;            
            }
            return dict[key];
        }

        public SpriteFont getSize(int size)
        {
            return getFont(new FontKey(size, Style.REGULAR), fontMap);
        }

        private struct FontKey
        {
            public readonly int size;
            public readonly Style style;
            public FontKey(int size, Style style)
            {
                this.size = size;
                this.style = style;
            }
        }

        private enum Style
        {
            REGULAR,
            BOLD,
            ITALICS
        }
    }
}
