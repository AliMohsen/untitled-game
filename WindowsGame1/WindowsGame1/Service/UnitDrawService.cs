using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Processor.Content.Textures;
using TheGameOfForever.Draw;

namespace TheGameOfForever.Service
{
    public class UnitDrawService : AbstractGameService
    {
        public UnitDrawService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(EntityTextureComponent)); // 0
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            foreach (int id in this.entityIds[0])
            {
                Entity entity = entityManager.getEntity(id);
                TextureDefinition model = TextureLibrary.getTextureFromId(entity.getComponent<EntityTextureComponent>()
                    .getTextureId());
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();
                SpriteBatchWrapper.DrawGame(model.getSpriteSheet(), locationComponent.getCurrentLocation(), model.getSourceRectangle(), Color.White, 
                    locationComponent.getFacingRadians(), model.getOrigin(), model.getScale(), SpriteEffects.None, 1);
            }
        }
    }
}
