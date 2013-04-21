using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service.Shapes
{
    public class RectangleShape : IShape
    {
        protected Rectangle rectangle;
        protected Vector2 rotatePoint;
        protected float rotation;
        protected int mass;
        protected Vector2 location;

        public RectangleShape(Rectangle rectangle, Vector2 rotatePoint, float rotation, int mass)
        {
            this.rectangle = rectangle;
            this.rotatePoint = rotatePoint;
            this.rotation = rotation;
            this.mass = mass;
        }

        public Rectangle getRectangle()
        {
            return rectangle;
        }

        public Vector2 getLocation()
        {
            return new Vector2(rectangle.X, rectangle.Y);
        }

        public void setLocation(Vector2 location)
        {
            rectangle.X = (int) location.X;
            rectangle.Y = (int) location.Y;
        }

        public Vector2 getRotatePoint()
        {
            return rotatePoint;
        }

        public float getRotation()
        {
            return rotation;
        }

        public void setRotation(float rotation)
        {
            this.rotation = rotation;
        }
    }
}
