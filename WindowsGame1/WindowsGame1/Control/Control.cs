using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Control
{
    public class Control
    {
        private static IControl instance;
        private static ControllerType type;

        private Control() { }

        public static IControl Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KeyboardControl();
                }
                return instance;
            }
        }

        public static void selectType(ControllerType type)
        {
            if (type == ControllerType.GAMEPAD)
            {
                instance = new KeyboardControl();
            }
            else if (type == ControllerType.KEYBOARD)
            {
                instance = new GamepadControl();
            }
        }

        public enum ControllerType
        {
            GAMEPAD,
            KEYBOARD
        }
    }
}
