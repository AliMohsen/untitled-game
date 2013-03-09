using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Configuration.Character;
using TheGameOfForever.Configuration.Weapon;

namespace TheGameOfForever.Service
{
    public interface IDamageLogicService
    {
        Damage damageDealt(ICharacterStats attacker, IWeaponStats weapon, ICharacterStats victim);
    }

    public struct Damage
    {
        public readonly Status status;
        public readonly int damagePoints;

        public Damage(Status status, int damagePoints)
        {
            this.status = status;
            this.damagePoints = damagePoints;
        }
    }

    public enum Status
    {
        MISS,
        HIT
    }
}
