using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component.Weapons
{
    public class WeaponLibrary
    {
        static Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>();

        public static void initWeaponLibrary()
        {
            weapons.Add(0, new Weapon("pistol", (float)Math.PI / 48, 3, 30, 100, 5, 0.1f));
        }

        public static int getWeaponIdFromName(String name)
        {
            foreach (KeyValuePair<int, Weapon> weaponEntry in weapons)
            {
                if (weaponEntry.Value.getName().Equals(name))
                {
                    return weaponEntry.Key;
                }
            }
            throw new Exception("Could not find weapon with name : [" + name + "].");
        }

        public static Weapon getWeaponFromId(int id)
        {
            return weapons[id];
        }
    }
}
