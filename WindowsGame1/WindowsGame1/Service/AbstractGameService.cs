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
        protected List<InterestingEntityCollection> entityIds = new List<InterestingEntityCollection>();
        protected EntityManager entityManager;

        public AbstractGameService(EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        protected void subscribeToComponentGroup(params Type[] types)
        {
            interestingComponentTypes.Add(new List<Type>(types));
            entityIds.Add(new InterestingEntityCollection());
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
                    entityIds[i].add(entity.getId());
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
                    entityIds[i].remove(entity.getId());
                }
            }  
        }

        public void removeEntity(Entity entity)
        {
            for (int i = 0; i < interestingComponentTypes.Count; i++)
            {
                entityIds[i].remove(entity.getId());
            }
        }

        public abstract void update(GameTime gameTime, AbstractGameState gameState);

        public virtual void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {

        }

        public virtual void refresh()
        {
            throw new NotImplementedException();
        }

        public class InterestingEntityCollection : IEnumerable<int>
        {
            HashSet<int> entityIds = new HashSet<int>();
            int last = -1;

            public bool add(int id)
            {
                last = id;
                return entityIds.Add(id);
            }

            public bool contains(int id)
            {
                return entityIds.Contains(id);
            }

            public bool remove(int id)
            {
                return entityIds.Remove(id);
            }

            /// <summary>
            /// Gets last added, does not guarantee that this id still exists in the collection.
            /// </summary>
            public int getLast()
            {
                return last;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return entityIds.GetEnumerator();
            }

            IEnumerator<int> IEnumerable<int>.GetEnumerator()
            {
                return entityIds.GetEnumerator();
            }

            internal int count()
            {
                return entityIds.Count;
            }
        }


        public void refreshEntities()
        {
            entityManager.refreshAfterService();
        }

        public virtual void draw3d(GameTime gameTime, AbstractGameState state, GraphicsDevice device)
        {
        }
    }
}
