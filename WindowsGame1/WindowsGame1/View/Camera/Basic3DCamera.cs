using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.View.Camera
{
    public class Basic3DCamera
    {
        public enum CameraMode
        {
            FOLLOWINGSTANDARD,
            FOLLOWINGAIMING,
            FREE
        }

        Vector3 position;
        Vector3 lookingAt;
        float rotation;
        float fieldOfView;
        float aspectRatio;
        CameraMode cameraMode = CameraMode.FREE;

        private Vector3 followingStandardOffset = new Vector3(0, 2, -4);
        private Vector3 followingAimingOffset = new Vector3(-0.8f, 1.5f, -3);

        public void setEntityRotation(float rotation)
        {
            this.rotation = rotation;
        }

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
            switch (cameraMode)
            {
                case CameraMode.FOLLOWINGSTANDARD:
                    {
                        Matrix rotationMatrix = Matrix.CreateRotationY(rotation);
                        Vector3 transformedReference =
                             Vector3.Transform(followingStandardOffset, rotationMatrix);
                        Vector3 cameraPosition = transformedReference + lookingAt;
                        return Matrix.CreateLookAt(cameraPosition, lookingAt,
                            new Vector3(0.0f, 1.0f, 0.0f));
                    }
                case CameraMode.FOLLOWINGAIMING:
                    {
                        Matrix rotationMatrix = Matrix.CreateRotationY(rotation);
                        Vector3 transformedReference =
                             Vector3.Transform(followingAimingOffset, rotationMatrix);
                        Vector3 cameraPosition = transformedReference + lookingAt;
                        return Matrix.CreateLookAt(cameraPosition, lookingAt,
                            new Vector3(0.0f, 1.0f, 0.0f));
                    }
                case CameraMode.FREE:
                    return Matrix.CreateLookAt(position, lookingAt, new Vector3(0, 1, 0));
            }
            return default(Matrix);
        }

        public Matrix getProjectionMatrix()
        {
            return Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, 1.0f, 300.0f);
        }
    }
}
