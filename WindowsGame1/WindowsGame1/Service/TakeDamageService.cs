using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;

namespace TheGameOfForever.Service
{
    public class TakeDamageService : AbstractGameService
    {
        public interface Observer
        {
            void handleUnitDeath();
        }

        public TakeDamageService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(DamageComponent), typeof(HealthComponent));
        }
       
        List<int> entitiesToRemove = new List<int>();
        public override void update(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState gameState)
        {
            bool enterKillCamState = false;
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
                    entity.addComponent(new DeadComponent(-healthComponent.getHealth()));
                    enterKillCamState = true;
                }
                if (sumDamage > 0 && entity.hasComponent<StatusDrawComponent>())
                {
                    entity.getComponent<StatusDrawComponent>().addEntry(sumDamage.ToString(), Color.Red, 600);
                }
            }
            if (enterKillCamState)
            {
                ((Observer)gameState).handleUnitDeath();
            }
        }
    }
}
