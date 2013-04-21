using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Service.Shapes;
using Microsoft.Xna.Framework;
using TheGameOfForever.Geometry;
using TheGameOfForever.Ui.Editor;

namespace TheGameOfForever.Service
{
    public class CollisionService : AbstractGameService
    {
        public CollisionService(EntityManager entityManager)
            : base(entityManager)
        {
            subscribeToComponentGroup(typeof(Selected), typeof(CollisionHitBox));
            subscribeToComponentGroup(typeof(CollisionHitBox));
        }

        public override void update(Microsoft.Xna.Framework.GameTime gameTime, GameState.AbstractGameState gameState)
        {
            int selectedId = entityIds[0].getLast();
            if (selectedId == -1) return;
            Entity entity = entityManager.getEntity(selectedId);
            CollisionHitBox selectedHitBox = entity.getComponent<CollisionHitBox>();
            LocationComponent selectedLocation = entity.getComponent<LocationComponent>();
            List<IShape> collisionShapes = selectedHitBox.getCollisionShapes();

            foreach (int id in entityIds[1])
            {
                if (id == selectedId) continue;
                Entity entityToCollide = entityManager.getEntity(id);
                CollisionHitBox toCollideHitBox = entityToCollide.getComponent<CollisionHitBox>();
                LocationComponent toCollideLocation = entityToCollide.getComponent<LocationComponent>();

                foreach (IShape collisionShape in collisionShapes)
                {
                    collisionShape.setLocation(selectedLocation.getCurrentLocation());
                    collisionShape.setRotation(selectedLocation.getFacingRadians());
                    foreach (IShape collisionShape2 in toCollideHitBox.getCollisionShapes())
                    {
                        collisionShape2.setLocation(toCollideLocation.getCurrentLocation());
                        collisionShape2.setRotation(toCollideLocation.getFacingRadians());
                        Vector2 repluseForce = CollisionHelper.collide(collisionShape, collisionShape2);
                        selectedLocation.setCurrentLocation(selectedLocation.getCurrentLocation() + repluseForce);
                    }
                }

            }
        }

        public override void draw(GameTime gameTime, GameState.AbstractGameState gameState, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            foreach (int id in entityIds[1])
            {
                Entity entityToCollide = entityManager.getEntity(id);
                CollisionHitBox toCollideHitBox = entityToCollide.getComponent<CollisionHitBox>();
                foreach (IShape collisionShape in toCollideHitBox.getCollisionShapes())
                {
                    if (collisionShape is RectangleShape)
                    {
                        RectangleShape shape = ((RectangleShape)collisionShape);
                        spriteBatch.Draw(EditorContent.blank, shape.getRectangle(), null, Color.Orange * 0.4f, shape.getRotation(),
                            shape.getRotatePoint() / new Vector2(shape.getRectangle().Width, shape.getRectangle().Height), Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 1);
                    }
                }
            }
        }
    }
}
