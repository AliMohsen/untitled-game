using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Processor.Content.Models
{
    public class ModelDefinition
    {
        String name;
        Texture2D spriteSheet;
        Vector2 scale;
        float defaultRotation;
        Vector2 origin;
        Rectangle sourceRectangle;

        public ModelDefinition(String name, Texture2D spriteSheet, Vector2 scale,
            float defaultRotation, Vector2 origin, Rectangle sourceRectangle)
        {
            this.name = name;
            this.spriteSheet = spriteSheet;
            this.scale = scale;
            this.defaultRotation = defaultRotation;
            this.origin = origin;
            this.sourceRectangle = sourceRectangle;
        }

        public String getName()
        {
            return name;
        }

        internal Texture2D getSpriteSheet()
        {
            return spriteSheet;
        }

        internal Rectangle getSourceRectangle()
        {
            return sourceRectangle;
        }

        internal Vector2 getOrigin()
        {
            return origin;
        }

        internal Vector2 getScale()
        {
            return scale;
        }
    }
}
