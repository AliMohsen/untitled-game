using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;

namespace TheGameOfForever.Service
{
    public class ProjectileService : AbstractGameService
    {
        public ProjectileService(EntityManager entityManager) : base(entityManager)
        {
            subscribeToComponentGroup(typeof(IsProjectile)); // 0
        }

        public override void update(GameTime gameTime, AbstractGameState gameState)
        {
            foreach (int e in entityIds[0])
            {
                Entity entity = entityManager.getEntity(e);
                LocationComponent loc = entity.getComponent<LocationComponent>();
                loc.setCurrentLocation(loc.getCurrentLocation() 
                    + entity.getComponent<MovementComponent>().getVelocity());
            }
        }
    }
}
