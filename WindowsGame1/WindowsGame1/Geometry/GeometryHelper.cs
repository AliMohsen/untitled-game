using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Geometry
{
    public class GeometryHelper
    {
        public static Random rand = new Random();

        static public Vector2 randomVector2(float x, float x1, float y, float y1)
        {
            float xr = Math.Min(x, x1) + ((float)rand.NextDouble() * Math.Abs(x - x1));
            float yr = Math.Min(y, y1) + ((float)rand.NextDouble() * Math.Abs(y - y1));

            return new Vector2(xr, yr);
        }

        static public float getRandomFloat(float min, float max)
        {
            float min2 = Math.Min(min, max);
            float abs = Math.Abs(min - max);
            float db = (float)rand.NextDouble();
            float added = db * abs;
            return (Math.Min(min, max) + (float)rand.NextDouble() * Math.Abs(min - max));
        }

        public static Vector2 rotateVec(Vector2 vec, float angle)
        {
            vec = Vector2.Transform(vec, Matrix.CreateRotationZ(angle));
            return vec;
        }

        public static float CalculateAngle(Vector2 origin, Vector2 point)
        {
            // center system around point
            float x = origin.X - point.X;
            float y = origin.Y - point.Y;

            // calculate and return angle
            float angle = (float)Math.Atan2(-x, y);
            return angle;
        }

        public static float angleAroundOrigin(Vector2 vec)
        {
            float angle;
            if (vec.Y > 0) angle = (float)Math.Atan2(vec.Y, vec.X);
            else angle = (float)(Math.PI + (Math.PI + (float)Math.Atan2(vec.Y, vec.X)));
            return angle;
        }
    }
}
