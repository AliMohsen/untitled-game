using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using TheGameOfForever.Service.Shapes;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service
{
    public class CollisionService : AbstractGameService
    {
        public CollisionService(EntityManager entityManager) : base(entityManager)
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
                    if (collisionShape.GetType() != typeof(Circle)) return;
                    foreach (IShape collisionShape2 in collisionShapes)
                    {
                        if (collisionShape2.GetType() != typeof(Circle)) continue;
                        Vector2 repluseForce = intersectCircles((Circle) collisionShape, (Circle) collisionShape2,
                            selectedLocation.getCurrentLocation(), toCollideLocation.getCurrentLocation());
                        selectedLocation.setCurrentLocation(selectedLocation.getCurrentLocation() + repluseForce);
                    }
                }

            }
        }

        public Vector2 intersectCircles(Circle a, Circle b, Vector2 locationA, Vector2 locationB)
        {
            float dist = Vector2.Distance(locationA, locationB);
            if (dist > a.getRadius() + b.getRadius())
            {
                return Vector2.Zero;
            }
            else
            {
                return Vector2.Normalize(locationB - locationA) * 
                    (dist - (a.getRadius() + b.getRadius()));
            }

        }
    }
}
