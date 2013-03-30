﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Component
{
    public class EntityModelComponent : BaseComponent
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
