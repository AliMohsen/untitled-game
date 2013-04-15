using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Processor.Content.Textures
{
    public class TextureLibrary
    {
        static Dictionary<int, TextureDefinition> definitions = new Dictionary<int, TextureDefinition>();

        public static void initModelLibrary(ContentManager content)
        {
            definitions.Add(0, new TextureDefinition("test", content.Load<Texture2D>("texture//test"), new Vector2(1),
                0, new Vector2(10), new Rectangle(0,0,20,20)));
            definitions.Add(1, new TextureDefinition("human", content.Load<Texture2D>("texture//humanEntity"), new Vector2(1),
                0, new Vector2(15), new Rectangle(0, 0, 30, 30)));
        }

        public static int getModelIdFromName(String name)
        {
            foreach (KeyValuePair<int, TextureDefinition> definitionEntry in definitions)
            {
                if (definitionEntry.Value.getName().Equals(name))
                {
                    return definitionEntry.Key;
                }
            }
            throw new ContentException("Could not find texture with name : [" + name + "].");
        }

        public static TextureDefinition getTextureFromId(int id)
        {
            return definitions[id];
        }
    }
}
