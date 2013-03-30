using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TheGameOfForever.Ui.Editor;
using TheGameOfForever.Ui.Font;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TheGameOfForever.Ui.Layer;
using TheGameOfForever.Ui.Editor.Input;
using System.IO;
using TheGameOfForever.GameState;
using TheGameOfForever.Entities;
using TheGameOfForever.Component.Map;
using TheGameOfForever.Processor.Content.Models;

namespace TheGameOfForever
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager content;

        private static UiService uiLayer = new UiService();

        private Texture2D mousePointer;

        private static int width = 1280;
        private static int height = 800;

        UiLayerManager layerManager = new UiLayerManager();
        MouseService mouseService = new MouseService();
        UiService uiService = new UiService();

        /// <summary>
        /// Load up the entities
        /// </summary>
        GameStateManager stateManager;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IntPtr hWnd = this.Window.Handle;
            var control = System.Windows.Forms.Control.FromHandle(hWnd);
            var form = control.FindForm();
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        private void Form1_MouseDown(object sender,
        System.Windows.Forms.MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                IntPtr hWnd = this.Window.Handle;
                SendMessage(hWnd, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }*/
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();
            base.Initialize();
            stateManager.createRenderTarget(GraphicsDevice, (int)Map.getWorldWidth(), (int)Map.getWorldHeight());
        }

        protected override void LoadContent()
        {
            Game1.content = Content;
            FontFactory.setContentManager(content);
            ModelLibrary.initModelLibrary(content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mousePointer = Content.Load<Texture2D>("editor//mousepointer");
            stateManager = new GameStateManager(new EntityLoader(new EntityManager(),
            (EntityManager entityManager) =>
            {
                entityManager.addEntity(Entity.EntityFactory.createHumanEntity(100, new Vector2(10, 10), 0, true));
                entityManager.addEntity(Entity.EntityFactory.createHumanEntity(100, new Vector2(10, 40), 0, true));
                entityManager.addEntity(Entity.EntityFactory.createHumanEntity(100, new Vector2(300, 100), 1, true));
                entityManager.addEntity(Entity.EntityFactory.createHumanEntity(100, new Vector2(300, 140), 1, true));
            }));
            layerManager.addLayerOnTop(new SaveLoadLayer(uiService));
            stateManager.pushState(new UnitSelectState(0, stateManager));
            OutputConsole.writeLn("Loading");
        }

        protected override void UnloadContent()
        {
        }

        BasicButton button = new BasicButton(uiLayer, new Rectangle(width - 150, 50, 100, 24), "Testing");
        BasicButton button2 = new BasicButton(uiLayer, new Rectangle(width - 150, 150, 100, 24), "Testing2");

        protected override void Update(GameTime gameTime)
        {
            mouseService.updateCurrent();
            layerManager.update(gameTime);
            uiLayer.update();
            uiService.update();
            stateManager.update(gameTime);
            mouseService.updateLast();
        }

        private Vector2 screenOffset = new Vector2(10, 30);

        protected override void Draw(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            stateManager.draw(gameTime, spriteBatch);
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.Draw(EditorContent.blank, new Rectangle(0, 0, 1, GraphicsDevice.Viewport.Height), Color.DarkGray);
            spriteBatch.Draw(EditorContent.blank, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, 1), Color.DarkGray);
            spriteBatch.Draw(EditorContent.blank, new Rectangle(0, GraphicsDevice.Viewport.Height - 1, GraphicsDevice.Viewport.Width, 1), Color.DarkGray);
            spriteBatch.Draw(EditorContent.blank, new Rectangle(GraphicsDevice.Viewport.Width - 1, 0, 1, GraphicsDevice.Viewport.Height), Color.DarkGray);
            spriteBatch.End();

            spriteBatch.Begin();
            layerManager.draw(spriteBatch);

            DrawStringHelper.drawString(spriteBatch, "BestGameEver - v0.01", "mentone", 10, Color.Black, new Vector2(10, 5));
            spriteBatch.Draw(stateManager.getGameScreen(), new Rectangle((int)screenOffset.X, (int)screenOffset.Y,
                (int)Map.getWorldWidth(), (int)Map.getWorldHeight()), Color.White);
            spriteBatch.Draw(mousePointer, new Vector2(mouse.X, mouse.Y), Color.White);
            OutputConsole.draw(spriteBatch, 4, new Vector2(10,660), 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
