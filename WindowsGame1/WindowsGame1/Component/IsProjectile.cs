using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class IsProjectile : BaseComponent
    {
        private int damage;
        private bool canCollide;
        private float maxRange = 0;
        private float travelled = 0;
        public IsProjectile(int damage, bool canCollide, float maxRange)
        {
            this.canCollide = canCollide;
            this.damage = damage;
            this.maxRange = maxRange;
        }

        public int getDamage()
        {
            return damage;
        }

        public bool isCanCollide()
        {
            return canCollide;
        }

        public float getMaxRange()
        {
            return maxRange;
        }

        public float getTravelled()
        {
            return travelled;
        }

        public void addToTravelled(float distance)
        {
            travelled += distance;
        }
    }
}
