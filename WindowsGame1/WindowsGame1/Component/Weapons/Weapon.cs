using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component.Weapons
{
    public class Weapon
    {
        private String name;
        private float accuracy;
        private int shotsPerTurn;
        private int power;
        private int range;
        private int weight;
        private float critical;

        public Weapon(String name, float accuracy, int shotsPerTurn, int power,
            int range, int weight, float critical)
        {
            this.name = name;
            this.accuracy = accuracy;
            this.shotsPerTurn = shotsPerTurn;
            this.power = power;
            this.range = range;
            this.weight = weight;
            this.critical = critical;
        }

        public String getName()
        {
            return name;
        }

        public float getAccuracy()
        {
            return accuracy;
        }

        public int getShotsPerTurn()
        {
            return shotsPerTurn;
        }

        public int getPower()
        {
            return power;
        }

        public int getRange()
        {
            return range;
        }

        public int getWeight()
        {
            return weight;
        }

        public float getCritical()
        {
            return critical;
        }
    }
}
