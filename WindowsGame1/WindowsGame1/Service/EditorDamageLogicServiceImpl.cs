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
        Random rand = new Random();

        private readonly int objectWidth = 10;
        private readonly int distance = 50;
        private float chanceToHit = 0.5f;

        public void setChancetoHit(float chance)
        {
            chanceToHit = chance;
        }

        public float getChanceToHit()
        {
            return chanceToHit;
        }

        public Damage damageDealt(Configuration.Character.ICharacterStats attacker, Configuration.Weapon.IWeaponStats weapon, Configuration.Character.ICharacterStats victim)
        {

            //** DAMAGE CALCULATION **//

            // damagePoints = weaponPower * modifiers - defence

            int damagePoints;
            float modifiers;
            int defence;

            // modifiers = critModifier * evasionModifier * luckModifier

            float critModifier = 1;
            float evasionModifier = 1;
            float luckModifier = 1;

            // Generate random number between 0 and 1. If number is within Luck
            // apply critical modifier to damage.

            if (rand.NextDouble() <= attacker.getLuck())
            {
                critModifier = weapon.getCrit();
            }

            modifiers = critModifier * evasionModifier * luckModifier;

            // defence = defence + armour

            defence = victim.getDefense() + victim.getArmour();

            damagePoints = (int)(weapon.getPower() * modifiers - defence);

            //** STATUS **//

            // If the random number is within the victims Evasion %, the victim
            // will dodge.
            if (rand.NextDouble() <= victim.getEvasion())
            {
                return new Damage(Status.MISS, damagePoints);
            }
            
            // If the distance between the attacker and victim exceeds the
            // the weapon range, reduce the chanceToHit.

            if (weapon.getRange() < distance)
            {
                chanceToHit *= (weapon.getRange() / distance);
            }

            // Determine whether the shot is a hit or miss.

            if (rand.NextDouble() > chanceToHit)
            {
                return new Damage(Status.MISS, damagePoints);
            }

            return new Damage(Status.HIT, damagePoints);

        }

        public float calculateConeAngle(Configuration.Character.ICharacterStats attacker, Configuration.Character.ICharacterStats victim)
        {
            // Angle = ( width of object / ( hitRatio * distance )) * ( 180/pi )

            float angle = (objectWidth / (chanceToHit * distance)) * (180 / (float)Math.PI);
            return angle;
        }
    }
}
