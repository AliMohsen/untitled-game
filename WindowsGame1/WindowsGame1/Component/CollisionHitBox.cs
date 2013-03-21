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
    }
}
