using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Control
{
    public interface IControl
    {
        void updateCurrent();
        void updateLast();

        //Right stick directionals
        bool isRUpPressed();
        bool isRUpHeld();
        bool isRDownPressed();
        bool isRDownHeld();
        bool isRLeftPressed();
        bool isRLeftHeld();
        bool isRRightPressed();
        bool isRRightHeld();
        
        //Left stick directionals
        bool isLUpPressed();
        bool isLUpHeld();
        bool isLDownPressed();
        bool isLDownHeld();
        bool isLLeftPressed();
        bool isLLeftHeld();
        bool isLRightPressed();
        bool isLRightHeld();

        bool isActionAPressed();
        bool isActionAHeld();
        bool isActionBPressed();
        bool isActionBHeld();
        bool isActionCPressed();
        bool isActionCHeld();
        bool isActionDPressed();
        bool isActionDHeld();
        bool isActionEPressed();
        bool isActionEHeld();
    }
}
