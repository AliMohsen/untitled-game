using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service
{
    class CollisionService
    {

        public Vector2 collide(Shapes.IShape a, Shapes.IShape b)
        {
            if (a is Shapes.RectangleShape && b is Shapes.RectangleShape)
            {
                return intersectRectangles(a, b);
            }

            if (a is Shapes.Circle && b is Shapes.RectangleShape)
            {
                return -intersectCircleRectangle(a, b);
            }

            if (a is Shapes.RectangleShape && b is Shapes.Circle)
            {
                return intersectCircleRectangle(a, b);
            }

            if (a is Shapes.Circle && b is Shapes.Circle)
            {
                return intersectCircles(a, b);
            }

            return Vector2.Zero;
        }

        public Vector2 intersectRectangles(Shapes.IShape a, Shapes.IShape b)
        {
            throw new NotImplementedException();
        }

        public Vector2 intersectCircleRectangle(Shapes.IShape a, Shapes.IShape b)
        {
            throw new NotImplementedException();
        }

        public Vector2 intersectCircles(Shapes.IShape a, Shapes.IShape b)
        {
            throw new NotImplementedException();
        }

    }
}
