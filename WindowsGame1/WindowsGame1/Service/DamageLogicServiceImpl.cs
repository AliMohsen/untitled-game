using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Service
{
    class DamageLogicServiceImpl : IDamageLogicService
    {
        /// <summary>
        /// Default logic to damage enemy.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="weapon"></param>
        /// <param name="victim"></param>
        /// <returns></returns>
        public Damage damageDealt(Configuration.Character.ICharacterStats attacker, Configuration.Weapon.IWeaponStats weapon, Configuration.Character.ICharacterStats victim)
        {
            //Damage logic belongs here.
            return new Damage(Status.HIT, 5);
        }
    }
}
