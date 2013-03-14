using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component.Map
{
    public class Map
    {
        /// <summary>
        /// At 1.0 zoom, 5 pixels = 1 metre.
        /// </summary>
        private static readonly float WORLD_HEIGHT = 200 * 5;
        private static readonly float WORLD_WIDTH = 200 *5;

        public float getWorldHeight()
        {
            return WORLD_HEIGHT;
        }
        public float getWorldWidth()
        {
            return WORLD_WIDTH;
        }

    }
}
