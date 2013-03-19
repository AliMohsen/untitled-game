using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Service;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.GameState
{
    public class GameStateManager
    {
        List<IGameService> gameServices = new List<IGameService>();
        LinkedList<AbstractGameState> gameStates = new LinkedList<AbstractGameState>();
        private EntityManager entityManager = new EntityManager();
        private IEntityLoader entityLoader;

        public GameStateManager(IEntityLoader entityLoader)
        {
            this.entityLoader = entityLoader;
        }

        public void pushState(AbstractGameState state)
        {
            gameStates.AddFirst(state);
        }

        public void popState()
        {
            if (gameStates.Count != 0)
            {
                gameStates.RemoveFirst();
            }
        }

        public T getService<T>() where T : IGameService
        {
            foreach (IGameService service in gameServices)
            {
                if (service is T)
                {
                    return (T) service;
                }
            }
            return default(T);
        }

        public void swapState(AbstractGameState oldState, AbstractGameState newState)
        {
            LinkedListNode<AbstractGameState> stateNode = gameStates.Find(oldState);
            if (stateNode != null)
            {
                stateNode.Value = newState;
            }
        }

        public void removeState(AbstractGameState state)
        {
            gameStates.Remove(state);
        }

        public void addOnTop(AbstractGameState oldState, AbstractGameState newState)
        {
            gameStates.AddBefore(gameStates.Find(oldState), newState);
        }

        private void initializeServices()
        {
        }

        public void initializeEntities()
        {
            // Load all starting entities.
            entityManager.addEntity(EntityFactory.createHumanEntity(100, new Vector2(100, 100), 0));
            entityManager.addEntity(EntityFactory.createHumanEntity(100, new Vector2(200, 100), 1));
        }

        public void update(GameTime gameTime)
        {
            
        }
    }
}
