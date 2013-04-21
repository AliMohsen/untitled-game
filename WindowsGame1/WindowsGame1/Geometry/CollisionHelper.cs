using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameOfForever.Service.Shapes;
using Microsoft.Xna.Framework;

namespace TheGameOfForever.Geometry
{
    public class CollisionHelper
    {
        public static Vector2 collide(IShape a, IShape b)
        {
            if (a is RectangleShape && b is RectangleShape)
            {
                return intersectRectangles((RectangleShape)a, (RectangleShape)b);
            }

            if (a is Circle && b is RectangleShape)
            {
                return -intersectCircleRectangle(a, b);
            }

            if (a is RectangleShape && b is Circle)
            {
                return intersectCircleRectangle(a, b);
            }

            if (a is Circle && b is Circle)
            {
                return intersectCircles((Circle)a, (Circle)b);
            }

            return Vector2.Zero;
        }

        public static Vector2 intersectCircleRectangle(IShape a, IShape b)
        {
            throw new NotImplementedException();
        }

        public static Vector2 intersectCircles(Circle a, Circle b)
        {
            Vector2 aLocation = a.getLocation();
            Vector2 bLocation = b.getLocation();
            float aRadius = a.getRadius();
            float bRadius = b.getRadius();
            float distance = Vector2.Distance(aLocation, bLocation);

            if (distance > aRadius + bRadius)
            {
                return Vector2.Zero;
            }
            else
            {
                return Vector2.Normalize(bLocation - aLocation) * (distance - (aRadius + bRadius));
            }
        }

        //SAT for two rotated rectangles
        // 1st rectangle is weaker so is moved out by return vector2
        public static Vector2 intersectRectangles(RectangleShape a, RectangleShape b)
        {

            RectangleShape ar = new RectangleShape(new Rectangle((int)(a.getRectangle().X - a.getRotatePoint().X),
                (int)(a.getRectangle().Y - a.getRotatePoint().Y), a.getRectangle().Width, a.getRectangle().Height),
                a.getRotatePoint(), a.getRotation(), 0);
              
            //Rotated Vector points of Rectangle A
            Vector2 aUL = UpperLeftCorner(ar);
            Vector2 aUR = UpperRightCorner(ar);
            Vector2 aLL = LowerLeftCorner(ar);
            Vector2 aLR = LowerRightCorner(ar);

            Vector2[] aPoints = new Vector2[] { aUL, aUR, aLL, aLR };



            int aLeft = (int)Math.Min(Math.Min(aUL.X, aUR.X), Math.Min(aLL.X, aLR.X));
            int aTop = (int)Math.Min(Math.Min(aUL.Y, aUR.Y), Math.Min(aLL.Y, aLR.Y));
            int aRight = (int)Math.Max(Math.Max(aUL.X, aUR.X), Math.Max(aLL.X, aLR.X));
            int aBottom = (int)Math.Max(Math.Max(aUL.Y, aUR.Y), Math.Max(aLL.Y, aLR.Y));

            Rectangle aNoRotate = new Rectangle(aLeft, aTop, aRight - aLeft, aBottom - aTop);

            RectangleShape br = new RectangleShape(new Rectangle((int)(b.getRectangle().X - b.getRotatePoint().X),
                (int)(b.getRectangle().Y - b.getRotatePoint().Y), b.getRectangle().Width, b.getRectangle().Height),
                b.getRotatePoint(), b.getRotation(), 0);

            //Rotated Vector points of Rectangle B
            Vector2 bUL = UpperLeftCorner(br);
            Vector2 bUR = UpperRightCorner(br);
            Vector2 bLL = LowerLeftCorner(br);
            Vector2 bLR = LowerRightCorner(br);

            Vector2[] bPoints = new Vector2[] { bUL, bUR, bLL, bLR };




            int bLeft = (int)Math.Min(Math.Min(bUL.X, bUR.X), Math.Min(bLL.X, bLR.X));
            int bTop = (int)Math.Min(Math.Min(bUL.Y, bUR.Y), Math.Min(bLL.Y, bLR.Y));
            int bRight = (int)Math.Max(Math.Max(bUL.X, bUR.X), Math.Max(bLL.X, bLR.X));
            int bBottom = (int)Math.Max(Math.Max(bUL.Y, bUR.Y), Math.Max(bLL.Y, bLR.Y));

            Rectangle bNoRotate = new Rectangle(bLeft, bTop, bRight - bLeft, bBottom - bTop);

            //Checks initially for the bounding rectangles non rotated.
            if (!intersectRectanglesNoRotate(aNoRotate, bNoRotate))
            {
                return Vector2.Zero;
            }

            List<Vector2> aRectangleAxis = new List<Vector2>();
            aRectangleAxis.Add(aUR - aUL);
            aRectangleAxis.Add(aUR - aLR);
            aRectangleAxis.Add(bUL - bLL);
            aRectangleAxis.Add(bUL - bUR);

            //Cycle through all of the Axis we need to check. If a collision does not occur
            //on ALL of the Axis, then a collision is NOT occurring. We can then exit out 
            //immediately and notify the calling function that no collision was detected. If
            //a collision DOES occur on ALL of the Axis, then there is a collision occurring
            //between the rotated rectangles. We know this to be true by the Seperating Axis Theorem
            Vector2 smallest = new Vector2(10000, 10000);
            foreach (Vector2 aAxis in aRectangleAxis)
            {


                Vector2 res = IsAxisCollision(aPoints, bPoints, aAxis);
                if (res == Vector2.Zero)
                {
                    return Vector2.Zero;
                }
                else
                {
                    if (Math.Pow(res.X, 2) + Math.Pow(res.Y, 2) < Math.Pow(smallest.X, 2) + Math.Pow(smallest.Y, 2))
                    {
                        smallest = res;
                    }
                }

            }

            return smallest;
        }

