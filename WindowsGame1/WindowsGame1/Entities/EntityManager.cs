using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities.Exception;
using TheGameOfForever.Service;

namespace TheGameOfForever.Entities
{
    public class EntityManager
    {
        // To be used as an array for fast lookup.
        Dictionary<int, Entity> entities = new Dictionary<int, Entity>();
        private List<IGameService> services = new List<IGameService>();

        public void registerEntityService(IGameService gameService)
        {
            services.Add(gameService);
        }

        public Entity getEntity(int id)
        {
            return entities[id];
        }

        public void addEntity(Entity entity)
        {
            if (entity.getId() > 0) 
            {
                throw new InvalidEntityException("Invalid ID for entity.");
            }
            entities.Add(entity.getId(), entity);
            foreach (IGameService service in services)
            {
                service.registerEntityIfNeeded(entity);
            }
        }
    }
}
