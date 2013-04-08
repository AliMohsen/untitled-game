using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class MovementTime : BaseComponent
    {
        private long millisToMove = 5000;
        public long getMillisToMove()
        {
            return millisToMove;
        }
    }
}
