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
        VertexPositionColor[] vertices;
        String name;

        public ModelDefinition(String name, params VertexPositionColor[] vertices)
        {
            this.vertices = vertices;
            this.name = name;
        }

        public ModelDefinition(String name, VertexPositionColor[] vertices)
        {
            this.vertices = vertices;
            this.name = name;
        }

        public VertexPositionColor[] getVertices()
        {
            return vertices;
        }

        public String getName()
        {
            return name;
        }
    }
}
