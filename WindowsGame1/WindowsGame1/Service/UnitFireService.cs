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
using TheGameOfForever.Configuration.Weapon;
using TheGameOfForever.Geometry;

namespace TheGameOfForever.Service
{
    class UnitFireService : AbstractGameService
    {
        Random rand = new Random();

        public UnitFireService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(IsProjectile));
            subscribeToComponentGroup(typeof(Controllable));
            subscribeToComponentGroup(typeof(Selected));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            IControl control = DefaultControl.Instance;
            EngageState state = (EngageState)gameState;

            Entity entity = entityManager.getEntity(entityIds[2].getLast());
            LocationComponent locationComponent = entity.getComponent<LocationComponent>();           
            MovementComponent movementComponent = entity.getComponent<MovementComponent>();

            if (control.isActionBPressed())
            {
                int[] entityIdsUnchanged = entityIds[0].ToArray<int>();

                foreach (int id2 in entityIdsUnchanged)
                {
                    entityManager.removeEntity(id2);
                }
                state.disengage();
            }

            if (control.isLLeftHeld())
            {
                locationComponent.setFacingRadians(entity.getComponent<LocationComponent>().getFacingRadians()
                    - movementComponent.getTurningSpeed(gameTime));
            }
            else if (control.isLRightHeld())
            {
                locationComponent.setFacingRadians(entity.getComponent<LocationComponent>().getFacingRadians()
                    + movementComponent.getTurningSpeed(gameTime));
            }
            else if (control.isActionAPressed() || control.isActionAHeld())
            {
                float unitDirection = locationComponent.getFacingRadians();
                Vector2 unitLocation = locationComponent.getCurrentLocation();
                
                int heldWeaponId = entity.getComponent<ArsenalComponent>().getCurrentWeaponId();
                float weaponAcc = WeaponLibrary.getWeaponFromId(heldWeaponId).getAccuracy();
                float maximum = weaponAcc / 2;
                float minimum = -weaponAcc / 2;
                float bulletDirection = GeometryHelper.getRandomFloat(minimum, maximum);

                List<BaseComponent> components = new List<BaseComponent>();
                components.Add(new LocationComponent(unitLocation, bulletDirection));
                components.Add(new MovementComponent(10, 
                    GeometryHelper.rotateVec(new Vector2(0, 1), bulletDirection + unitDirection) * 10));
                components.Add(new IsProjectile(100, true));

                entityManager.addEntity(Entity.EntityFactory.createEntityWithComponents(components));
            }
        }

        public override void draw(GameTime gameTime, AbstractGameState gameState, SpriteBatch spriteBatch)
        {
            Entity unit = null;
            int id = entityIds[2].getLast();
            unit = entityManager.getEntity(id);

            Vector2 location = unit.getComponent<LocationComponent>().getCurrentLocation();
            float direction = unit.getComponent<LocationComponent>().getFacingRadians();

            spriteBatch.Draw(EditorContent.blank, location, new Rectangle(0, 0, 1, 1), Color.Blue,
                (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);

            Rectangle leftLine = new Rectangle(0, 0, 1, 500);
            Rectangle rightLine = new Rectangle(0, 0, 1, 500);

            int heldWeaponId = unit.getComponent<ArsenalComponent>().getCurrentWeaponId();
            float weaponAcc = WeaponLibrary.getWeaponFromId(heldWeaponId).getAccuracy();

            float leftAngle = - weaponAcc / 2;
            float rightAngle = weaponAcc / 2;

            spriteBatch.Draw(EditorContent.blank, unit.getComponent<LocationComponent>().getCurrentLocation(), leftLine,
                Color.DarkGray, leftAngle + direction, new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);
            spriteBatch.Draw(EditorContent.blank, unit.getComponent<LocationComponent>().getCurrentLocation(), rightLine,
                Color.DarkGray, rightAngle + direction, new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);
            spriteBatch.Draw(EditorContent.blank, unit.getComponent<LocationComponent>().getCurrentLocation(), rightLine,
                Color.DarkGray, direction , new Vector2(0.5f), new Vector2(1), SpriteEffects.None, 1);

            foreach (int id2 in entityIds[0])
            {
                Entity entity = entityManager.getEntity(id2);
                spriteBatch.Draw(EditorContent.blank,
                    entity.getComponent<LocationComponent>().getCurrentLocation(), new Rectangle(0, 0, 1, 1), Color.HotPink,
                    (float)Math.PI / 2, new Vector2(0.5f), new Vector2(5), SpriteEffects.None, 1);

            }
        }
    }
}
