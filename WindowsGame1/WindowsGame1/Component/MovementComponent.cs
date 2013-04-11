using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class MovementComponent : BaseComponent
    {
        private float baseMovementSpeed;
        private Vector2 velocity;
        private float turningSpeed = 0.001f;

        public MovementComponent(float baseMovementSpeed, Vector2 velocity)
        {
            this.baseMovementSpeed = baseMovementSpeed;
            this.velocity = velocity;
        }

        public float getBaseMovementSpeed(GameTime gameTime)
        {
            return baseMovementSpeed * gameTime.ElapsedGameTime.Milliseconds;
        }

        public Vector2 getVelocity()
        {
            return velocity;
        }

        public void setVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public float getTurningSpeed(GameTime gameTime)
        {
            return turningSpeed * gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
