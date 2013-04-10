using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class MovementTime : BaseComponent
    {
        private long fullMillisToMove = 5000;
        private int movedAmount;
        private long millisToMove = 5000;

        public long getMillisToMove()
        {
            return millisToMove;
        }

        public void decrementMillisToMove(long millis)
        {
            millisToMove -= millis;
        }

        public long getFullMillisToMove()
        {
            return fullMillisToMove;
        }

        public void incrementMovedAmount()
        {
            movedAmount++;
            millisToMove = fullMillisToMove;
        }

        public int getMovedAmount()
        {
            return movedAmount;
        }
    }
}
