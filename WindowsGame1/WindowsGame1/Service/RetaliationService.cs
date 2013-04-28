using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;
using TheGameOfForever.Geometry;
using TheGameOfForever.Configuration.Weapon;
using TheGameOfForever.Service.Shapes;
using TheGameOfForever.GameState;

namespace TheGameOfForever.Service
{
    public class RetaliationService : AbstractGameService
    {
        public interface Observer
        {
            void handleEndRetaliation();
        }

        public RetaliationService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(RetaliateComponent));
            subscribeToComponentGroup(typeof(IsProjectile));
            subscribeToComponentGroup(typeof(Selected));
            subscribeToComponentGroup(typeof(IsFiring));
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            if (entityIds[0].count() == 0)
            {
                ((Observer)gameState).handleEndRetaliation();
            } else if (entityIds[3].count() == 0)
            // Select the most damaged.
            {
                int mostDamaged = entityIds[0].ElementAt(0);
                for (int i = 1; i < entityIds[0].count(); i++)
                {
                    RetaliateComponent r1 = entityManager.getEntity(mostDamaged).getComponent<RetaliateComponent>();
                    RetaliateComponent r2 = entityManager.getEntity(entityIds[0].ElementAt(i)).getComponent<RetaliateComponent>();

                    if (r1.getDamage() < r2.getDamage()) mostDamaged = i;
                }

                Entity attacker = entityManager.getEntity(mostDamaged);
                LocationComponent locationComponent = attacker.getComponent<LocationComponent>();

                Entity target = entityManager.getEntity(entityIds[2].getLast());
                Vector2 newTargetLocation = target.getComponent<LocationComponent>().getCurrentLocation();

                locationComponent.setFacingRadians(GeometryHelper.CalculateAngle(newTargetLocation, locationComponent.getCurrentLocation()));
                // Most damage now firing.
                attacker.addComponent(new IsFiring());
            }
            else if (!entityManager.getEntity(entityIds[3].getLast()).getComponent<IsFiring>().getCompleted())
            {
                Entity entity = entityManager.getEntity(entityIds[3].getLast());
                LocationComponent locationComponent = entity.getComponent<LocationComponent>();
                WeaponStats heldWeapon = WeaponLibrary.getWeaponFromId(
                    entity.getComponent<ArsenalComponent>().getCurrentWeaponId());
                
                int shotsPerTurn = heldWeapon.getShotsPerTurn();
                long timeBetweenShots = heldWeapon.getTimeBetweenShots();
                int shotsFired = entity.getComponent<IsFiring>().getShotsFired();
                long time = entity.getComponent<IsFiring>().getTimeSinceFirstShot();
                
                entity.getComponent<IsFiring>().setTimeSinceFirstShot(time + gameTime.ElapsedGameTime.Milliseconds);

                if (shotsFired < shotsPerTurn)
                {
                    if (time > timeBetweenShots * shotsFired)
                    {
                        float unitDirection = locationComponent.getFacingRadians();
                        Vector2 unitLocation = locationComponent.getCurrentLocation();

                        float weaponAcc = heldWeapon.getAccuracy();
                        float maximum = weaponAcc / 2;
                        float minimum = -weaponAcc / 2;
                        float bulletDirection = GeometryHelper.getRandomFloat(minimum, maximum);

                        List<BaseComponent> components = new List<BaseComponent>();
                        components.Add(new LocationComponent(unitLocation, bulletDirection));
                        components.Add(new MovementComponent(4,
                            4 * Vector2.Normalize(GeometryHelper.rotateVec(new Vector2(0, 1), bulletDirection + unitDirection))));
                        components.Add(new IsProjectile(100, true, 100));
                        components.Add(new CollisionHitBox(new RectangleShape(new Rectangle((int)unitLocation.X, (int)unitLocation.Y, 10, 10), new Vector2(5f), 0, 10)));

                        entityManager.addEntity(Entity.EntityFactory.createEntityWithComponents(components));
                        entity.getComponent<IsFiring>().incrementShotsFired();
                    }
                }
                else
                {
                    if (entityIds[1].count() == 0)
                    {
                        foreach (int id in entityIds[0])
                        {
                            entityManager.getEntity(id).removeComponent<RetaliateComponent>();
                        }
                        entity.removeComponent<IsFiring>();
                        ((Observer)gameState).handleEndRetaliation();
                    }
                }
            }
        }
    }
}
