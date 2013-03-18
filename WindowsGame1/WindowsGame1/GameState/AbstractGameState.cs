﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.GameState
{
    public abstract class AbstractGameState
    {
        private GameStateManager gameStateManager;

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
    }
}
