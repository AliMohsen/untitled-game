using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class RetaliateComponent : BaseComponent
    {
        private int damageTaken = 0;

        public void addDamage(int damage)
        {
            this.damageTaken += damage;
        }

        public int getDamage()
        {
            return damageTaken;
        }
    }
}
