using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Service
{
    /// <summary>
    /// Editor damage logic service implementation.
    /// </summary>
    public class EditorDamageLogicServiceImpl : IDamageLogicService
    {
        Random random = new Random();
        float randomPercent = 0.5f;

        public void setPercent(float percent)
        {
            randomPercent = percent;
        }

        public float getPecent()
        {
            return randomPercent;
        }


        public Damage damageDealt(Configuration.Character.ICharacterStats attacker, Configuration.Weapon.IWeaponStats weapon, Configuration.Character.ICharacterStats victim)
        {
            throw new NotImplementedException();
        }
    }
}
