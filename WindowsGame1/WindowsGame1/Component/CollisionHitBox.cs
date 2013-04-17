using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service.Shapes;

namespace TheGameOfForever.Component
{
    public class CollisionHitBox : BaseComponent
    {
        List<IShape> collisionShapes = new List<IShape>();
        public CollisionHitBox(params IShape[] shapes)
        {
            this.collisionShapes = new List<IShape>();
            for (int i = 0; i < shapes.Length; i++)
            {
                collisionShapes.Add(shapes[i]);
            }
        }

        public List<IShape> getCollisionShapes()
        {
            return collisionShapes;
        }
    }
}
