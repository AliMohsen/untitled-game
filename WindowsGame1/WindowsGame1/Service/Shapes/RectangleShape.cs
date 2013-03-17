using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service.Shapes
{
    class RectangleShape : IShape
    {
        protected Rectangle r;
        protected Vector2 rotatePoint;
        protected float rotation;
        protected int mass;

        public RectangleShape(Rectangle r, Vector2 rotatePoint, float rotation, int mass)
        {
            this.r = r;
            this.rotatePoint = rotatePoint;
            this.rotation = rotation;
            this.mass = mass;
        }
    }
}
