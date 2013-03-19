using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service
{
    public interface IGameService
    {
        public void registerEntityIfNeeded(Entity entity);
        public void unregisterEntity(Entity entity);

        public void update(GameTime gameTime);
    }
}
