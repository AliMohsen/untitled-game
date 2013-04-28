using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Service.Shapes;
using TheGameOfForever.Geometry;
using Microsoft.Xna.Framework;
using TheGameOfForever.Draw;
using TheGameOfForever.Ui.Editor;
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.GameState;

namespace TheGameOfForever.Service
{
    class ProjectileCollisionService : AbstractGameService
    {
        public ProjectileCollisionService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(IsProjectile));
            subscribeToComponentGroup(typeof(CollisionHitBox));
            subscribeToComponentGroup(typeof(IsFiring));
        }
        
        public override void update(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState gameState)
        {
            HashSet<int> toRemove = new HashSet<int>();
            foreach (int id in entityIds[0])
            {
                Entity projectile = entityManager.getEntity(id);
                CollisionHitBox projectileHitBox = projectile.getComponent<CollisionHitBox>();
                LocationComponent projectileLocation = projectile.getComponent<LocationComponent>();
                Vector2 currentLocation = projectileLocation.getCurrentLocation();
                Vector2 lastLocation = projectileLocation.getLastLocation();
                List<IShape> collisionShapes = projectileHitBox.getCollisionShapes();

                foreach (int id2 in entityIds[1])
                {
                    Entity entityToCollide = entityManager.getEntity(id2);
                    bool hit = false;
                    if (entityToCollide.hasComponent<IsProjectile>()) continue;
                    if (entityToCollide.getId() == entityIds[2].getLast()) continue;

                    CollisionHitBox toCollideHitBox = entityToCollide.getComponent<CollisionHitBox>();
                    LocationComponent toCollideLocation = entityToCollide.getComponent<LocationComponent>();
                    foreach (RectangleShape collisionShape in collisionShapes)
                    {
                        if (hit) continue;
                        if (projectileLocation != null)
                        {
                            collisionShape.setRectangle(new Rectangle((int)currentLocation.X, (int)currentLocation.Y,
                                10,10));
                            collisionShape.setRotation(projectileLocation.getFacingRadians());
                        }

                        foreach (IShape collisionShape2 in toCollideHitBox.getCollisionShapes())
                        {
                            if (hit) continue;
                            if (toCollideLocation != null)
                            {
                                collisionShape2.setLocation(toCollideLocation.getCurrentLocation());
                                collisionShape2.setRotation(toCollideLocation.getFacingRadians());
                            }
                            
                            Vector2 repluseForce = CollisionHelper.collide(collisionShape, collisionShape2);
                            if (projectileLocation != null)
                            {
                                //projectileLocation.setCurrentLocation(projectileLocation.getCurrentLocation() + repluseForce);
                            }
                            if (repluseForce.LengthSquared() > 0 && entityToCollide.hasComponent<DamageComponent>())
                            {
                                int damage = projectile.getComponent<IsProjectile>().getDamage();
                                entityToCollide.getComponent<DamageComponent>().addDamage(damage);

                                if (!entityToCollide.hasComponent<RetaliateComponent>())
                                {
                                    entityToCollide.addComponent(new RetaliateComponent());
                                }
                                entityToCollide.getComponent<RetaliateComponent>().addDamage(damage);

                                toRemove.Add(projectile.getId());
                                hit = true;
                            }
                        }
                    }
                }
            }
            foreach (int i in toRemove)
            {
                entityManager.removeEntity(i);
            }
        }

        public override void draw(GameTime gameTime, GameState.AbstractGameState gameState, SpriteBatch spriteBatch)
        {
/*
            foreach (int id in entityIds[0])
            {
                Entity entityToCollide = entityManager.getEntity(id);
                CollisionHitBox toCollideHitBox = entityToCollide.getComponent<CollisionHitBox>();
                foreach (IShape collisionShape in toCollideHitBox.getCollisionShapes())
                {
                    if (collisionShape is RectangleShape)
                    {
                        RectangleShape shape = ((RectangleShape)collisionShape);
                        SpriteBatchWrapper.DrawGame(EditorContent.blank, shape.getLocation(), shape.getRectangle(), Color.Orange * 0.4f, shape.getRotation(),
                            shape.getRotatePoint() / new Vector2(shape.getRectangle().Width, shape.getRectangle().Height), new Vector2(1), SpriteEffects.None, 1.1f);
                    }
                }
            }
 */
        }
    }
}
