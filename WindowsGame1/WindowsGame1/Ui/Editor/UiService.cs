using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Ui.Editor
{
    public class UiService
    {
        public bool propagateClicks;
        private List<IClickable> clickables = new List<IClickable>();

        public void registerClickable(IClickable clickable)
        {
            clickables.Add(clickable);
        }

        public void stopPropagation()
        {
            propagateClicks = false;
        }

        public void update()
        {
            propagateClicks = true;
            for (int i = clickables.Count - 1; i >= 0; i--)
            {
                clickables[i].hasClicked();
            }
        }

    }
}
