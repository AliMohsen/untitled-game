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
using Microsoft.Xna.Framework.Graphics;
using TheGameOfForever.Draw;

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
            if (entityIds[0].count() == 0) return;
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
                    if (selectedLocation != null)
                    {
                        collisionShape.setLocation(selectedLocation.getCurrentLocation());
                        collisionShape.setRotation(selectedLocation.getFacingRadians());
                    }
                    foreach (IShape collisionShape2 in toCollideHitBox.getCollisionShapes())
                    {

                        if (toCollideLocation != null)
                        {
                            collisionShape2.setLocation(toCollideLocation.getCurrentLocation());
                            collisionShape2.setRotation(toCollideLocation.getFacingRadians());
                        }
                        Vector2 repluseForce = CollisionHelper.collide(collisionShape, collisionShape2);
                        if (selectedLocation != null)
                        {
                            selectedLocation.setCurrentLocation(selectedLocation.getCurrentLocation() + repluseForce);
                        }
                    }
                }

            }
        }

        public override void draw(GameTime gameTime, GameState.AbstractGameState gameState, SpriteBatch spriteBatch)
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
                        SpriteBatchWrapper.DrawGame(EditorContent.blank, shape.getRectangle(), null, Color.Orange * 0.4f, shape.getRotation(),
                            shape.getRotatePoint() / new Vector2(shape.getRectangle().Width, shape.getRectangle().Height), SpriteEffects.None, 1.1f);
                    }
                    if (collisionShape is Circle)
                    {
                        Circle shape = ((Circle)collisionShape);
                        SpriteBatchWrapper.DrawGame(EditorContent.circle100, shape.getLocation(), new Rectangle(0,0,100,100), Color.Orange * 0.4f, 0,
                            new Vector2(EditorContent.circle100.Width/2), shape.getRadius() * 2 / (float)100, SpriteEffects.None, 1);
                    }

                    /*
                    if (collisionShape is Line)
                    {
                        DrawHelper.drawBetween(((Line)collisionShape).getStartPoint(),  ((Line)collisionShape).getEndPoint(),spriteBatch,Color.Red, 2);
                    }
                     * */
                }
            }
        }
    }
}
