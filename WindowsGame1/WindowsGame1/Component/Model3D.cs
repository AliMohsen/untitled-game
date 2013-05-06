using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class Model3D : BaseComponent
    {
        Quaternion rotation;
        Vector3 location;
        int modelIndex;
        float scale;

        public Model3D(int modelIndex, float scale)
        {
            this.modelIndex = modelIndex;
            this.scale = scale;
        }

        public Quaternion getRotation()
        {
            return rotation;
        }

        public Vector3 getLocation()
        {
            return location;
        }

        public void setLocation(Vector3 location)
        {
            this.location = location;
        }

        public void setRotation(Quaternion rotation)
        {
            this.rotation = rotation;
        }

        public float getScale()
        {
            return scale;
        }

        public int getModelIndex()
        {
            return modelIndex;
        }

    }
}
