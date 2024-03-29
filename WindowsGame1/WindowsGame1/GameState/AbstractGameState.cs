﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Service;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.View.Camera;

namespace TheGameOfForever.GameState
{
    public abstract class AbstractGameState
    {
        protected GameStateManager gameStateManager;
        private List<IGameService> gameServices = new List<IGameService>();
        private ICamera2D camera;
        public AbstractGameState(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
            camera = GameStateManager.getCamera();
        }

        public abstract bool isPropagateUpdate();
        public abstract bool isPropagateDraw();

        public ICamera2D getCamera()
        {
            return camera;
        }

        protected void addAndRefreshService(IGameService service)
        {
            gameServices.Add(service);
        }

        protected void addService(IGameService service)
        {
            gameServices.Add(service);
        }

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
                service.update(gameTime, this);
                service.refreshEntities();
            }
        }

        public virtual void draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (AbstractGameService gameService in gameServices)
            {
                gameService.draw(gameTime, this, spriteBatch);
            }
        }

        public virtual void draw3d(GameTime gameTime, GraphicsDevice device)
        {
            foreach (AbstractGameService gameService in gameServices)
            {
                gameService.draw3d(gameTime, this, device);
            }
        }
    }
}
