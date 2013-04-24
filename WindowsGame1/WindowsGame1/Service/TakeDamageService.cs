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

        List<int> entitiesToRemove = new List<int>();
        public override void update(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState gameState)
        {
            entitiesToRemove.Clear();
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
                damageComponent.clear();
                if (healthComponent.getHealth() < 0)
                {
                    entitiesToRemove.Add(id);
                }
                if (sumDamage > 0 && entity.hasComponent<StatusDrawComponent>())
                {
                    entity.getComponent<StatusDrawComponent>().addEntry(sumDamage.ToString(), Color.Red, 600);
                }
            }
            foreach (int id in entitiesToRemove)
            {
                entityManager.removeEntity(id);
            }
        }
    }
}
