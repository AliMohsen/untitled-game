using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame4
{
    public static class helper
    {

        public static float Clerp(float from, float to, float step)
        {
            float t = ((MathHelper.WrapAngle(to - from) * (step)));
            return from + t;
        }


        public static Vector2[] rectangleRotate(Rectangle rec, Vector2 origin, float rotation)
        {
            Vector2[] res = new Vector2[4];
            res[0] = new Vector2(rec.X, rec.Y);
            res[1] = new Vector2(rec.X + rec.Width, rec.Y);
            res[2] = new Vector2(rec.X + rec.Width, rec.Y + rec.Height);
            res[3] = new Vector2(rec.X, rec.Y + rec.Height);

            for (int i = 0; i < 4; i++)
            {
                res[i] = rotatePoint(res[i], origin, rotation);
            }

            return res;

        }

        public static Vector2 rotatePoint2(Vector2 toRotate, Vector2 Origin, float rotation)
        {
            Vector2 r;
            r.X = (float)(Origin.X + (Math.Cos(rotation) * (toRotate.X - Origin.X) -
                    Math.Sin(rotation) * (toRotate.Y - Origin.Y)));
            r.Y = (float)(Origin.Y + (Math.Sin(rotation) * (toRotate.X - Origin.X) +
                    Math.Cos(rotation) * (toRotate.Y - Origin.Y)));
            return r;
        }



        public static Vector2 rotatePoint(Vector2 toRotate, Vector2 Origin, float rotation)
        {
            //Normalise to origin
            Vector2 back = toRotate - Origin;
            Vector2 temp = new Vector2();
            temp.X = (float)(back.X * Math.Cos(-rotation) - back.Y * Math.Sin(-rotation));
            temp.Y = (float)(back.X * Math.Sin(rotation) + back.Y * Math.Cos(-rotation));
            return (temp + Origin);
        }
        public static float rotationAround(Vector2 origin, Vector2 point)
        {
            float feta = (float)Math.Atan(-(origin.X - point.X) / (origin.Y - point.Y));
            if (origin.Y < point.Y)
            {
                feta += MathHelper.ToRadians(180);
            }
            return feta;
        }

    }
}
