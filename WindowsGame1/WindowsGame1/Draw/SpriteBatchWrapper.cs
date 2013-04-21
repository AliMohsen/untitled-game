using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.GameState;

namespace TheGameOfForever.Draw
{
    public static class SpriteBatchWrapper
    {
        struct DrawParams : IComparable<DrawParams>
        {
            public Texture2D texture;
            public SpriteFont spriteFont;
            public StringBuilder text;
            public string textString;
            public Vector2? position;
            public Rectangle? destinationRectangle;
            public Rectangle? sourceRectangle;
            public Color color;
            public float rotation;
            public Vector2 origin;
            public Vector2? scale;
            public float scaleF;
            public SpriteEffects effects;
            public float layerDepth;
            public int matrix;

            public DrawParams(Texture2D texture, SpriteFont spriteFont, Vector2? position,
                Rectangle? destinationRectangle, Rectangle? sourceRectangle, StringBuilder text,
                string textString, Color color, float rotation, Vector2 origin, Vector2? scale,
                float scaleF, SpriteEffects effects, float layerDepth, int matrix)
            {
                this.texture = texture;
                this.spriteFont = spriteFont;
                this.position = position;
                this.destinationRectangle = destinationRectangle;
                this.sourceRectangle = sourceRectangle;
                this.text = text;
                this.textString = textString;
                this.color = color;
                this.rotation = rotation;
                this.origin = origin;
                this.scale = scale;
                this.scaleF = scaleF;
                this.effects = effects;
                this.layerDepth = layerDepth;
                this.matrix = matrix;
            }

            public int CompareTo(DrawParams obj)
            {
                if (this.layerDepth > obj.layerDepth)
                {
                    return -1;
                }
                else if (this.layerDepth < obj.layerDepth)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private static List<DrawParams> toDraw;
        private static List<Matrix> transforms;

        public static void initialise()
        {
            toDraw = new List<DrawParams>();
            transforms = new List<Matrix>();
        }

        private static int addMatrix(Matrix matrix)
        {
            if (transforms.Contains(matrix))
            {
                return transforms.IndexOf(matrix);
            }
            else
            {
                transforms.Add(matrix);
                return transforms.Count - 1;
            }
        }

        public static void DrawUI(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, null, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, null, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Rectangle destinationRectangle, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, null, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, null, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, null, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Vector2 position, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, null, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, sourceRectangle, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, sourceRectangle, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, sourceRectangle, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, sourceRectangle, null, null, color, rotation, origin, new Vector2(1), 1, effects, layerDepth, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, sourceRectangle, null, null, color, rotation, origin, new Vector2(1), 1, effects, layerDepth, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, null, destinationRectangle, sourceRectangle, null, null, color, rotation, origin, new Vector2(1), 1, effects, layerDepth, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, rotation, origin, scale, 1, effects, layerDepth, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, rotation, origin, scale, 1, effects, layerDepth, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, rotation, origin, scale, 1, effects, layerDepth, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, rotation, origin, null, scale, effects, layerDepth, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, rotation, origin, null, scale, effects, layerDepth, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, position, null, sourceRectangle, null, null, color, rotation, origin, null, scale, effects, layerDepth, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawStringUI(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, null, text, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawStringGame(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, null, text, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawStringCustom(SpriteFont spriteFont, string text, Vector2 position, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, null, text, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawStringUI(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, text, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawStringGame(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, text, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawStringCustom(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, text, null, color, 0, new Vector2(0.5f), new Vector2(1), 1, SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawStringUI(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, null, text, color, rotation, origin, null, scale, effects, layerDepth, -1);
            toDraw.Add(parameters);
        }

        public static void DrawStringGame(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, null, text, color, rotation, origin, null, scale, effects, layerDepth, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawStringCustom(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth, Matrix transform)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, null, text, color, rotation, origin, null, scale, effects, layerDepth, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawStringUI(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, text, null, color, rotation, origin, null, scale, effects, layerDepth, -1);
            toDraw.Add(parameters);
        }

        public static void DrawStringGame(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, text, null, color, rotation, origin, null, scale, effects, layerDepth, addMatrix(GameStateManager.getCamera().getCameraTransformMatrix()));
            toDraw.Add(parameters);
        }

        public static void DrawStringCustom(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth, Matrix transform)
        {
            DrawParams parameters = new DrawParams(null, spriteFont, position, null, null, text, null, color, rotation, origin, null, scale, effects, layerDepth, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void drawItems(SpriteBatch spriteBatch)
        {
            toDraw.Sort();
            DrawHelper.spriteBatchBeginGame(spriteBatch);

            int prevMatrixIndex = 0;
            int currMatrixIndex;

            foreach (DrawParams p in toDraw)
            {
                currMatrixIndex = p.matrix;

                if (currMatrixIndex != prevMatrixIndex)
                {
                    spriteBatch.End();
                    if (currMatrixIndex < 0)
                    {
                        spriteBatch.Begin();
                    }
                    else
                    {
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, transforms.ElementAt(currMatrixIndex));
                    }
                }

                if (p.spriteFont == null)
                {
                    if (p.position != null)
                    {
                        if (p.scale != null)
                        {
                            spriteBatch.Draw(p.texture, (Vector2)p.position, p.sourceRectangle, p.color, p.rotation, p.origin, (Vector2)p.scale, p.effects, p.layerDepth);
                        }
                        else
                        {
                            spriteBatch.Draw(p.texture, (Vector2)p.position, p.sourceRectangle, p.color, p.rotation, p.origin, (float)p.scaleF, p.effects, p.layerDepth);
                        }
                    }
                    else
                    {
                        spriteBatch.Draw(p.texture, (Rectangle)p.destinationRectangle, p.sourceRectangle, p.color, p.rotation, p.origin, p.effects, p.layerDepth);
                    }
                }
                else
                {
                    if (p.text != null)
                    {
                        spriteBatch.DrawString(p.spriteFont, p.text, (Vector2)p.position, p.color, p.rotation, p.origin, (float)p.scaleF, p.effects, p.layerDepth);
                    }
                    else
                    {
                        spriteBatch.DrawString(p.spriteFont, p.textString, (Vector2)p.position, p.color, p.rotation, p.origin, (float)p.scaleF, p.effects, p.layerDepth);
                    }
                }
                prevMatrixIndex = currMatrixIndex;
            }

            toDraw.Clear();
            spriteBatch.End();
        }
    }
}