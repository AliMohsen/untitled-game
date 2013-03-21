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
        protected GameStateManager gameStateManager;
        protected List<IGameService> gameServices = new List<IGameService>();

        public AbstractGameState(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        public abstract bool isPropagateUpdate();
        public abstract bool isPropagateDraw();

        public void changeState(AbstractGameState gameState)
        {
            gameStateManager.swapState(this, gameState);
        }

        public void addStateOnTop(AbstractGameState gameState)
        {
            gameStateManager.pushState(gameState);
        }

        public void removeState()
        {
            gameStateManager.removeState(this);
        }

        public void addStateOnTopOfThis(AbstractGameState gameState)
        {
            gameStateManager.addOnTop(this, gameState);
        }

        public virtual void update(GameTime gameTime)
        {
            foreach (IGameService service in gameServices)
            {
                service.update(gameTime, this);
            }
        }
    }
}
