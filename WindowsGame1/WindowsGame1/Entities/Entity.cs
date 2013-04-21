using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Component;
using TheGameOfForever.Processor.Content.Textures;
using TheGameOfForever.Service.Shapes;
using TheGameOfForever.Geometry;

namespace TheGameOfForever.Entities
{
    public class Entity
    {
        int id = -1;
        private List<BaseComponent> components = new List<BaseComponent>();
        private EntityManager entityManager;

        private Entity(int id, params BaseComponent[] components)
        {
            this.id = id;
            for (int i = 0; i < components.Length; i++)
            {
                this.components.Add(components[i]);
            }
        }

        public void setEntityManager(EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }

        private Entity(int id, List<BaseComponent> components)
        {
            this.id = id;
            this.components = components;
        }

        public int getId()
        {
            return id;
        }

        public Boolean hasComponent<T>()
        {
            foreach (BaseComponent component in components)
            {
                if (component is T)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean hasComponent(Type t)
        {
            foreach (BaseComponent component in components)
            {
                if (t.IsAssignableFrom(component.GetType()))
                {
                    return true;
                }
            }
            return false;
        }

        public T getComponent<T>() where T : BaseComponent
        {
            foreach (BaseComponent component in components)
            {
                if (component is T)
                {
                    return (T) component;
                }
            }
            return default(T);
        }

        public void removeComponent<T>() where T : BaseComponent
        {
            List<BaseComponent> componentsToRemove = new List<BaseComponent>();
            foreach (BaseComponent component in components)
            {
                if (component is T)
                {
                    componentsToRemove.Add(component);
                }
            }
            foreach (BaseComponent component in componentsToRemove)
            {
                components.Remove(component);
            }
            entityManager.updateEntity(this);
        }

        public void addComponent(BaseComponent component)
        {
            components.Add(component);
            entityManager.updateEntity(this);
        }

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

            public static Entity createMapComponent(params Vector2[] points)
            {
                List<Line> lineShapes = new List<Line>();
                VertexListComponent vertex = new VertexListComponent(points);

                for (int i = 0; i < vertex.getPoints().Count; i++)
                {
                    Vector2 start = vertex.getPoints()[i];
                    Vector2 end;

                    if (i + 1 == vertex.getPoints().Count)
                    {
                        end = vertex.getPoints()[0];
                    }
                    else
                    {
                        end = vertex.getPoints()[i + 1];
                    }
                    Vector2 between = start - end;
                    float angle = GeometryHelper.CalculateAngle(end, start);
                    float distance = between.Length() + 1.0f;
                    lineShapes.Add(new Line(start, (int)distance, angle, 0));
                }
                CollisionHitBox hitboxes = new CollisionHitBox(lineShapes.ToArray());
                return createEntityWithComponents(new MapElementComponent(), hitboxes, vertex);
            }

            public static Entity createHumanEntity(int health, Vector2 startingLocation, int teamId, bool controllable,
                params BaseComponent[] otherComponents)
            {
                List<BaseComponent> components = new List<BaseComponent>();
                // Add health.
                components.Add(new HealthComponent(health));
                // WHERE YOU AT!
                components.Add(new LocationComponent(startingLocation, 0));
                // People can move.
                components.Add(new MovementComponent(0.1f, Vector2.Zero));
                // Humans form teams.
                components.Add(new AllegianceComponent(teamId));
                components.Add(new MovementTime(10000000));
                components.Add(new IsHumanComponent());
                components.Add(new CollisionHitBox(new Circle(Vector2.Zero, 15, 5)));
                //components.Add(new CollisionHitBox(new RectangleShape(new Rectangle((int)(startingLocation.X - 25), 
                 //   (int)(startingLocation.Y - 25), 50,50),new Vector2(25),0,0)));
                components.Add(new Controllable(1));
                components.Add(new EntityTextureComponent(TextureLibrary.getModelIdFromName("human")));
                components.Add(new ArsenalComponent("pistol", "ak47"));
                return createEntityWithComponents(components);
            }
        }
    }
}
