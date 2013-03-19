using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class Controllable : BaseComponent
    {
        Boolean inControl = false;

        public Controllable()
        { }

        public bool isInControl()
        {
            return inControl;
        }

        public void setIsInControl(bool inControl)
        {
            this.inControl = inControl;
        }

        public void toggleInControl()
        {
            inControl = !inControl;
        }
    }
}
