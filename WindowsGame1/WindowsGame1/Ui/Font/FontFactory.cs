using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace TheGameOfForever.Ui.Font
{
    public class FontFactory
    {
        private Dictionary<String, IFontCollection> fonts = new Dictionary<string, IFontCollection>();

        private static FontFactory instance;

        private static ContentManager contentManager;

        public static void setContentManager(ContentManager contentManager)
        {
            FontFactory.contentManager = contentManager;
        }

        public static FontFactory getInstance()
        {
            if (instance == null)
            {
                instance = new FontFactory();
                instance.fonts.Add("Mentone", new BasicFontCollection("Mentone", FontFactory.contentManager));
            }
            return instance;
        }

        public IFontCollection getFont(String fontName)
        {
            return fonts[fontName];
        }
    }
}