        private static bool intersectRectanglesNoRotate(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        public static Vector2 UpperLeftCorner(RectangleShape a)
        {
            Vector2 aUpperLeft = new Vector2(a.getRectangle().Left, a.getRectangle().Top);
            aUpperLeft = RotatePoint(aUpperLeft, aUpperLeft + a.getRotatePoint(), a.getRotation());
            return aUpperLeft;
        }

        public static Vector2 UpperRightCorner(RectangleShape a)
        {
            Vector2 aUpperRight = new Vector2(a.getRectangle().Right, a.getRectangle().Top);
            aUpperRight = RotatePoint(aUpperRight, aUpperRight + new Vector2(-(a.getRectangle().Width - a.getRotatePoint().X), 
                a.getRotatePoint().Y), a.getRotation());
            return aUpperRight;
        }

        public static Vector2 LowerLeftCorner(RectangleShape a)
        {
            Vector2 aLowerLeft = new Vector2(a.getRectangle().Left, a.getRectangle().Bottom);
            aLowerLeft = RotatePoint(aLowerLeft, aLowerLeft + new Vector2(a.getRotatePoint().X, 
                -(a.getRectangle().Height - a.getRotatePoint().Y)), a.getRotation());
            return aLowerLeft;
        }


        public static Vector2 LowerRightCorner(RectangleShape a)
        {
            Vector2 aLowerRight = new Vector2(a.getRectangle().Right, a.getRectangle().Bottom);
            aLowerRight = RotatePoint(aLowerRight, aLowerRight + new Vector2(-(a.getRectangle().Width - a.getRotatePoint().X), 
                -(a.getRectangle().Height - a.getRotatePoint().Y)), a.getRotation());
            return aLowerRight;
        }

        private static Vector2 RotatePoint(Vector2 thePoint, Vector2 theOrigin, float theRotation)
        {
            Vector2 temp = thePoint - theOrigin;
            Vector2 rotatePoint;
            rotatePoint.X = (float)(temp.X * Math.Cos(theRotation) - temp.Y * Math.Sin(theRotation));
            rotatePoint.Y = (float)(temp.X * Math.Sin(theRotation) + temp.Y * Math.Cos(theRotation));

            return rotatePoint + theOrigin;
        }

        //A is weaker
        private static Vector2 IsAxisCollision(Vector2[] a, Vector2[] b, Vector2 aAxis)
        {
            //Project the corners of the Rectangle we are checking on to the Axis and
            //get a scalar value of that project we can then use for comparison
            Vector2[] aRectangleAProj = new Vector2[4];
            aRectangleAProj[0] = (GenerateProjection(a[0], aAxis));
            aRectangleAProj[1] = (GenerateProjection(a[1], aAxis));
            aRectangleAProj[2] = (GenerateProjection(a[2], aAxis));
            aRectangleAProj[3] = (GenerateProjection(a[3], aAxis));

            //Project the corners of the current Rectangle on to the Axis and
            //get a scalar value of that project we can then use for comparison
            Vector2[] aRectangleBProj = new Vector2[4];
            aRectangleBProj[0] = (GenerateProjection(b[0], aAxis));
            aRectangleBProj[1] = (GenerateProjection(b[1], aAxis));
            aRectangleBProj[2] = (GenerateProjection(b[2], aAxis));
            aRectangleBProj[3] = (GenerateProjection(b[3], aAxis));


            int[] aRectangleAScalar = new int[4];
            aRectangleAScalar[0] = (GenerateScalar(a[0], aAxis));
            aRectangleAScalar[1] = (GenerateScalar(a[1], aAxis));
            aRectangleAScalar[2] = (GenerateScalar(a[2], aAxis));
            aRectangleAScalar[3] = (GenerateScalar(a[3], aAxis));


            int[] aRectangleBScalar = new int[4];
            aRectangleBScalar[0] = (GenerateScalar(b[0], aAxis));
            aRectangleBScalar[1] = (GenerateScalar(b[1], aAxis));
            aRectangleBScalar[2] = (GenerateScalar(b[2], aAxis));
            aRectangleBScalar[3] = (GenerateScalar(b[3], aAxis));


            int aMinIndex = 0;
            int aMaxIndex = 0;
            int bMinIndex = 0;
            int bMaxIndex = 0;

            int aMin = aRectangleAScalar[0];
            int aMax = aRectangleAScalar[0];
            int bMin = aRectangleBScalar[0];
            int bMax = aRectangleBScalar[0];

            for (int i = 1; i < 4; i++)
            {
                if (aRectangleAScalar[i] < aMin)
                {
                    aMin = aRectangleAScalar[i];
                    aMinIndex = i;
                }

                if (aRectangleAScalar[i] > aMax)
                {
                    aMax = aRectangleAScalar[i];
                    aMaxIndex = i;
                }

                if (aRectangleBScalar[i] < bMin)
                {
                    bMin = aRectangleBScalar[i];
                    bMinIndex = i;
                }

                if (aRectangleBScalar[i] > bMax)
                {
                    bMax = aRectangleBScalar[i];
                    bMaxIndex = i;
                }
            }


            //If we have overlaps between the Rectangles (i.e. Min of B is less than Max of A)
            //then we are detecting a collision between the rectangles on this Axis
            if (bMin <= aMax && bMax >= aMax)
            {

                return -(aRectangleAProj[aMaxIndex] - aRectangleBProj[bMinIndex]);


            }
            else if (aMin <= bMax && aMax >= bMax)
            {
                return aRectangleBProj[bMaxIndex] - aRectangleAProj[aMinIndex];

            }

            return Vector2.Zero;
        }


        //Dot product of vector and axis for scalar value
        private static int GenerateScalar(Vector2 projected, Vector2 theAxis)
        {
            float aScalar = (theAxis.X * projected.X) + (theAxis.Y * projected.Y);
            return (int)aScalar;
        }

        private static Vector2 GenerateProjection(Vector2 theRectangleCorner, Vector2 theAxis)
        {
            //Using the formula for Vector projection. Take the corner being passed in
            //and project it onto the given Axis
            float aNumerator = (theRectangleCorner.X * theAxis.X) + (theRectangleCorner.Y * theAxis.Y);
            float aDenominator = (theAxis.X * theAxis.X) + (theAxis.Y * theAxis.Y);
            float aDivisionResult = aNumerator / aDenominator;
            return new Vector2(aDivisionResult * theAxis.X, aDivisionResult * theAxis.Y);

        }
    }
}
