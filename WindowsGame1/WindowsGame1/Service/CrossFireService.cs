using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Component;
using TheGameOfForever.Entities;
using Microsoft.Xna.Framework;
using TheGameOfForever.GameState;
using TheGameOfForever.Geometry;

namespace TheGameOfForever.Service
{
    public class CrossFireService : AbstractGameService
    {
        private int maxCrossfireDistance;

        public CrossFireService(EntityManager entityManager) : base(entityManager)
        {
            interestingComponentTypes.Add(typeof(CanFire));
        }

        public override void update(GameTime gameTime, GameState.AbstractGameState gameState)
        {
            if (((MovementState)gameState).isMoving())
            {
                Entity entityMoving = entityManager.getEntity(((MovementState)gameState).getEntityId());
                foreach (int entityId in entityIds)
                {
                    Entity entity = entityManager.getEntity(entityId);
                    if (entity.hasComponent<InterceptionFirePotential>()
                        && entity.getComponent<AllegianceComponent>().getTeamId()
                        != entityMoving.getComponent<AllegianceComponent>().getTeamId())
                    {
                        LocationComponent entityLocationComp = entity.getComponent<LocationComponent>();
                        InterceptionFirePotential interceptionFirePotential = entity.getComponent<InterceptionFirePotential>();
                        // Do a range check.
                        Vector2 targetLocation = entityMoving.getComponent<LocationComponent>().getCurrentLocation();
                        if (Vector2.DistanceSquared(targetLocation, entityLocationComp.getCurrentLocation()) >
                            interceptionFirePotential.getMaxAwarenessRangeFront() *
                            interceptionFirePotential.getMaxAwarenessRangeFront())
                        {
                            //Face target
                            entityLocationComp.setFacingRadians(
                                GeometryHelper.CalculateAngle(entityLocationComp.getCurrentLocation(), targetLocation));
                            // Fire away
                            fireShot(entityMoving, entity);
                        }
                    }

                }
            }
        }

        private void fireShot(Entity entityMoving, Entity interceptionEntity)
        {

        }
    }
}
