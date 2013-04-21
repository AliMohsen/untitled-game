using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service.Shapes
{
    public interface IShape
    {
        Vector2 getLocation();
        void setLocation(Vector2 location);
        void setRotation(float rotation);
        float getRotation();
    }
}
