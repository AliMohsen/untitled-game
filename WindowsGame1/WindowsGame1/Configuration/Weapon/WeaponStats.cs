﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Configuration.Weapon
{
    public class WeaponStats : IWeaponStats
    {
        private String name;
        private float accuracy;
        private int shotsPerTurn;
        private int power;
        private float range;
        private int weight;
        private float critical;
        private long timeBetweenShots;

        public WeaponStats(String name, float accuracy, int shotsPerTurn, int power,
            int range, int weight, float critical, long timeBetweenShots)
        {
            this.name = name;
            this.accuracy = accuracy;
            this.shotsPerTurn = shotsPerTurn;
            this.power = power;
            this.range = range;
            this.weight = weight;
            this.critical = critical;
            this.timeBetweenShots = timeBetweenShots;
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

        public float getRange()
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

        public long getTimeBetweenShots()
        {
            return timeBetweenShots;
        }
    }
}
