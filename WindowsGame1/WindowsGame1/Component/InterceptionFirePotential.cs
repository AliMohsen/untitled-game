using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class InterceptionFirePotential : BaseComponent
    {
        private int maxAwarenessRangeFront;
        private int maxAwarenessRangeBack;
        private long lastVolleyFired = 0;
        private long shotsLeftInVolley = 0;

        public InterceptionFirePotential(int maxAwarenessRangeFront, int maxAwarenessRangeBack)
        {
            this.maxAwarenessRangeBack = maxAwarenessRangeBack;
            this.maxAwarenessRangeFront = maxAwarenessRangeFront;
        }

        public int getMaxAwarenessRangeFront()
        {
            return maxAwarenessRangeFront;
        }

        public int getMaxAwarenessRangeBack()
        {
            return maxAwarenessRangeBack;
        }

    }
}
