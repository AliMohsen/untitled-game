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
        Random rand = new Random();
        float weaponAcc = (float)Math.PI / 18;

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

            if (control.isActionAPressed() || control.isActionAHeld())
            {
                Entity unit = entityManager.getEntity(state.getEntityId());
                Vector2 unitLocation = unit.getComponent<LocationComponent>().getCurrentLocation();
                float unitDirection = unit.getComponent<LocationComponent>().getFacingRadians();

                float maximum = weaponAcc / 2;
                float minimum = -weaponAcc / 2;

                float bulletDirection = (float)rand.NextDouble() * (maximum - minimum) + minimum;

                List<BaseComponent> components = new List<BaseComponent>();
                components.Add(new LocationComponent(unitLocation, bulletDirection));
                float x = (float)Math.Cos(bulletDirection + unitDirection);
                float y = (float)Math.Sin(bulletDirection + unitDirection);
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
            float direction = unit.getComponent<LocationComponent>().getFacingRadians();

            spriteBatch.Draw(EditorContent.blank, location, new Rectangle(0, 0, 1, 1), Color.Blue,
                (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);

            Rectangle leftLine = new Rectangle(0, 0, 500, 1);
            Rectangle rightLine = new Rectangle(0, 0, 500, 1);

            float leftAngle = - weaponAcc / 2;
            float rightAngle = weaponAcc / 2;

            spriteBatch.Draw(EditorContent.blank, unit.getComponent<LocationComponent>().getCurrentLocation(), leftLine, Color.Black, leftAngle + direction, new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);
            spriteBatch.Draw(EditorContent.blank, unit.getComponent<LocationComponent>().getCurrentLocation(), rightLine, Color.Black, rightAngle + direction, new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);

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
