using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace TheGameOfForever.Control
{
    public class GamepadControl : IControl
    {
        private static GamePadState current = GamePad.GetState(0);
        private static GamePadState previous = GamePad.GetState(0);

        public void updateCurrent()
        {
            GamepadControl.current = GamePad.GetState(0);
        }

        public void updateLast()
        {
            GamepadControl.previous = current;
        }

        public bool isRUpPressed()
        {
            return current.ThumbSticks.Right.Y == 1.0f
                && previous.ThumbSticks.Right.Y != 1.0f;
        }

        public bool isRUpHeld()
        {
            return current.ThumbSticks.Right.Y == 1.0f;
        }

        public bool isRDownPressed()
        {
            return current.ThumbSticks.Right.Y == -1.0f
                && previous.ThumbSticks.Right.Y != -1.0f;            
        }

        public bool isRDownHeld()
        {
            return current.ThumbSticks.Right.Y == -1.0f;
        }

        public bool isRLeftPressed()
        {
            return current.ThumbSticks.Right.X == -1.0f
                && previous.ThumbSticks.Right.X != -1.0f;  
        }

        public bool isRLeftHeld()
        {
            return current.ThumbSticks.Right.X == -1.0f;
        }

        public bool isRRightPressed()
        {
            return current.ThumbSticks.Right.X == 1.0f
                && previous.ThumbSticks.Right.X != 1.0f;  
        }

        public bool isRRightHeld()
        {
            return current.ThumbSticks.Right.X == 1.0f;
        }

        public bool isLUpPressed()
        {
            return current.ThumbSticks.Left.Y == 1.0f
                && previous.ThumbSticks.Left.Y != 1.0f;  
        }

        public bool isLUpHeld()
        {
            return current.ThumbSticks.Left.Y == 1.0f;
        }

        public bool isLDownPressed()
        {
            return current.ThumbSticks.Left.Y == -1.0f
                && previous.ThumbSticks.Left.Y != -1.0f;  
        }

        public bool isLDownHeld()
        {
            return current.ThumbSticks.Left.Y == -1.0f;
        }

        public bool isLLeftPressed()
        {
            return current.ThumbSticks.Left.X == -1.0f
                && previous.ThumbSticks.Left.X != -1.0f;  
        }

        public bool isLLeftHeld()
        {
            return current.ThumbSticks.Left.X == -1.0f;
        }

        public bool isLRightPressed()
        {
            return current.ThumbSticks.Left.X == 1.0f
                && previous.ThumbSticks.Left.X != 1.0f;  
        }

        public bool isLRightHeld()
        {
            return current.ThumbSticks.Left.X == 1.0f;
        }

        public bool isActionAPressed()
        {
            return current.Buttons.A == ButtonState.Pressed
                && previous.Buttons.A == ButtonState.Released;
        }

        public bool isActionAHeld()
        {
            return current.Buttons.A == ButtonState.Pressed;
        }

        public bool isActionBPressed()
        {
            return current.Buttons.LeftShoulder == ButtonState.Pressed
                && previous.Buttons.LeftShoulder == ButtonState.Released;
        }

        public bool isActionBHeld()
        {
            return current.Buttons.LeftShoulder == ButtonState.Pressed;
        }

        public bool isActionCPressed()
        {
            return current.Triggers.Right == 1.0f
                && previous.Triggers.Right != 1.0f;
        }

        public bool isActionCHeld()
        {
            return current.Triggers.Right == 1.0f;
        }

        public bool isActionDPressed()
        {
            return current.Buttons.B == ButtonState.Pressed
                && previous.Buttons.B == ButtonState.Released;
        }

        public bool isActionDHeld()
        {
            return current.Buttons.B == ButtonState.Pressed;
        }

        public bool isActionEPressed()
        {
            throw new NotImplementedException();
        }

        public bool isActionEHeld()
        {
            throw new NotImplementedException();
        }
    }
}
