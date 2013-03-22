using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace TheGameOfForever.Control
{
    public class KeyboardControl : IControl
    {
        private static KeyboardState current = Keyboard.GetState();
        private static KeyboardState previous = Keyboard.GetState();

        public void updateCurrent()
        {
            KeyboardControl.current = Keyboard.GetState();
        }

        public void updateLast()
        {
            KeyboardControl.previous = current;
        }

        public bool isRUpPressed()
        {
            return current.IsKeyDown(Keys.Up)
                && previous.IsKeyUp(Keys.Up);
        }

        public bool isRUpHeld()
        {
            return current.IsKeyDown(Keys.Up);
        }

        public bool isRDownPressed()
        {
            return current.IsKeyDown(Keys.Down)
                && previous.IsKeyUp(Keys.Down);            
        }

        public bool isRDownHeld()
        {
            return current.IsKeyDown(Keys.Down);
        }

        public bool isRLeftPressed()
        {
            return current.IsKeyDown(Keys.Left)
                && previous.IsKeyUp(Keys.Left);
        }

        public bool isRLeftHeld()
        {
            return current.IsKeyDown(Keys.Left);
        }

        public bool isRRightPressed()
        {
            return current.IsKeyDown(Keys.Right)
                && previous.IsKeyUp(Keys.Right);
        }

        public bool isRRightHeld()
        {
            return current.IsKeyDown(Keys.Right);
        }

        public bool isLUpPressed()
        {
            return current.IsKeyDown(Keys.W)
                && previous.IsKeyUp(Keys.W);
        }

        public bool isLUpHeld()
        {
            return current.IsKeyDown(Keys.W);
        }

        public bool isLDownPressed()
        {
            return current.IsKeyDown(Keys.S)
                && previous.IsKeyUp(Keys.S);
        }

        public bool isLDownHeld()
        {
            return current.IsKeyDown(Keys.S);
        }

        public bool isLLeftPressed()
        {
            return current.IsKeyDown(Keys.A)
                && previous.IsKeyUp(Keys.A);
        }

        public bool isLLeftHeld()
        {
            return current.IsKeyDown(Keys.A);
        }

        public bool isLRightPressed()
        {
            return current.IsKeyDown(Keys.D)
                && previous.IsKeyUp(Keys.D);
        }

        public bool isLRightHeld()
        {
            return current.IsKeyDown(Keys.D);
        }

        public bool isActionAPressed()
        {
            return current.IsKeyDown(Keys.Space)
                && previous.IsKeyUp(Keys.Space);
        }

        public bool isActionAHeld()
        {
            return current.IsKeyDown(Keys.Space);
        }

        public bool isActionBPressed()
        {
            return current.IsKeyDown(Keys.LeftControl)
                && previous.IsKeyUp(Keys.LeftControl);
        }

        public bool isActionBHeld()
        {
            return current.IsKeyDown(Keys.LeftControl);
        }

        public bool isActionCPressed()
        {
            return current.IsKeyDown(Keys.LeftAlt)
                && previous.IsKeyUp(Keys.LeftAlt);
        }

        public bool isActionCHeld()
        {
            return current.IsKeyDown(Keys.LeftAlt);
        }

        public bool isActionDPressed()
        {
            return current.IsKeyDown(Keys.E)
                && previous.IsKeyUp(Keys.E);
        }

        public bool isActionDHeld()
        {
            return current.IsKeyDown(Keys.E);
        }
    }
}
