using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service.Shapes;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Geometry
{
    public class CollisionHelper
    {
        public static Vector2 collide(IShape a, IShape b)
        {
            if (a is RectangleShape && b is RectangleShape)
            {
                return intersectRectangles((RectangleShape)a, (RectangleShape)b);
            }

            if (a is Circle && b is RectangleShape)
            {
                return -intersectCircleRectangle(a, b);
            }

            if (a is RectangleShape && b is Circle)
            {
                return intersectCircleRectangle(a, b);
            }

            if (a is Circle && b is Circle)
            {
                return intersectCircles((Circle)a, (Circle)b);
            }

            return Vector2.Zero;
        }

        public static Vector2 intersectRectangles(RectangleShape a, RectangleShape b)
        {
            throw new NotImplementedException();
        }

        public static Vector2 intersectCircleRectangle(IShape a, IShape b)
        {
            throw new NotImplementedException();
        }

        public static Vector2 intersectCircles(Circle a, Circle b)
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
