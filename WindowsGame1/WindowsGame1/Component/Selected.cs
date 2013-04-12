using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class Selected : BaseComponent
    {
        private int shotsFired = 0;

        public int getShotsFired()
        {
            return shotsFired;
        }

        public void setShotsFired(int shotsFired)
        {
            this.shotsFired = shotsFired;
        }

        public void incrementShotsFired()
        {
            ++shotsFired;
        }
    }
}
