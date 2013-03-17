using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service.Shapes
{
    public class Circle : IShape
    {
        private Vector2 location;
        private float radius;
        private int mass;

        public Circle(Vector2 location, float radius, int mass)
        {
            this.location = location;
            this.radius = radius;
            this.mass = mass;
        }
    }
}
