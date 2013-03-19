using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Entities;
using TheGameOfForever.Component;

namespace TheGameOfForever.Service
{
    public class MovementControlService : AbstractGameService
    {
        public MovementControlService(EntityManager entityManager) : base(entityManager)
        {
            interestingComponentTypes.Add(typeof(Controllable));
        }

        public override void update(GameTime gameTime)
        {
            foreach (int e in entityIds)
            {
                Entity entity = entityManager.getEntity(e);
                // Do movement logic based on controller input.
                LocationComponent loc = entity.getComponent<LocationComponent>();
            }
        }
    }
}
