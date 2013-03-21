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
        protected List<Type> interestingComponentTypes = new List<Type>();
        protected HashSet<int> entityIds = new HashSet<int>();
        protected EntityManager entityManager;

        public AbstractGameService(EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        public void registerEntityIfNeeded(Entity entity)
        {
            foreach (Type type in interestingComponentTypes) 
            {
                if (entity.GetType().IsAssignableFrom(type))
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
