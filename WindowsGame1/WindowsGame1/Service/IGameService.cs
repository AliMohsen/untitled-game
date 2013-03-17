using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;

namespace TheGameOfForever.Service
{
    public interface IGameService
    {
        void registerEntityIfNeeded(Entity entity);
        void unregisterEntity(Entity entity);
    }
}
