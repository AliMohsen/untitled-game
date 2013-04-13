using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Configuration.Weapon
{
    public class WeaponLibrary
    {
        static Dictionary<int, WeaponStats> weapons = new Dictionary<int, WeaponStats>();

        public static void initWeaponLibrary()
        {
            weapons.Add(0, new WeaponStats("pistol", (float)Math.PI / 48, 3, 30, 100, 5, 0.1f, 1000));
            weapons.Add(1, new WeaponStats("ak47", (float)Math.PI / 12, 20, 100, 80, 10, 0.1f, 100));
        }

        public static int getWeaponIdFromName(String name)
        {
            foreach (KeyValuePair<int, WeaponStats> weaponEntry in weapons)
            {
                if (weaponEntry.Value.getName().Equals(name))
                {
                    return weaponEntry.Key;
                }
            }
            throw new Exception("Could not find weapon with name : [" + name + "].");
        }

        public static WeaponStats getWeaponFromId(int id)
        {
            return weapons[id];
        }
    }
}
