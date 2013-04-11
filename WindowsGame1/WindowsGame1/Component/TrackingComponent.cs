using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class TrackingComponent : BaseComponent
    {
        Vector2 location;
        float rotation;

        public TrackingComponent setTrackingRotation(float rotation)
        {
            this.rotation = rotation;
            return this;
        }

        public float getTrackingRotation()
        {
            return rotation;
        }

        public TrackingComponent setTrackingLocation(Vector2 location)
        {
            this.location = location;
            return this;
        }

        public Vector2 getTrackingLocation()
        {
            return location;
        }
    }
}
