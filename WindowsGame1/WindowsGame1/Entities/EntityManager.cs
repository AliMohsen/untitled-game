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

        public void registerService(IGameService gameService)
        {
            services.Add(gameService);
            foreach (Entity entity in entities.Values)
            {
                gameService.registerEntityIfNeeded(entity);
            }
        }

        public Entity getEntity(int id)
        {
            return entities[id];
        }

        private List<Tuple<Action, int, Entity>> actionList =
            new List<Tuple<Action, int, Entity>>();
        private enum Action
        {
            ADD,
            REMOVE,
        }

        public void addEntity(Entity entity)
        {
            actionList.Add(
                new Tuple<Action, int, Entity>(Action.ADD, entity.getId(), entity));

        }

        public void removeEntity(int entityId)
        {
            actionList.Add(
                new Tuple<Action, int, Entity>(Action.REMOVE, entityId, null));
        }

        public void updateEntity(Entity entity)
        {
            removeEntity(entity.getId());
            addEntity(entity);
        }

        public void refreshAfterService()
        {
            foreach (Tuple<Action, int, Entity> action in actionList)
            {
                switch (action.Item1)
                {
                    case Action.ADD:
                        {
                            if (action.Item2 < 0)
                            {
                                throw new InvalidEntityException("Invalid ID for entity.");
                            }
                            action.Item3.setEntityManager(this);
                            entities.Add(action.Item2, action.Item3);
                            foreach (IGameService service in services)
                            {
                                service.registerEntityIfNeeded(action.Item3);
                            }
                        }
                        break;
                    case Action.REMOVE:
                        {
                            foreach (IGameService service in services)
                            {
                                service.removeEntity(entities[action.Item2]);
                            }
                            entities.Remove(action.Item2);
                        }
                        break;

                }

            }
            actionList.Clear();
        }

    }
}
