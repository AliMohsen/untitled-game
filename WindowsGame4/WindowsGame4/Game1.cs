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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame4
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rectangle A = new Rectangle(50,50,100,150);
        
        Rectangle B = new Rectangle(400,300,200,150);


        collisionShape a;
        collisionShape b;
        collisionShape c;
        collisionShape d;

        Texture2D nulltex;
        Texture2D circle50;
        Texture2D para;
        Texture2D testing;
        Texture2D testingblur;

        Texture2D circle50Heightmap;

        Texture2D parabg;

        float testingbc = 0.0f;
        float testingc = 0.0f;
        int testingframeCount = 0;

        Rectangle player;

        PrimitiveBatch pbatch;
        Vector2 lineA = new Vector2(150, 100);
        Vector2 lineB = new Vector2(150, 200);

        RenderTarget2D heightmap;
        RenderTarget2D colormap;

        Effect lighting;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            a = new collisionShape(A, new Vector2(A.Width / 2, A.Height / 2), 0,200);
            b = new collisionShape(B, new Vector2(B.Width / 2, B.Height / 2), 0,500);
            c = new collisionShape(new Vector2(200, 200), 10,900);
            d = new collisionShape(new Vector2(300,300),20,800);

            player = new Rectangle(100, 100, 20, 40);

            


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            nulltex = Content.Load<Texture2D>("null");
            circle50 = Content.Load<Texture2D>("circle50");
            para = Content.Load<Texture2D>("para");
            testing = Content.Load<Texture2D>("testing normal");
            testingblur = Content.Load<Texture2D>("testing blur");
            parabg = Content.Load<Texture2D>("parabg");
            // TODO: use this.Content to load your game content here
            pbatch = new PrimitiveBatch(GraphicsDevice);
            circle50Heightmap = Content.Load<Texture2D>("circle50heiht");

            lighting = Content.Load<Effect>("light");
            begin.setGraphics(GraphicsDevice);

            heightmap = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 1, GraphicsDevice.PresentationParameters.BackBufferFormat);
            colormap = new RenderTarget2D(GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 1, GraphicsDevice.PresentationParameters.BackBufferFormat);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        Vector2 l1pos;
        Vector2 l2pos;
        Vector2 l3pos;
        Vector2 l4pos;
        Vector2 l5pos;
        Vector2 l6pos;
        Vector2 l7pos;
        Vector2 l8pos;

        float l1rot = 0.5f;
        float l2rot = 0.7f;
        float l3rot = 0.2f;
        float l4rot = 0.1f;
        float l5rot = 0.5f;
        float l6rot = 0.9f;
        float l7rot = 0.3f;
        float l8rot = 0.4f;

        float oldscroll = 0;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            float mposx = Mouse.GetState().X;
            float mposy = Mouse.GetState().Y;
            l1pos = helper.rotatePoint2(new Vector2(mposx + 10, mposy + 15), new Vector2(mposx, mposy), l1rot);
            l2pos = helper.rotatePoint2(new Vector2(mposx -50, mposy + 75), new Vector2(mposx + 30, mposy + 20), l2rot);
            l3pos = helper.rotatePoint2(new Vector2(mposx + 2, mposy + 30), new Vector2(mposx-10, mposy), l1rot);
            l4pos = helper.rotatePoint2(new Vector2(mposx - 8, mposy - 75), new Vector2(mposx + 20, mposy + 60), l2rot);
            l5pos = helper.rotatePoint2(new Vector2(mposx - 220, mposy + 15), new Vector2(mposx-40, mposy-10), l1rot);
            l6pos = helper.rotatePoint2(new Vector2(mposx - 50, mposy - 25), new Vector2(mposx + 20, mposy - 70), l2rot);
            l7pos = helper.rotatePoint2(new Vector2(mposx + 40, mposy + 22), new Vector2(mposx-10, mposy+30), l1rot);
            l8pos = helper.rotatePoint2(new Vector2(mposx + 30, mposy - 75), new Vector2(mposx + 20, mposy - 20), l2rot);


            l1rot += 0.09f;
            l2rot += 0.06f;
            l3rot += 0.1f;
            l4rot += 0.02f;
            l5rot += 0.8f;
            l6rot += 0.08f;
            l7rot += 0.05f;
            l8rot += 0.09f;

            

            Camera2d.Pos = new Vector2(player.X, player.Y);

            MouseState m = Mouse.GetState();

            if (m.ScrollWheelValue > oldscroll)
            {
                Camera2d.Zoom += 0.01f;
                oldscroll = m.ScrollWheelValue;
            }

            if (m.ScrollWheelValue < oldscroll)
            {
                Camera2d.Zoom -= 0.1f;
                oldscroll = m.ScrollWheelValue;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                lineA.X--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                lineA.X++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                lineA.Y--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                lineA.Y++;
            }

            

            if (testingframeCount < 15)
            {
                testingc += 1.0f/15;
            }
            else if (testingframeCount <= 60 && testingframeCount >= 35)
            {
                testingc -= 1.0f / 25;
                testingbc += 1.0f / 25;
            }
            else if (testingframeCount > 60)
            {
                testingbc -= 1.0f / 20;
            }

            if (testingframeCount < 120)
            {
                testingframeCount++;
            }
            else
            {
                testingframeCount = 0;
                testingc = 0;
                testingbc = 0;
            }




            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                a.r.Y-=5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                a.r.X-=5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                a.r.Y+=5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                a.r.X+=5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                a.rotation += 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                a.rotation -= 0.1f;
            }






            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                c.location.Y--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.J))
            {
                c.location.X--;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                c.location.Y++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                c.location.X++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                c.rotation += 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.U))
            {
                c.rotation -= 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad8))
            {
                b.r.Y-=5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            {
                b.r.X-=5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            {
                b.r.Y+=5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad6))
            {
                b.r.X+=5;
            }


            Vector2 v = collision.ShapeSelector(a, b);

            if (a.mass > b.mass)
            {
                b.r.X -= (int)v.X;
                b.r.Y -= (int)v.Y;
            }
            else
            {
                a.r.X += (int)v.X;
                a.r.Y += (int)v.Y;
            }

            Vector2 vcr = collision.ShapeSelector(c, a);


            if (c.mass > a.mass)
            {
                a.r.X -= (int)vcr.X;
                a.r.Y -= (int)vcr.Y;
            }
            else
            {
                c.location += vcr;
            }

            //a.r.X -= (int)vcrr[1].X;
            //a.r.Y -= (int)vcrr[1].Y;

            Vector2 vcr2 = collision.ShapeSelector(c, b);

            if (c.mass > b.mass)
            {
                b.r.X -= (int)vcr2.X;
                b.r.Y -= (int)vcr2.Y;
            }
            else
            {
                c.location += vcr2;
            }

            Vector2 circV = collision.ShapeSelector(c, d);

            if (c.mass > d.mass)
            {
                d.location -= circV;
            }
            else
            {
                c.location += circV;
            }

            vcr2 = collision.ShapeSelector(d, b);

            if (d.mass > b.mass)
            {
                b.r.X -= (int)vcr2.X;
                b.r.Y -= (int)vcr2.Y;
            }
            else
            {
                d.location += vcr2;
            }

            vcr2 = collision.ShapeSelector(d, a);

            if (d.mass > a.mass)
            {
                a.r.X -= (int)vcr2.X;
                a.r.Y -= (int)vcr2.Y;
            }
            else
            {
                d.location += vcr2;
            }


            Vector2 vcl1 = collision.circleLineDetect(lineA, lineB, c);
            c.location -= vcl1;



            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            /*
            spriteBatch.Begin();

            int modifierx = 0;
            int modifiery = 0;
            if (Camera2d.Pos.X < 0)
            {
                modifierx = 100;
            }
            if (Camera2d.Pos.Y < 0)
            {
                modifiery = 100;
            }

            for (int i = 0; i < GraphicsDevice.PresentationParameters.BackBufferWidth / Camera2d.Zoom; i += 100)
            {
                for (int j = 0; j < GraphicsDevice.PresentationParameters.BackBufferHeight / Camera2d.Zoom; j += 100)
                {

                    spriteBatch.Draw(parabg, new Rectangle((int)(i * Camera2d.Zoom), (int)(j * Camera2d.Zoom), (int)(100 * Camera2d.Zoom), (int)(100 * Camera2d.Zoom)), new Rectangle((int)(modifierx + ((Camera2d.Pos.X * 0.5f % 100)), (int)(modifiery + ((Camera2d.Pos.Y * 0.5f % 100)), 100, 100), new Color(g * 0.005f, g * 0.002f, g * 0.009f, 1.0f));
                }
            }
            
            



            spriteBatch.End();
            

            begin.Alpha(spriteBatch);
            spriteBatch.Draw(nulltex, player, Color.Orange);
            spriteBatch.End();

            */

            graphics.GraphicsDevice.SetRenderTarget(0, colormap);
            GraphicsDevice.Clear(Color.DarkSlateGray);

            pbatch.Begin(PrimitiveType.LineList);
            pbatch.AddVertex(lineA, Color.Wheat);
            pbatch.AddVertex(lineB, Color.Wheat);

            pbatch.End();

            spriteBatch.Begin();

            spriteBatch.Draw(nulltex, a.r, new Rectangle(0, 0, nulltex.Width, nulltex.Height), Color.Green, a.rotation, new Vector2((a.rotatePoint.X / (float)a.r.Width) * 3, (a.rotatePoint.Y / (float)a.r.Height) * 3), SpriteEffects.None, 1.0f);
            spriteBatch.Draw(nulltex, b.r, new Rectangle(0, 0, nulltex.Width, nulltex.Height), Color.Orange, b.rotation, new Vector2((b.rotatePoint.X / (float)b.r.Width) * 3, (b.rotatePoint.Y / (float)b.r.Height) * 3), SpriteEffects.None, 1.0f);
            
            
            //Draw circle
            spriteBatch.Draw(circle50, new Rectangle((int)c.location.X, (int)c.location.Y, (int)c.radius * 2, (int)c.radius * 2), new Rectangle(0, 0, 50, 50), Color.White, c.rotation, new Vector2(25), SpriteEffects.None, 1.0f);
            spriteBatch.Draw(circle50, new Rectangle((int)d.location.X, (int)d.location.Y, (int)d.radius * 2, (int)d.radius * 2), new Rectangle(0, 0, 50, 50), Color.Purple, d.rotation, new Vector2(25), SpriteEffects.None, 1.0f);


            //spriteBatch.Draw(circle50Heightmap, new Rectangle((int)c.location.X, (int)c.location.Y, (int)c.radius * 2, (int)c.radius * 2), new Rectangle(0, 0, 50, 50), Color.White, c.rotation, new Vector2(25), SpriteEffects.None, 1.0f);
            //spriteBatch.Draw(circle50Heightmap, new Rectangle((int)d.location.X, (int)d.location.Y, (int)d.radius * 2, (int)d.radius * 2), new Rectangle(0, 0, 50, 50), Color.White, d.rotation, new Vector2(25), SpriteEffects.None, 1.0f);
         
/*
 * 
 * 
            spriteBatch.Draw(nulltex, collision.todraw1, Color.Black);
            spriteBatch.Draw(nulltex, collision.todraw2, Color.Black);
            spriteBatch.Draw(nulltex, collision.todraw3, Color.Black);
            spriteBatch.Draw(nulltex, collision.todraw4, Color.Black);
            spriteBatch.Draw(nulltex, collision.todraw5, Color.Black);
            spriteBatch.Draw(nulltex, collision.todraw6, Color.Black);
            spriteBatch.Draw(nulltex, collision.todraw7, Color.Black);
            spriteBatch.Draw(nulltex, collision.todraw8, Color.Black);*/
            spriteBatch.Draw(nulltex, collision.todraw9, Color.Purple);/*



            spriteBatch.Draw(testingblur,new Rectangle(100,100,300,100),new Color(1,1,1,0.8f*testingbc));
            spriteBatch.Draw(testing,new Rectangle(100,100,300,100),new Color(1,1,1,testingc*0.8f));
            */
            spriteBatch.End();
            graphics.GraphicsDevice.SetRenderTarget(0, heightmap);
            GraphicsDevice.Clear(new Color(0.1f,0.1f,0.1f));
            spriteBatch.Begin();
            spriteBatch.Draw(circle50Heightmap, new Rectangle((int)c.location.X, (int)c.location.Y, (int)c.radius * 2, (int)c.radius * 2), new Rectangle(0, 0, 50, 50), Color.White, c.rotation, new Vector2(25), SpriteEffects.None, 1.0f);
            spriteBatch.Draw(circle50Heightmap, new Rectangle((int)d.location.X, (int)d.location.Y, (int)d.radius * 2, (int)d.radius * 2), new Rectangle(0, 0, 50, 50), Color.White, d.rotation, new Vector2(25), SpriteEffects.None, 1.0f);
            spriteBatch.End();

            graphics.GraphicsDevice.SetRenderTarget(0, null);
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.Textures[1] = heightmap.GetTexture();

            spriteBatch.Begin(SpriteBlendMode.None, SpriteSortMode.Immediate,
    SaveStateMode.None);

            //Set lighting params
            lighting.Parameters["LightPositions"].Elements[0].SetValue(l1pos);
            lighting.Parameters["LightPositions"].Elements[1].SetValue(l2pos);
            lighting.Parameters["LightIntense"].Elements[0].SetValue(400);
            lighting.Parameters["LightIntense"].Elements[1].SetValue(600);
            lighting.Parameters["LightColors"].Elements[0].SetValue(new Vector4(0.7f, 0.8f, 1, 0.5f));
            lighting.Parameters["LightColors"].Elements[1].SetValue(new Vector4(0.5f, 0.1f, 0.15f, 0.5f));

            lighting.Parameters["LightPositions"].Elements[2].SetValue(l3pos);
            lighting.Parameters["LightPositions"].Elements[3].SetValue(l4pos);
            lighting.Parameters["LightIntense"].Elements[2].SetValue(100);
            lighting.Parameters["LightIntense"].Elements[3].SetValue(500);
            lighting.Parameters["LightColors"].Elements[2].SetValue(new Vector4(0.7f, 0.8f, 1, 0.5f));
            lighting.Parameters["LightColors"].Elements[3].SetValue(new Vector4(1f, 0.1f, 0.6f, 0.5f));

            lighting.Parameters["LightPositions"].Elements[4].SetValue(l5pos);
            lighting.Parameters["LightPositions"].Elements[5].SetValue(l6pos);
            lighting.Parameters["LightIntense"].Elements[4].SetValue(150);
            lighting.Parameters["LightIntense"].Elements[5].SetValue(350);
            lighting.Parameters["LightColors"].Elements[4].SetValue(new Vector4(0.2f, 0.6f, 0.4f, 0.5f));
            lighting.Parameters["LightColors"].Elements[5].SetValue(new Vector4(0.5f, 0.1f, 0.5f, 0.5f));

            lighting.Parameters["LightPositions"].Elements[6].SetValue(l7pos);
            lighting.Parameters["LightPositions"].Elements[7].SetValue(l8pos);
            lighting.Parameters["LightIntense"].Elements[6].SetValue(250);
            lighting.Parameters["LightIntense"].Elements[7].SetValue(50);
            lighting.Parameters["LightColors"].Elements[6].SetValue(new Vector4(0.7f, 0.8f, 0.3f, 0.5f));
            lighting.Parameters["LightColors"].Elements[7].SetValue(new Vector4(0.1f, 0.6f, 0.7f, 0.5f));


            lighting.Begin();

            EffectPass pass = lighting.CurrentTechnique.Passes[0];
            pass.Begin();

            spriteBatch.Draw(colormap.GetTexture(), Vector2.Zero, Color.White);
            pass.End();

            lighting.End();

            spriteBatch.End();

            GraphicsDevice.Textures[1] = null;

            base.Draw(gameTime);
        }
    }
}
