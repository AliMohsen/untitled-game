using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Processor.Content.Model
{
    public class ModelLibrary
    {
        static Dictionary<int, ModelDefinition> definitions = new Dictionary<int, ModelDefinition>();
        public static void initModelLibrary()
        {
            definitions.Add(0, new ModelDefinition("human", 
                // Back
                new VertexPositionColor(new Vector3(-1, 0, 0),Color.Gray),
                new VertexPositionColor(new Vector3(1, 0, 0),Color.Gray),
                new VertexPositionColor(new Vector3(0, 2, 0),Color.Gray),

                // Bottom
                new VertexPositionColor(new Vector3(-1, 0, 0),Color.Gray),
                new VertexPositionColor(new Vector3(1, 0, 0),Color.Gray),
                new VertexPositionColor(new Vector3(0, 0, 1),Color.Gray),

                // Left
                new VertexPositionColor(new Vector3(-1, 0, 0),Color.Gray),
                new VertexPositionColor(new Vector3(0, 0, 1),Color.Gray),
                new VertexPositionColor(new Vector3(0, 2, 0),Color.Gray),
                
                // Right
                new VertexPositionColor(new Vector3(1, 0, 0),Color.Gray),
                new VertexPositionColor(new Vector3(0, 0, 1),Color.Gray),
                new VertexPositionColor(new Vector3(0, 2, 0),Color.Gray)));
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
            throw new ContentException("Could not find texture with name : [" + name + "].");
        }

        public static ModelDefinition getModelFromId(int id)
        {
            return definitions[id];
        }
    }
}
