using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.Ui.Layer
{
    /// <summary>
    /// Manages the composition of UI layers.
    /// </summary>
    class UiLayerManager
    {
        private LinkedList<ILayer> layers = new LinkedList<ILayer>();

        /// <summary>
        /// Add layer to top of layer stack.
        /// </summary>
        /// <param name="layer"></param>
        public void addLayerOnTop(ILayer layer)
        {
            layers.AddFirst(layer);
        }

        /// <summary>
        /// Removes the layer which .equals(layer).
        /// </summary>
        /// <param name="layer"></param>
        public void removeLayer(ILayer layer)
        {
            layers.Remove(layer);
        }

        /// <summary>
        /// Update acts on the top layer first followed by the layers undearneath in order.
        /// </summary>
        /// <param name="gameTime"></param>
        public void update(GameTime gameTime)
        {
            bool canUpdate = true;           
            foreach (ILayer layer in layers)
            {
                if (canUpdate)
                {
                    layer.update(gameTime);
                    canUpdate &= !layer.stopUpdatePropagation();
                }
            }
        }

        /// <summary>
        /// Draw the layers in order.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void draw(SpriteBatch spriteBatch)
        {
            bool canDraw = true;
            Queue<ILayer> layersToDraw = new Queue<ILayer>();
            foreach (ILayer layer in layers)
            {
                if (canDraw)
                {
                    layersToDraw.Enqueue(layer);
                    canDraw &= !layer.stopDrawPropagation();
                }
            }
            foreach (ILayer layer in layersToDraw)
            {
                layer.draw(spriteBatch);
            }
        }


    }
}
