using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Entities
{
    public interface IEntityLoader
    {
        void loadEntities(EntityManager entityManager);
    }
}
