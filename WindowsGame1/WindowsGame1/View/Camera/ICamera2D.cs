using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Component.Map;

namespace TheGameOfForever.View.Camera
{
    public interface ICamera2D
    {
        Matrix getCameraTransformMatrix();
        void update();
        void setMap(Map map);
        Vector2 translateToGame(Vector2 point);
        Vector2 translateToUI(Vector2 point);
        #region Camera functions.

        void setZoom(float zoom);
        float getZoom();
        void setDesiredZoom(float zoom);
        void setZoomFollowSpeed(float speed);

        void setRotation(float rotate);
        void setTrackingRotation(float rotate);
        void setDesiredTrackingRotation(float rotate);
        void setDesiredRotation(float rotate);
        float getTrackingRotation();
        float getRotation();
        void setRotationFollowSpeed(float speed);

        void setWorldPosition(Vector2 position);
        void setDesiredWorldPosition(Vector2 position);
        void setWorldPositionFollowSpeed(float speed);
        Vector2 getWorldPosition();

        #endregion
    }
}