using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework.Graphics;

namespace TheGameOfForever.Service
{
    public interface IGameService
    {
        void registerEntityIfNeeded(Entity entity);
        void refreshEntity(Entity entity);
        void removeEntity(Entity entity);
        void refresh();
        void update(GameTime gameTime, AbstractGameState gameState);
        void refreshEntities();
        void draw3d(GameTime gameTime, AbstractGameState gameState, GraphicsDevice device);
    }
}
