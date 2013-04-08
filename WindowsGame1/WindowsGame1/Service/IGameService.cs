using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;

namespace TheGameOfForever.Service
{
    public interface IGameService
    {
        void registerEntityIfNeeded(Entity entity);
        void refreshEntity(Entity entity);
        void removeEntity(Entity entity);

        void update(GameTime gameTime, AbstractGameState gameState);
    }
}
