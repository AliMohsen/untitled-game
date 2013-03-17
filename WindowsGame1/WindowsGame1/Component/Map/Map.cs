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
        private static readonly float WORLD_HEIGHT = 620;
        private static readonly float WORLD_WIDTH = 1000;

        public static float getWorldHeight()
        {
            return WORLD_HEIGHT;
        }
        public static float getWorldWidth()
        {
            return WORLD_WIDTH;
        }

    }
}
