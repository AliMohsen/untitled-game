using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Processor.Content.Models
{
    public class ModelLibrary
    {
        static Dictionary<int, ModelDefinition> definitions = new Dictionary<int, ModelDefinition>();

        public static void initModelLibrary(ContentManager content)
        {
            definitions.Add(0, new ModelDefinition("test", content.Load<Texture2D>("model//test"), new Vector2(1),
                0, new Vector2(10), new Rectangle(0,0,20,20)));
        }

        public static int getModelIdFromName(String name)
        {
            foreach (KeyValuePair<int, ModelDefinition> definitionEntry in definitions)
            {
                if (definitionEntry.Value.getName().Equals(name))
                {
                    return definitionEntry.Key;
                }
            }
            throw new ContentException("Could not find model with name : [" + name + "].");
        }

        public static ModelDefinition getModelFromId(int id)
        {
            return definitions[id];
        }
    }
}
