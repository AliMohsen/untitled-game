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

        public IsProjectile(int damage, bool canCollide)
        {
            this.canCollide = canCollide;
            this.damage = damage;
        }

        public int getDamage()
        {
            return damage;
        }

        public bool isCanCollide()
        {
            return canCollide;
        }
    }
}
