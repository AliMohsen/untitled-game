using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class StatusDrawComponent : BaseComponent
    {
        public List<String> messages = new List<string>();
        public List<Color> colors = new List<Color>();
        public List<long> millisToDisplays = new List<long>();
        public List<long> millisLefts = new List<long>();

        public void addEntry(String message, Color color, long millisToDisplay)
        {
            messages.Add(message);
            colors.Add(color);
            millisToDisplays.Add(millisToDisplay);
            millisLefts.Add(millisToDisplay);
        }

        public Tuple<string, Color, long, long> getEntry(int index)
        {
            return Tuple.Create<string, Color, long, long>(
                messages[index], colors[index], millisToDisplays[index], millisLefts[index]);
        }

        public List<long> getMillisLeft()
        {
            return millisLefts;
        }

        public void removeAt(int index)
        {
            messages.RemoveAt(index);
            colors.RemoveAt(index);
            millisToDisplays.RemoveAt(index);
            millisLefts.RemoveAt(index);
        }

        internal int getCount()
        {
            return messages.Count;
        }
    }
}
