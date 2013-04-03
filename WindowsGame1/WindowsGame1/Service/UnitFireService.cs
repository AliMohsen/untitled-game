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
using TheGameOfForever.Processor.Content.Models;

namespace TheGameOfForever.Service
{
    class UnitFireService : AbstractGameService
    {
        public UnitFireService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(IsProjectile));
            subscribeToComponentGroup(typeof(Controllable));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            IControl control = DefaultControl.Instance;
            EngageState state = (EngageState)gameState;

            foreach (int id in entityIds)
            {
                Entity entity = entityManager.getEntity(id);
                if (entity.hasComponent<IsProjectile>())
                {
                    Vector2 location = entity.getComponent<LocationComponent>().getCurrentLocation();
                    Vector2 nextLocation = location + entity.getComponent<MovementComponent>().getVelocity();
                    entity.getComponent<LocationComponent>().setCurrentLocation(nextLocation);
                }
            }

            if (control.isActionBPressed())
            {

                HashSet<int> newEntityIds = new HashSet<int>();

                foreach (int id in entityIds)
                {
                    Entity entity = entityManager.getEntity(id);
                    if (!entity.hasComponent<IsProjectile>())
                    {
                        newEntityIds.Add(id);
                    }
                }
                entityIds = newEntityIds;
                state.disengage();
            }

            if (control.isActionAPressed())
            {
                Entity unit = entityManager.getEntity(state.getEntityId());
                Vector2 unitLocation = unit.getComponent<LocationComponent>().getCurrentLocation();
                float unitDirection = unit.getComponent<LocationComponent>().getFacingRadians();

                List<BaseComponent> components = new List<BaseComponent>();
                components.Add(new LocationComponent(unitLocation, unitDirection));
                float x = (float)Math.Cos(unitDirection);
                float y = (float)Math.Sin(unitDirection);
                components.Add(new MovementComponent(10, new Vector2(x, y) * 10));
                components.Add(new IsProjectile(100, true));
                
                entityManager.addEntity(Entity.EntityFactory.createEntityWithComponents(components));
            }
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            EngageState state = (EngageState)gameState;
            Entity unit = entityManager.getEntity(state.getEntityId());
            Vector2 location = unit.getComponent<LocationComponent>().getCurrentLocation();

            spriteBatch.Draw(EditorContent.blank, location, new Rectangle(0, 0, 1, 1), Color.Blue,
                (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);

            foreach (int id in entityIds)
            {
                Entity entity = entityManager.getEntity(id);
                if (entity.hasComponent<IsProjectile>())
                {
                    spriteBatch.Draw(EditorContent.blank, entity.getComponent<LocationComponent>().getCurrentLocation(), new Rectangle(0, 0, 1, 1), Color.HotPink,
                        (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);
                }
            }
        }
    }
}
