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
        void setMap(Map map);

        #region Camera functions.

        void setZoom(float zoom);
        float getZoom(float zoom);

        void setRotation(float rotate);
        float getRotation();

        void setWorldPosition(Vector2 position);
        Vector2 getWorldPosition();

        void setEntityViewpoint(bool entityViewpoint);

        #endregion
    }
}