using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Component.Map;

namespace TheGameOfForever.View.Camera
{
    /// <summary>
    /// A basic 2D camera implementation.
    /// </summary>
    public class Basic2DCamera : ICamera
    {
        /// <summary>
        /// IsStale tells us if we need to recompute the map transform.
        /// </summary>
        private bool isStale = true;

        private int viewportWidth;
        private int viewportHeight;
        private int worldWidth;
        private int worldHeight;

        private float zoom;
        private Matrix transform;
        private Vector2 position;
        private float rotation;

        private Map map;

        public Basic2DCamera()
        {
            viewportWidth = GraphicsDeviceManager.DefaultBackBufferWidth;
            viewportWidth = GraphicsDeviceManager.DefaultBackBufferHeight;
            worldHeight = 5 * 200; // 200 metres;
            worldWidth = 5 * 200;
        }

        public void setMap(Map map)
        {
            this.map = map;
            worldWidth = (int)map.getWorldHeight();
            worldHeight = (int)map.getWorldWidth();
        }

        public Matrix getCameraTransformMatrix()
        {
            if (isStale || transform == null)
            {
                transform =
                     Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0))
                     * Matrix.CreateRotationZ(rotation) 
                     * Matrix.CreateScale(new Vector3(zoom, zoom, 1)) 
                     * Matrix.CreateTranslation(new Vector3(viewportWidth 
                         * 0.5f,viewportHeight * 0.5f, 0));
            }
            return transform;
        }

        public void setZoom(float zoom)
        {
            this.zoom = zoom;
            isStale = true;
        }

        public float getZoom(float zoom)
        {
            return zoom;
        }

        public void setRotation(float rotation)
        {
            this.rotation = rotation;
            isStale = true;
        }

        public float getRotation()
        {
            return rotation;
        }

        public void setWorldPosition(Vector2 position)
        {
            this.position = position;
            isStale = true;
        }

        public Vector2 getWorldPosition()
        {
            return position;
        }
    }
}
