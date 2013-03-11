﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Ui.Font;

namespace TheGameOfForever.Ui.Editor
{
    public class BasicButton : IClickable
    {
        FontFactory fontFactory = FontFactory.getInstance();

        Rectangle box;
        public string displayName;
        bool hover;
        bool clicked;
        UiService uiService;

        public BasicButton(UiService uiService, Rectangle box, string displayName)
        {
            this.uiService = uiService;
            this.box = box;
            this.displayName = displayName;
            uiService.registerClickable(this);
        }

        public Vector2 Location
        {
            get { return new Vector2(box.X, box.Y); }
        }

        MouseState lastState = Mouse.GetState();

        public delegate void HandleMouseClick();
        private List<HandleMouseClick> handleMouseClickHandlers = new List<HandleMouseClick>();

        public void addHandler(HandleMouseClick handleMouseClick)
        {
            this.handleMouseClickHandlers.Add(handleMouseClick);
        }

        public void clearHandlers()
        {
            handleMouseClickHandlers.Clear();
        }

        public void hasClicked()
        {
            if (box.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1))
                && uiService.propagateClicks)
            {
                hover = true;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    clicked = true;
                    if (lastState.LeftButton == ButtonState.Released)
                    {
                        lastState = Mouse.GetState();
                        foreach (HandleMouseClick handler in handleMouseClickHandlers)
                        {
                            handler();
                        }
                    }
                }
                else clicked = false;
                uiService.stopPropagation();
            }
            else hover = false;

            lastState = Mouse.GetState();
        }

        private float hoverAlpha = 1;

        public void draw(SpriteBatch sprite)
        {
            Color bgColor;
            Color underlineColor;
            Color textColor;

            if (clicked)
            {
                bgColor = new Color(0.95f, 0.95f, 0.95f);
                underlineColor = textColor = Color.DeepSkyBlue;
            }
            else if (hover)
            {
                hoverAlpha = MathHelper.SmoothStep(hoverAlpha, 0.95f, 0.25f);
                bgColor = new Color(hoverAlpha, hoverAlpha, hoverAlpha);
                underlineColor = textColor = Color.SlateGray;
            }
            else
            {
                hoverAlpha = MathHelper.SmoothStep(hoverAlpha, 1f, 0.25f);
                bgColor = Color.White;
                underlineColor = textColor = Color.SlateGray;
            }
            sprite.Draw(EditorContent.blank, box, bgColor);
            DrawStringHelper.drawString(sprite, displayName, "mentone", 10, textColor, new Vector2(box.X + box.Width / 2, box.Y + 2), Alignment.CENTERED);
            sprite.Draw(EditorContent.blank, new Rectangle(box.X, box.Y + box.Height, box.Width, 1), underlineColor);
            sprite.Draw(EditorContent.blank, new Rectangle(box.X + 1, box.Y + box.Height, 1, box.Height / 3), new Rectangle(0, 0, 1, 1), underlineColor, MathHelper.Pi, Vector2.Zero, SpriteEffects.None, 1);
            sprite.Draw(EditorContent.blank, new Rectangle(box.X + box.Width, box.Y + box.Height, 1, box.Height / 3), new Rectangle(0,0,1,1), underlineColor, MathHelper.Pi, Vector2.Zero, SpriteEffects.None, 1);
        }

    }
}
