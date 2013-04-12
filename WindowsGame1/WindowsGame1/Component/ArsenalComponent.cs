using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.Configuration.Weapon;

namespace TheGameOfForever.Component
{
    public class ArsenalComponent : BaseComponent
    {
        List<int> weapons = new List<int>();
        private int currentlySelected = -1;

        public ArsenalComponent(params String[] weapons)
        {
            if (weapons != null)
            {
                foreach (String weaponName in weapons)
                {
                    this.addWeapon(weaponName);
                }
            }
        }

        public void addWeapon(String weaponName)
        {
            int weaponId = WeaponLibrary.getWeaponIdFromName(weaponName);
            weapons.Add(weaponId);
            if (currentlySelected == -1)
            {
                currentlySelected = weaponId;
            }
        }

        public int getCurrentWeaponId()
        {
            return currentlySelected;
        }

        public List<int> getWeapons()
        {
            return weapons;
        }

        public void setCurrentWeaponFromName(String weaponName)
        {
            currentlySelected = WeaponLibrary.getWeaponIdFromName(weaponName);            
        }

        public void setCurrentWeaponFromId(int weaponId)
        {
            currentlySelected = weaponId;
        }

        public void selectNextWeapon()
        {
            currentlySelected = (currentlySelected + 1) % weapons.Count;
        }

        public void selectPreviousWeapon()
        {
            if (currentlySelected == 0) currentlySelected = weapons.Count - 1;
            else currentlySelected = (currentlySelected - 1) % weapons.Count;
        }
    }
}
