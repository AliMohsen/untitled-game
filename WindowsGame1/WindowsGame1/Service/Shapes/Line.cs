using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Geometry;

namespace TheGameOfForever.Service.Shapes
{   
    public class Line : RectangleShape
    {
        private Vector2 startPoint;

        public Line(Vector2 startPoint, int length, float rotation, int mass) : 
            base(new Rectangle(), startPoint, rotation, mass)
        {
            this.rectangle.X = (int)startPoint.X;
            this.rectangle.Y = (int)startPoint.Y;
            this.rectangle.Height = length;
            this.rectangle.Width = 1;
            this.rotation = rotation;
            this.startPoint = startPoint;
            this.mass = mass;
            this.rotatePoint = Vector2.Zero;
        }

        public Vector2 getStartPoint()
        {
            return startPoint;
        }

        public Vector2 getEndPoint()
        {
            return GeometryHelper.rotatePoint(startPoint
                + new Vector2(0,rectangle.Height), startPoint, rotation);
        }
    }
}
