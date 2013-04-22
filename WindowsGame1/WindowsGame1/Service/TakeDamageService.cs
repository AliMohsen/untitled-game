using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service
{
    public class TakeDamageService : AbstractGameService
    {
        public TakeDamageService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(DamageComponent), typeof(HealthComponent));
        }

        public override void update(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState gameState)
        {
            foreach (int id in entityIds[0])
            {
                Entity entity = entityManager.getEntity(id);
                DamageComponent damageComponent = entity.getComponent<DamageComponent>();
                HealthComponent healthComponent = entity.getComponent<HealthComponent>();
                int sumDamage = 0;
                foreach (int damage in damageComponent.getDamage())
                {
                    sumDamage += damage;
                    healthComponent.setHealth(healthComponent.getHealth() - damage);
                }
                if (entity.hasComponent<StatusDrawComponent>())
                {
                    entity.getComponent<StatusDrawComponent>().addEntry(sumDamage.ToString(), Color.Red, 1500);
                }
            }
        }
    }
}
