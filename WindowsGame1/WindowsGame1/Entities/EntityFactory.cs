using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Component;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Entities
{
    public class EntityFactory
    {
        private static int uniqueId = 0;
        private static Object thisLock = new Object();

        public static Entity createEntityWithComponents(List<BaseComponent> components)
        {
            lock (thisLock)
            {
                uniqueId++;
                return new Entity(uniqueId, components);
            }
        }

        public static Entity createEntityWithComponents(params BaseComponent[] components)
        {
            lock (thisLock)
            {
                uniqueId++;
                return new Entity(uniqueId, components);
            }
        }

        public static Entity createHumanEntity(int health)
        {
            // Add health.
            HealthComponent healthComponent = new HealthComponent(health);
            // WHERE YOU AT!
            LocationComponent locationComponent = new LocationComponent();
            // People can move.
            MovementComponent movementComponent = new MovementComponent(6);
            return createEntityWithComponents(
                healthComponent, 
                new IsHumanComponent(), 
                locationComponent, 
                movementComponent);
        }
    }
}
