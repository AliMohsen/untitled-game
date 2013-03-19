using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Service;

namespace TheGameOfForever.GameState
{
    public abstract class AbstractGameState
    {
        private GameStateManager gameStateManager;
        protected List<IGameService> gameServices = new List<IGameService>();

        public AbstractGameState(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        public abstract bool isPropagateUpdate();
        public abstract bool isPropagateDraw();

        protected void changeState(AbstractGameState gameState)
        {
            gameStateManager.swapState(this, gameState);
        }

        protected void addStateOnTop(AbstractGameState gameState)
        {
            gameStateManager.pushState(gameState);
        }

        protected void removeState()
        {
            gameStateManager.removeState(this);
        }

        protected void addStateOnTopOfThis(AbstractGameState gameState)
        {
            gameStateManager.addOnTop(this, gameState);
        }

        public virtual void update(GameTime gameTime)
        {
            foreach (IGameService service in gameServices)
            {
                service.update(gameTime);
            }
        }
    }
}
