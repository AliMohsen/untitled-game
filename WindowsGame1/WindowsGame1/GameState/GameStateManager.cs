using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Service;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.GameState
{
    public class GameStateManager
    {
        List<IGameService> gameServices = new List<IGameService>();
        LinkedList<AbstractGameState> gameStates = new LinkedList<AbstractGameState>();
        private EntityManager entityManager = new EntityManager();
        private EntityLoader entityLoader;

        public GameStateManager(EntityLoader entityLoader)
        {
            this.entityLoader = entityLoader;
            initializeEntities();
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
            T newService = (T) Activator.CreateInstance(typeof(T), entityManager);
            entityManager.registerService(newService);
            gameServices.Add(newService);
            return newService;
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

            entityLoader.loadEntities(entityManager);
        }

        public void update(GameTime gameTime)
        {
            foreach (AbstractGameState gameState in gameStates)
            {
                gameState.update(gameTime);
                if (!gameState.isPropagateUpdate())
                {
                    return;
                }
            }
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
    }
}
