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
    public class collisionShape
    {
        public Rectangle r;
        public Vector2 rotatePoint;
        public float rotation = 0;
        public int Flag = 0;

        public float radius;
        public Vector2 location;
        public int mass;

        public collisionShape(Rectangle r, Vector2 rotatePoint, float rotation, int mass)
        {
            this.r = r;
            this.rotatePoint = rotatePoint;
            this.rotation = rotation;
            Flag = 0;
            this.mass = mass;
        }

        public collisionShape(Vector2 location, float radius, int mass)
        {
            this.location = location;
            this.radius = radius;
            Flag = 1;
            this.mass = mass;
        }


    }
}
