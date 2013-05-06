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
        static ModelLibrary()
        {
            VertexPositionNormalTexture[] vertices = new VertexPositionNormalTexture[12];
                //Front
                vertices[0].Position = new Vector3(-1, 0, 0);
                vertices[1].Position = new Vector3(0, 2, 0);
                vertices[2].Position = new Vector3(1, 0, 0);
                Vector3 normalOne = Vector3.Cross(vertices[1].Position - vertices[0].Position, 
                    vertices[2].Position - vertices[0].Position);
                normalOne.Normalize();
                vertices[0].Normal = -normalOne;
                vertices[1].Normal = -normalOne;
                vertices[2].Normal = -normalOne;
                vertices[0].TextureCoordinate = new Vector2(0, 1);
                vertices[1].TextureCoordinate = new Vector2(0.5f, 0);
                vertices[2].TextureCoordinate = new Vector2(1, 1);

                // Left
                 vertices[6].Position =new Vector3(-1, 0, 0);
                 vertices[7].Position = new Vector3(0, 0, -2);
                 vertices[8].Position =new Vector3(0, 2, 0);
                 Vector3 normalTwo = Vector3.Cross(vertices[7].Position - vertices[6].Position,
                    vertices[8].Position - vertices[6].Position);
                 normalTwo.Normalize();
                 vertices[6].Normal = -normalTwo;
                 vertices[7].Normal = -normalTwo;
                 vertices[8].Normal = -normalTwo;
                 vertices[6].TextureCoordinate = new Vector2(0, 1);
                 vertices[8].TextureCoordinate = new Vector2(0.5f, 0);
                 vertices[7].TextureCoordinate = new Vector2(1, 1);
                
                // Right
                 vertices[9].Position =new Vector3(1, 0, 0);
                 vertices[10].Position =new Vector3(0, 2, 0);
                 vertices[11].Position =new Vector3(0, 0, -2);
                 Vector3 normalThree = Vector3.Cross(vertices[10].Position - vertices[9].Position,
                    vertices[11].Position - vertices[9].Position);
                 normalThree.Normalize();
                 vertices[9].Normal = -normalThree;
                 vertices[10].Normal = -normalThree;
                 vertices[11].Normal = -normalThree;
                 vertices[9].TextureCoordinate = new Vector2(0, 1);
                 vertices[10].TextureCoordinate = new Vector2(0.5f, 0);
                 vertices[11].TextureCoordinate = new Vector2(1, 1);

                 definitions.Add(0, new ModelDefinition("human", vertices));
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
