using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Processor.Content.Models;

namespace TheGameOfForever.Service
{
    public class UnitDrawService : AbstractGameService
    {
        public UnitDrawService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(EntityModelComponent));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            foreach (int id in this.entityIds)
            {
                Entity entity = entityManager.getEntity(id);
                ModelDefinition model = ModelLibrary.getModelFromId(entity.getComponent<EntityModelComponent>()
                    .getModelId());
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();
                spriteBatch.Draw(model.getSpriteSheet(), locationComponent.getCurrentLocation(), model.getSourceRectangle(), Color.White, 
                    locationComponent.getFacingRadians(), model.getOrigin(), model.getScale(), SpriteEffects.None, 1);
            }
        }
    }
}
