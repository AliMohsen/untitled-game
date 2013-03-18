using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class LocationComponent : BaseComponent
    {
        private Vector2 location;

        public LocationComponent(Vector2 startingLocation)
        {
            this.location = location;
        }

        public Vector2 getLocation()
        {
            return location;
        }

        public void setLocation(Vector2 location)
        {
            this.location = location;
        }
    }
}
