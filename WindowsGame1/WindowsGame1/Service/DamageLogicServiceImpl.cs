using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Configuration.Character;
using TheGameOfForever.Configuration.Weapon;

namespace TheGameOfForever.Service
{
    public class DamageLogicServiceImpl : AbstractGameService, IDamageLogicService
    {
        /// <summary>
        /// Default logic to damage enemy.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="weapon"></param>
        /// <param name="victim"></param>
        /// <returns></returns>
        public Damage damageDealt(ICharacterStats attacker, IWeaponStats weapon, ICharacterStats victim)
        {
            //Damage logic belongs here.
            return new Damage(Status.HIT, 5);
        }

        public override void update(GameTime gameTime)
        {
        }
    }
}
