using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.GameState
{
    public static class GlobalStateInfo
    {
        private static int totalPlayers = 2;

        public static int getTotalPlayers()
        {
            return totalPlayers;
        }

        public static void setTotalPlayers(int total)
        {
            totalPlayers = total;
        }
    }
}
