using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.Processor.Content.Model
{
    public class ModelDefinition
    {
        VertexPositionNormalTexture[] vertices;
        String name;

        public ModelDefinition(String name, VertexPositionNormalTexture[] vertices)
        {
            this.vertices = vertices;
            this.name = name;
        }

        public VertexPositionNormalTexture[] getVertices()
        {
            return vertices;
        }

        public String getName()
        {
            return name;
        }
    }
}
