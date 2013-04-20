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
            public Vector2? position;
            public Rectangle? destinationRectangle;
            public Rectangle? sourceRectangle;
            public Color color;
            public float rotation;
            public Vector2 origin;
            public Vector2 scale;
            public SpriteEffects effects;
            public float layerDepth;
            public int matrix;

            public DrawParams(Texture2D texture, Vector2? position, Rectangle? destinationRectangle,
                Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale,
                SpriteEffects effects, float layerDepth, int matrix)
            {
                this.texture = texture;
                this.position = position;
                this.destinationRectangle = destinationRectangle;
                this.sourceRectangle = sourceRectangle;
                this.color = color;
                this.rotation = rotation;
                this.origin = origin;
                this.scale = scale;
                this.effects = effects;
                this.layerDepth = layerDepth;
                this.matrix = matrix;
            }

            public int CompareTo(DrawParams obj)
            {
                if (this.layerDepth < obj.layerDepth)
                {
                    return -1;
                }
                else if (this.layerDepth > obj.layerDepth)
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
            transforms.Add(GameStateManager.getCamera().getCameraTransformMatrix());
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
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, 0);
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Rectangle destinationRectangle, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(texture, position, null, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(texture, position, null, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, 0);
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Vector2 position, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, position, null, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, 0);
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, 0);
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, rotation, origin, new Vector2(1), effects, layerDepth, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, rotation, origin, new Vector2(1), effects, layerDepth, 0);
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, rotation, origin, new Vector2(1), effects, layerDepth, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void DrawUI(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, rotation, origin, scale, effects, layerDepth, -1);
            toDraw.Add(parameters);
        }

        public static void DrawGame(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, rotation, origin, scale, effects, layerDepth, 0);
            toDraw.Add(parameters);
        }

        public static void DrawCustom(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, Matrix transform)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, rotation, origin, scale, effects, layerDepth, addMatrix(transform));
            toDraw.Add(parameters);
        }

        public static void drawItems(SpriteBatch spriteBatch)
        {
            toDraw.Sort();
            //            DrawHelper.spriteBatchBeginGame(spriteBatch);

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
                        spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null,
                            transforms.ElementAt(currMatrixIndex));
                    }
                }

                if (p.position != null)
                {
                    spriteBatch.Draw(p.texture, (Vector2)p.position, p.sourceRectangle, p.color, p.rotation, p.origin, p.scale, p.effects, p.layerDepth);
                }
                else
                {
                    spriteBatch.Draw(p.texture, (Rectangle)p.destinationRectangle, p.sourceRectangle, p.color, p.rotation, p.origin, p.effects, p.layerDepth);
                }

                prevMatrixIndex = currMatrixIndex;
            }

            toDraw.Clear();
            //            spriteBatch.End();
        }
    }
}