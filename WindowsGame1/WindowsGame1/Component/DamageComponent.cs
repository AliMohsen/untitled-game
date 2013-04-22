using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class DamageComponent : BaseComponent
    {
        List<int> damage = new List<int>();

        public List<int> getDamage()
        {
            return damage;
        }

        public void addDamage(int damage)
        {
            this.damage.Add(damage);
        }

        public void clear()
        {
            damage.Clear();
        }
    }
}
