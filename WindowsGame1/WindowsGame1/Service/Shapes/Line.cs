using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service.Shapes
{   
    public class Line : RectangleShape
    {
        private Vector2 startPoint;
        private int length;

        public Line(Vector2 startPoint, int length, float rotation, int mass) : base(new Rectangle(),startPoint,rotation,mass)
        {
            this.rectangle.X = (int)startPoint.X;
            this.rectangle.Y = (int)startPoint.Y;
            this.rectangle.Height = length;
            this.rectangle.Width = 0;
            this.rotation = rotation;
            this.mass = mass;
            this.rotatePoint = startPoint;
        }
    }
}
