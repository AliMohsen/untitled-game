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
        public Damage damageDealt(Configuration.Character.ICharacterStats attacker, Configuration.Weapon.IWeaponStats weapon, Configuration.Character.ICharacterStats victim)
        {
            // damage = weaponPower * modifiers - defence

            int damage;
            int modifiers;
            int defence;

            // modifiers = critModifier * evasionModifier * luckModifier

            int critModifier;
            int evasionModifier;
            int luckModifier;

            // defence = defence + armour

            defence = victim.getDefense() + victim.getArmour();

            throw new NotImplementedException();
        }
    }
}
