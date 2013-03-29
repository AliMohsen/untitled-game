using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Control;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Service
{
    class UnitFireService : AbstractGameService
    {
        public UnitFireService(EntityManager entityManager)
            : base(entityManager)
        {

        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            IControl control = DefaultControl.Instance;
            EngageState state = (EngageState)gameState;

            if (control.isActionBPressed())
            {
                state.disengage();
            }
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            EngageState state = (EngageState)gameState;
            Entity entity = entityManager.getEntity(state.getControlId());
            Vector2 location = entity.getComponent<LocationComponent>().getCurrentLocation();

            spriteBatch.Draw(EditorContent.blank, location, new Rectangle(0, 0, 1, 1), Color.Blue,
                (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);          
        }
    }
}
