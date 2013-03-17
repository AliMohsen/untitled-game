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
        public static List<String> consoleOutput = new List<string>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IntPtr hWnd = this.Window.Handle;
            var control = System.Windows.Forms.Control.FromHandle(hWnd);
            var form = control.FindForm();
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.MouseDown += new MouseEventHandler(Form1_MouseDown);
            layerManager.addLayerOnTop(new BattleLayer());
            layerManager.addLayerOnTop(new SaveLoadLayer(uiService));
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
            consoleOutput.Add("Initialising");
        }

        protected override void LoadContent()
        {
            Game1.content = Content;
            FontFactory.setContentManager(content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mousePointer = Content.Load<Texture2D>("editor//mousepointer");
            consoleOutput.Add("Loading");
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
            mouseService.updateLast();
        }

        protected override void Draw(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
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
            spriteBatch.Draw(mousePointer, new Vector2(mouse.X, mouse.Y), Color.White);
            for (int i = (int) MathHelper.Max(0, consoleOutput.Count - 4); i < consoleOutput.Count; i++)
            {
                DrawStringHelper.drawString(spriteBatch, consoleOutput[i], "mentone", 10, 
                    Color.Black, new Vector2(10, 660 + (i - (int) MathHelper.Max(0, consoleOutput.Count - 4)) * 12 ));
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
