using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Service;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.View.Camera;
using TheGameOfForever.Draw;

namespace TheGameOfForever.GameState
{
    public class GameStateManager
    {
        List<IGameService> gameServices = new List<IGameService>();
        LinkedList<AbstractGameState> gameStates = new LinkedList<AbstractGameState>();
        private EntityManager entityManager = new EntityManager();
        private EntityLoader entityLoader;
        static ICamera2D camera = new Basic2DCamera();

        public GameStateManager(EntityLoader entityLoader)
        {
            this.entityLoader = entityLoader;
            initializeEntities();
            camera.setWorldPosition(Vector2.Zero);
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
            camera.update();
            Control.DefaultControl.Instance.updateCurrent();
            foreach (AbstractGameState gameState in gameStates)
            {
                gameState.update(gameTime);
                if (!gameState.isPropagateUpdate())
                {
                    Control.DefaultControl.Instance.updateLast();
                    return;
                }
            }
            Control.DefaultControl.Instance.updateLast();
        }

        GraphicsDevice graphicsDevice;
        RenderTarget2D gameRenderTarget2D;
        public void createRenderTarget2D(GraphicsDevice graphicsDevice, int width, int height) {
            this.graphicsDevice = graphicsDevice;
            gameRenderTarget2D = new RenderTarget2D(graphicsDevice, width, height);

        }

        RenderTarget2D gameRenderTarget3D;
        public void createRenderTarget3D(GraphicsDevice graphicsDevice, int width, int height)
        {
            this.graphicsDevice = graphicsDevice;
            gameRenderTarget3D = new RenderTarget2D(graphicsDevice, width, height, true, graphicsDevice.DisplayMode.Format, DepthFormat.Depth24);
        }

        public Texture2D getGameScreen()
        {
            return gameRenderTarget2D;
        }

        public Texture2D getGameScreen3D()
        {
            return gameRenderTarget3D;
        }

        public void draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice device)
        {
            device.SetRenderTarget(gameRenderTarget2D);

            device.Clear(new Color(0.1f, 0.1f, 0.1f));

            bool canDraw = true;
            List<AbstractGameState> layersToDraw = new List<AbstractGameState>();

            foreach (AbstractGameState state in gameStates)
            {
                if (canDraw)
                {
                    layersToDraw.Add(state);
                    canDraw &= state.isPropagateDraw();
                }
            }
            layersToDraw.Reverse();
            foreach (AbstractGameState state in layersToDraw)
            {
                state.draw(gameTime, spriteBatch);
            }
            SpriteBatchWrapper.drawItems(spriteBatch);

            graphicsDevice.SetRenderTarget(gameRenderTarget3D);
            device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.DarkSlateBlue, 1.0f, 0);
            canDraw = true;
            layersToDraw = new List<AbstractGameState>();

            foreach (AbstractGameState state in gameStates)
            {
                if (canDraw)
                {
                    layersToDraw.Add(state);
                    canDraw &= state.isPropagateDraw();
                }
            }
            layersToDraw.Reverse();
            foreach (AbstractGameState state in layersToDraw)
            {
                state.draw3d(gameTime, device);
            }
            graphicsDevice.SetRenderTarget(null);
        }

        public static ICamera2D getCamera()
        {
            return camera;
        }
    }
}
