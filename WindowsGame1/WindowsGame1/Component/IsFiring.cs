using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class IsFiring : BaseComponent
    {
        private int shotsFired = 0;
        private long timeSinceFirstShot = 0;
        private bool completed = false;

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

        public long getTimeSinceFirstShot()
        {
            return timeSinceFirstShot;
        }

        public void setTimeSinceFirstShot(long timeSinceFirstShot)
        {
            this.timeSinceFirstShot = timeSinceFirstShot;
        }

        public bool getCompleted()
        {
            return completed;
        }

        public void setCompleted(bool completed)
        {
            this.completed = completed;
        }
    }
}
