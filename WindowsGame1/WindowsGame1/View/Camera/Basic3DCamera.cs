using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.View.Camera
{
    public class Basic3DCamera
    {
        Vector3 position;
        Vector3 lookingAt;
        float rotated;
        float fieldOfView;
        float aspectRatio;

        public void setPosition(Vector3 position)
        {
            this.position = position;
        }

        public void setLookingAt(Vector3 lookingAt)
        {
            this.lookingAt = lookingAt;
        }

        public void setFieldOfView(float fieldOfView)
        {
            this.fieldOfView = fieldOfView;
        }

        public void setAspectRatio(float aspectRatio)
        {
            this.aspectRatio = aspectRatio;
        }

        public Matrix getViewMatrix()
        {
            return Matrix.CreateLookAt(position, lookingAt, new Vector3(0, 1, 0));
        }

        public Matrix getProjectionMatrix()
        {
            return Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, 1.0f, 300.0f);
        }
    }
}
