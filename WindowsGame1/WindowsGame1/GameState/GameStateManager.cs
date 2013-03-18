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
        EntityManager entityManager = new EntityManager();
        List<IGameService> gameServices = new List<IGameService>();
        LinkedList<AbstractGameState> gameStates = new LinkedList<AbstractGameState>();

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
