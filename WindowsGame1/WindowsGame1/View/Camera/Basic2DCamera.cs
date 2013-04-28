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
    public class Basic2DCamera : ICamera2D
    {
        /// <summary>
        /// IsStale tells us if we need to recompute the map transform.
        /// </summary>
        private bool isStale = true;

        private int viewportWidth;
        private int viewportHeight;
        private int worldWidth;
        private int worldHeight;

        private float zoom = 1;
        private float desiredZoom = 1;
        private float zoomFollowSpeed = 0.2f;

        private Matrix transform;

        private Vector2 position;
        private Vector2 desiredPosition;
        private float positionFollowSpeed = 0.2f;

        private float rotation;
        private float desiredRotation;
        private float rotationFollowSpeed = 0.2f;

        private Map map;

        public Basic2DCamera()
        {
            viewportWidth = 1000;
            viewportHeight = 620;
            worldHeight = 5 * 200; // 200 metres;
            worldWidth = 5 * 200;
        }

        public void setMap(Map map)
        {
            this.map = map;
            worldWidth = (int)Map.getWorldHeight();
            worldHeight = (int)Map.getWorldWidth();
        }

        public Matrix getCameraTransformMatrix()
        {

           transform =
               Matrix.CreateTranslation(-position.X, -position.Y, 0) *
               Matrix.CreateRotationZ(-rotation) * 
               Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
               Matrix.CreateTranslation(new Vector3(viewportWidth / 2f,
                  viewportHeight / 2f, 0));
            return transform;
        }

        public Vector2 translateToGame(Vector2 point)
        {
            Vector3 output = (Matrix.CreateTranslation(point.X, point.Y, 0) * Matrix.Invert(transform)).Translation;
            return new Vector2(output.X, output.Y);
        }

        public Vector2 translateToUI(Vector2 point)
        {
            Vector3 output = (Matrix.CreateTranslation(point.X, point.Y, 0) * transform).Translation;
                           return new Vector2(output.X, output.Y);
        }

        public void update()
        {
            rotation = MathHelper.SmoothStep(rotation, desiredRotation, rotationFollowSpeed);
            zoom = MathHelper.SmoothStep(zoom, desiredZoom, zoomFollowSpeed);
            position.X = MathHelper.SmoothStep(position.X, desiredPosition.X, positionFollowSpeed);
            position.Y = MathHelper.SmoothStep(position.Y, desiredPosition.Y, positionFollowSpeed);
        }

        public void setZoom(float zoom)
        {
            this.zoom = zoom;
            desiredZoom = zoom;
            isStale = true;
        }

        public float getZoom(float zoom)
        {
            return zoom;
        }

        public void setRotation(float rotation)
        {
            this.rotation = rotation;
            desiredRotation = rotation;
            isStale = true;
        }

        public float getRotation()
        {
            return rotation;
        }

        public void setWorldPosition(Vector2 position)
        {
            this.position = position;
            desiredPosition = position;
            isStale = true;
        }

        public Vector2 getWorldPosition()
        {
            return position;
        }

        public float getZoom()
        {
            return zoom;
        }

        public void setDesiredZoom(float zoom)
        {
            desiredZoom = zoom;
        }

        public void setZoomFollowSpeed(float speed)
        {
            zoomFollowSpeed = speed;
        }

        public void setTrackingRotation(float rotate)
        {
            rotation = rotate - (float) Math.PI;
            desiredRotation = rotation;
        }

        public void setDesiredTrackingRotation(float rotate)
        {
            desiredRotation = rotate - (float)Math.PI;
        }

        public void setDesiredRotation(float rotate)
        {
            desiredRotation = rotate;
        }

        public float getTrackingRotation()
        {
            return rotation + (float)Math.PI;
        }

        public void setRotationFollowSpeed(float speed)
        {
            rotationFollowSpeed = speed;
        }

        public void setDesiredWorldPosition(Vector2 position)
        {
            desiredPosition = position;
        }

        public void setWorldPositionFollowSpeed(float speed)
        {
            positionFollowSpeed = speed;
        }
    }
}
