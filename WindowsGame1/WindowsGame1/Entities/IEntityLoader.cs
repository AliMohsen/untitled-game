using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Entities
{
    public delegate void LoadEntities(EntityManager entityManager);
    public class EntityLoader
    {
        private EntityManager entityManager;
        public EntityLoader(EntityManager entityManager, LoadEntities loadEntities)
        {
            this.loadEntities = loadEntities;
        }
        public LoadEntities loadEntities;
    }
}
