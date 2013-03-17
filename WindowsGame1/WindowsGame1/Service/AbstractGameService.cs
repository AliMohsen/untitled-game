using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;

namespace TheGameOfForever.Service
{
    public class AbstractGameService : IGameService
    {
        protected List<Type> interestingComponentTypes = new List<Type>();
        protected HashSet<int> entityIds = new HashSet<int>();

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
    }
}
