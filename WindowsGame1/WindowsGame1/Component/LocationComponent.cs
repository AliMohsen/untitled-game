using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class LocationComponent : BaseComponent
    {
        private Vector2 currentLocation;
        private Vector2 lastLocation;
        private float facingRadians = 0;

        public LocationComponent(Vector2 startingLocation, float facingRadians)
        {
            this.currentLocation = startingLocation;
            this.lastLocation = startingLocation;
            this.facingRadians = facingRadians;
        }

        public Vector2 getCurrentLocation()
        {
            return currentLocation;
        }

        public void setCurrentLocation(Vector2 location)
        {
            lastLocation = currentLocation;
            this.currentLocation = location;
        }

        public Vector2 getLastLocation()
        {
            return lastLocation;
        }

        public void setFacingRadians(float facingRadians)
        {
            this.facingRadians = facingRadians;
        }

        public float getFacingRadians()
        {
            return facingRadians;
        }
    }
}
