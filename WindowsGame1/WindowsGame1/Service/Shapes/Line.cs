using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service.Shapes
{   
    class Line : RectangleShape
    {
        private Vector2 startPoint;
        private int length;

        public Line(Vector2 startPoint, int length, float rotation, int mass) : base(new Rectangle(),startPoint,rotation,mass)
        {
            this.r.X = (int)startPoint.X;
            this.r.Y = (int)startPoint.Y;
            this.r.Height = length;
            this.r.Width = 0;
            this.rotation = rotation;
            this.mass = mass;
            this.rotatePoint = startPoint;
        }
    }
}
