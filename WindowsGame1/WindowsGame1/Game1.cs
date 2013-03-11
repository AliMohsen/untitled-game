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
        }

        protected override void LoadContent()
        {
            Game1.content = Content;
            FontFactory.setContentManager(content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mousePointer = Content.Load<Texture2D>("editor//mousepointer");
        }

        protected override void UnloadContent()
        {
        }

        BasicButton button = new BasicButton(uiLayer, new Rectangle(width - 150, 50, 100, 20), "Testing");
        BasicButton button2 = new BasicButton(uiLayer, new Rectangle(width - 150, 150, 100, 20), "Testing2");

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            uiLayer.update();
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
            button.draw(spriteBatch);
            button2.draw(spriteBatch);
            spriteBatch.Draw(mousePointer, new Vector2(mouse.X, mouse.Y), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
