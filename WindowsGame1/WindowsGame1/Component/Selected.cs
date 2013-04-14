using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class Selected : BaseComponent
    {
        private bool hasFired = false;

        public bool getHasFired()
        {
            return hasFired;
        }

        public void setHasFired(bool hasFired)
        {
            this.hasFired = hasFired;
        }
    }
}
