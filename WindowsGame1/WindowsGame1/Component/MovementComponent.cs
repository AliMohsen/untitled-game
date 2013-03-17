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

        public MovementComponent(float baseMovementSpeed)
        {
            this.baseMovementSpeed = baseMovementSpeed;
        }

        public float getBaseMovementSpeed()
        {
            return baseMovementSpeed;
        }
    }
}
