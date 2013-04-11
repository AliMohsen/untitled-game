using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Component
{
    public class VertexListComponent : BaseComponent
    {
        List<Vector2> points = new List<Vector2>();

        public VertexListComponent(params Vector2[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                addPoint(points[i]);
            }
        }

        public void addPoint(Vector2 point)
        {
            points.Add(point);
        }

        public List<Vector2> getPoints()
        {
            return points;
        }
    }
}
