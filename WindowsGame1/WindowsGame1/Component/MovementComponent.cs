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
        private float turningSpeed = 0.1f;

        public MovementComponent(float baseMovementSpeed, Vector2 velocity)
        {
            this.baseMovementSpeed = baseMovementSpeed;
            this.velocity = velocity;
        }

        public float getBaseMovementSpeed()
        {
            return baseMovementSpeed;
        }

        public Vector2 getVelocity()
        {
            return velocity;
        }

        public void setVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public float getTurningSpeed()
        {
            return turningSpeed;
        }
    }
}
