using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Configuration.Character;
using TheGameOfForever.Configuration.Weapon;
using TheGameOfForever.Service;

namespace TheGameOfForever.Component.Character
{
    class BasicCharacter : BaseComponent
    {
        // Stats
        ICharacterStats characterStats;
        IWeaponStats weaponStats;

        // Service
        IDamageLogicService damageLogicService;

        private int health;

        public BasicCharacter(ICharacterStats characterStats, IDamageLogicService damageLogicService)
        {
            this.characterStats = characterStats;
            this.damageLogicService = damageLogicService;
            health = characterStats.getHealth();
        }

        public ICharacterStats getStats()
        {
            return characterStats;
        }

        public void attack(BasicCharacter enemy)
        {
            enemy.receiveFire(damageLogicService.damageDealt(characterStats, weaponStats, enemy.getStats()));
        }

        public void receiveFire(Damage damage)
        {
            if (damage.status == Status.HIT)
            {
                health -= damage.damagePoints;
            }
        }

    }
}
