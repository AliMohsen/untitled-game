using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class DeadComponent : BaseComponent
    {
        int overkillAmount;
        long killScreenTime = 5000;
        public static readonly long totalKillScreenTime;

        public DeadComponent(int overkillAmount)
        {
            this.overkillAmount = overkillAmount;
        }

        public long getkillScreenTime()
        {
            return killScreenTime;
        }

        public void decrementKillScreenTime(long millis)
        {
            killScreenTime -= millis;
        }
    }
}
