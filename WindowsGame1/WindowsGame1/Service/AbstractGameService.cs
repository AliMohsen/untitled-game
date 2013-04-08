using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.Service
{
    public abstract class AbstractGameService : IGameService
    {
        private List<List<Type>> interestingComponentTypes = new List<List<Type>>();
        protected List<HashSet<int>> entityIds = new List<HashSet<int>>();
        protected EntityManager entityManager;

        public AbstractGameService(EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        protected void subscribeToComponentGroup(params Type[] types)
        {
            interestingComponentTypes.Add(new List<Type>(types));
            entityIds.Add(new HashSet<int>());
        }

        public void registerEntityIfNeeded(Entity entity)
        {
            for (int i = 0; i < interestingComponentTypes.Count; i++)
            {
                Boolean add = true;
                foreach (Type type in interestingComponentTypes[i])
                {
                    add &= entity.hasComponent(type);
                    if (!add)
                    {
                        continue;
                    }
                }
                if (add)
                {
                    entityIds[i].Add(entity.getId());
                }
            }
        }

        public void refreshEntity(Entity entity)
        {
            for (int i = 0; i < interestingComponentTypes.Count; i++)
            {
                Boolean add = true;
                foreach (Type type in interestingComponentTypes[i])
                {
                    add &= entity.hasComponent(type);
                    if (!add)
                    {
                        continue;
                    }
                }
                if (!add)
                {
                    entityIds[i].Remove(entity.getId());
                }
            }  
        }

        public void removeEntity(Entity entity)
        {
            for (int i = 0; i < interestingComponentTypes.Count; i++)
            {
                entityIds[i].Remove(entity.getId());
            }
        }

        public abstract void update(GameTime gameTime, AbstractGameState gameState);

        public virtual void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {

        }
    }
}
