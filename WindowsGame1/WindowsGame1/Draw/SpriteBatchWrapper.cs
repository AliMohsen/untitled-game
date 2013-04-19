using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

            public DrawParams(Texture2D texture, Vector2? position, Rectangle? destinationRectangle,
                Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale,
                SpriteEffects effects, float layerDepth)
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
            }

            public int CompareTo(DrawParams obj)
            {
                return (int)(this.layerDepth - obj.layerDepth);
            }
        }

        private static List<DrawParams> toDraw = new List<DrawParams>();

        public static void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);
            toDraw.Add(parameters);
        }

        public static void Draw(Texture2D texture, Vector2 position, Color color)
        {
            DrawParams parameters = new DrawParams(texture, position, null, null, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);
            toDraw.Add(parameters);
        }

        public static void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);
            toDraw.Add(parameters);
        }

        public static void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, 0,
                new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);
            toDraw.Add(parameters);
        }

        public static void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, null, destinationRectangle, sourceRectangle, color, rotation, origin, new Vector2(1), effects, layerDepth);
            toDraw.Add(parameters);
        }

        public static void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            DrawParams parameters = new DrawParams(texture, position, null, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
            toDraw.Add(parameters);
        }

        public static void drawItems(SpriteBatch spriteBatch)
        {
            toDraw.Sort();
//            DrawHelper.spriteBatchBeginGame(spriteBatch);

            foreach (DrawParams p in toDraw)
            {
                if (p.position != null)
                {
                    spriteBatch.Draw(p.texture, (Vector2)p.position, p.sourceRectangle, p.color, p.rotation, p.origin, p.scale, p.effects, p.layerDepth);
                }
                else
                {
                    spriteBatch.Draw(p.texture, (Rectangle)p.destinationRectangle, p.sourceRectangle, p.color, p.rotation, p.origin, p.effects, p.layerDepth);
                }
            }

            toDraw.Clear();

//            spriteBatch.End();
        }
    }
}
