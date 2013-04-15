using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class EntityTextureComponent : BaseComponent
    {
        int textureId;

        public EntityTextureComponent(int textureId)
        {
            this.textureId = textureId;
        }

        public int getTextureId()
        {
            return textureId;
        }
    }
}
