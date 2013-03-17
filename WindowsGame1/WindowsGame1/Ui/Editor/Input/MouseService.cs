using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace TheGameOfForever.Ui.Editor.Input
{
    public class MouseService
    {
        private static MouseState current = Mouse.GetState();
        private static MouseState previous = Mouse.GetState();

        public MouseService() { }

        public void updateCurrent()
        {
            MouseService.current = Mouse.GetState();
        }

        public void updateLast()
        {
            MouseService.previous = current;
        }

        public static bool isLeftClicked()
        {
            return current.LeftButton == ButtonState.Pressed 
                && previous.LeftButton == ButtonState.Released;
        }

        public static bool isRightClicked()
        {
            return current.RightButton == ButtonState.Pressed
                && previous.RightButton == ButtonState.Released;
        }

        public static bool isLeftPressed()
        {
            return current.LeftButton == ButtonState.Pressed;
        }

        public static bool isRightPressed()
        {
            return current.RightButton == ButtonState.Pressed;
        }

        public static int getX()
        {
            return current.X;
        }

        public static int getY()
        {
            return current.Y;
        }
    }
}
