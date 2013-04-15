using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.Component
{
    public class EntityModelComponent
    {
        int modelId;

        public EntityModelComponent(int modelId)
        {
            this.modelId = modelId;
        }

        public int getModelId()
        {
            return modelId;
        }
    }
}
