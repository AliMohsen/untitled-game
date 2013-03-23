using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;

namespace TheGameOfForever.Service
{
    public abstract class AbstractGameService : IGameService
    {
        private List<List<Type>> interestingComponentTypes = new List<List<Type>>();
        protected HashSet<int> entityIds = new HashSet<int>();
        protected EntityManager entityManager;

        public AbstractGameService(EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        protected void subscribeToComponentGroup(params Type[] types)
        {
            interestingComponentTypes.Add(new List<Type>(types));
        }

        public void registerEntityIfNeeded(Entity entity)
        {
            foreach (List<Type> types in interestingComponentTypes) 
            {
                Boolean add = true;
                foreach (Type type in types)
                {
                    add &= entity.hasComponent(type);
                    if (!add)
                    {
                        continue;
                    }
                }
                if (add)
                {
                    entityIds.Add(entity.getId());
                }
            }
        }

        public void unregisterEntity(Entity entity)
        {
            entityIds.Remove(entity.getId());       
        }

        public abstract void update(GameTime gameTime, AbstractGameState gameState);
    }
}
