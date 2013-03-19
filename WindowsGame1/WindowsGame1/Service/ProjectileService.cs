﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Service
{
    public class ProjectileService : AbstractGameService
    {
        public ProjectileService(EntityManager entityManager) : base(entityManager)
        {
            interestingComponentTypes.Add(typeof(IsProjectile));
        }

        public override void update(GameTime gameTime)
        {
            foreach (int e in entityIds)
            {
                Entity entity = entityManager.getEntity(e);
                LocationComponent loc = entity.getComponent<LocationComponent>();
                loc.setCurrentLocation(loc.getCurrentLocation() 
                    + entity.getComponent<MovementComponent>().getVelocity());
            }
        }
    }
}
