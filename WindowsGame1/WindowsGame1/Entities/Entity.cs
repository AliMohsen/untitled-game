using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using TheGameOfForever.Component;

namespace TheGameOfForever.Entities
{
    public class Entity
    {
        int id = -1;
        private List<BaseComponent> components;

        public Entity(int id, params BaseComponent[] components)
        {
            for (int i = 0; i < components.Length; i++)
            {
                this.components.Add(components[i]);
            }
        }

        public Entity(int id, List<BaseComponent> components)
        {
            this.components = components;
        }

        public int getId()
        {
            return id;
        }

        public Boolean hasComponent<T>()
        {
            foreach (IGameComponent component in components)
            {
                if (component is T)
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
    }
}
