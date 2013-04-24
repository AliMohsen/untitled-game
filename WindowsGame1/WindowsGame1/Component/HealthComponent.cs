using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class HealthComponent : BaseComponent
    {
        private readonly int startHealth;
        private int health = 0;

        public HealthComponent(int health)
        {
            startHealth = health;
            this.health = startHealth;
        }

        public int getHealth()
        {
            return health;
        }

        public void setHealth(int health)
        {
            this.health = health;
        }

        public void addHealth(int health)
        {
            this.health += health;
        }
    }
}
