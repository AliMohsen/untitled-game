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
                return intersectRectangles((Shapes.RectangleShape)a, (Shapes.RectangleShape)b);
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
                return intersectCircles((Shapes.Circle)a, (Shapes.Circle)b);
            }

            return Vector2.Zero;
        }

        public Vector2 intersectRectangles(Shapes.RectangleShape a, Shapes.RectangleShape b)
        {
            throw new NotImplementedException();
        }

        public Vector2 intersectCircleRectangle(Shapes.IShape a, Shapes.IShape b)
        {
            throw new NotImplementedException();
        }

        public Vector2 intersectCircles(Shapes.Circle a, Shapes.Circle b)
        {
            Vector2 aLocation = a.getLocation();
            Vector2 bLocation = b.getLocation();
            float aRadius = a.getRadius();
            float bRadius = b.getRadius();
            float distance = Vector2.Distance(aLocation, bLocation);

            if (distance > aRadius + bRadius)
            {
                return Vector2.Zero;
            }
            else
            {
                return Vector2.Normalize(bLocation - aLocation) * (distance - (aRadius + bRadius));
            }
        }

    }
}
