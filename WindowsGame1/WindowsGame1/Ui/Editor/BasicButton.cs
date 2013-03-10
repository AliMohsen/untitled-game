using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Ui.Font;

namespace TheGameOfForever.Ui.Editor
{
    public class BasicButton
    {
        FontFactory fontFactory = FontFactory.getInstance();

        Rectangle box;
        public string name;
        bool hover;
        bool clicked;

        public BasicButton(Rectangle box, string name)
        {
            this.box = box;
            this.name = name;
        }

        public Vector2 Location
        {
            get { return new Vector2(box.X, box.Y); }
        }

        MouseState lastState = Mouse.GetState();

        public bool hasClicked()
        {
            if (box.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
            {
                hover = true;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    clicked = true;
                    if (lastState.LeftButton == ButtonState.Released)
                    {
                        lastState = Mouse.GetState();
                        return true;
                    }
                }
                else clicked = false;
            }
            else hover = false;

            lastState = Mouse.GetState();
            return false;
        }

        public void draw(SpriteBatch sprite)
        {
            if (clicked)
            {
                sprite.Draw(EditorContent.blank, box, Color.Orange);
                sprite.DrawString(fontFactory.getFont("Mentone").getSize(12), name, new Vector2(box.X, box.Y), Color.Green);
            }
            else if (hover)
            {
                sprite.Draw(EditorContent.blank, box, new Color(0, 0, 0, 1));
                sprite.DrawString(fontFactory.getFont("Mentone").getSize(12), name, new Vector2(box.X, box.Y), Color.White);
            }
            else
            {
                sprite.Draw(EditorContent.blank, box, new Color(1, 1, 1, 1f));
                sprite.DrawString(fontFactory.getFont("Mentone").getSize(12), name, new Vector2(box.X, box.Y), Color.Black);
            }
        }

    }
}
