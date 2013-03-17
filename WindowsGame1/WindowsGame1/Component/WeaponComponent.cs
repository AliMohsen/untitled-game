using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    class WeaponComponent : BaseComponent
    {
        List<Entity> weapons = new List<Entity>();
        private Entity currentlySelected;

        public void addWeapon(Entity weapon)
        {
            weapons.Add(weapon);
            if (currentlySelected == null)
            {
                currentlySelected = weapon;
            }
        }

        public Entity getCurrentWeapon()
        {
            return currentlySelected;
        }

        public List<Entity> getWeapons()
        {
            return weapons;
        }

        public void setCurrentWeapon(Entity weapon)
        {
            currentlySelected = weapon;
        }
    }
}
