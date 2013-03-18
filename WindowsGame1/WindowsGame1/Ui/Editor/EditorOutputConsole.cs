using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TheGameOfForever.Ui.Font;

namespace TheGameOfForever.Ui.Editor
{
    public class OutputConsole
    {
        private static List<String> consoleOutput = new List<string>();

        public static void writeLn(String message)
        {
            consoleOutput.Add(message);
        }

        public static void draw(SpriteBatch spriteBatch, int number, Vector2 location, int colCount)
        {
            for (int i = (int)MathHelper.Max(0, consoleOutput.Count - number); i < consoleOutput.Count; i++)
            {
                DrawStringHelper.drawString(spriteBatch, consoleOutput[i], "mentone", 10,
                    Color.Black, new Vector2(location.X, location.Y + (i - (int)MathHelper.Max(0, consoleOutput.Count - number)) * 12));
            }
        }
    }
}
