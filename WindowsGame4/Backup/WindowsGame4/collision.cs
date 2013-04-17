using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame4
{
    public static class collision
    {


        public static Vector2 todraw1;
        public static Vector2 todraw2;
        public static Vector2 todraw3;
        public static Vector2 todraw4;

        public static Vector2 todraw5;
        public static Vector2 todraw6;
        public static Vector2 todraw7;
        public static Vector2 todraw8;
        public static Vector2 todraw9;


        //SAT for two rotated rectangles
        // 1st rectangle is weaker so is moved out by return vector2
        public static Vector2 intersectRectangles(collisionShape a, collisionShape b)
        {

            collisionShape ar = new collisionShape(new Rectangle((int)(a.r.X - a.rotatePoint.X), (int)(a.r.Y - a.rotatePoint.Y), a.r.Width, a.r.Height), a.rotatePoint, a.rotation,0);


            //Rotated Vector points of Rectangle A
            Vector2 aUL = UpperLeftCorner(ar);
            Vector2 aUR = UpperRightCorner(ar);
            Vector2 aLL = LowerLeftCorner(ar);
            Vector2 aLR = LowerRightCorner(ar);

            Vector2[] aPoints = new Vector2[] { aUL, aUR, aLL, aLR };

            todraw5 = aUL;
            todraw6 = aUR;
            todraw7 = aLL;
            todraw8 = aLR;



            int aLeft = (int)Math.Min(Math.Min(aUL.X, aUR.X), Math.Min(aLL.X, aLR.X));
            int aTop = (int)Math.Min(Math.Min(aUL.Y, aUR.Y), Math.Min(aLL.Y, aLR.Y));
            int aRight = (int)Math.Max(Math.Max(aUL.X, aUR.X), Math.Max(aLL.X, aLR.X));
            int aBottom = (int)Math.Max(Math.Max(aUL.Y, aUR.Y), Math.Max(aLL.Y, aLR.Y));

            Rectangle aNoRotate = new Rectangle(aLeft, aTop, aRight - aLeft, aBottom - aTop);

            collisionShape br = new collisionShape(new Rectangle((int)(b.r.X - b.rotatePoint.X), (int)(b.r.Y - b.rotatePoint.Y), b.r.Width, b.r.Height), b.rotatePoint, b.rotation,0);

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

            todraw1 = bUL;
            todraw2 = bUR;
            todraw3 = bLL;
            todraw4 = bLR;

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




        private static Vector2 rotatePoint(Vector2 toRotate, Vector2 Origin, float rotation)
        {
            //Normalise to origin
            Vector2 back = toRotate - Origin;
            Vector2 temp = new Vector2();
            temp.X = (float)(back.X * Math.Cos(-rotation) - back.Y * Math.Sin(-rotation));
            temp.Y = (float)(back.X * Math.Sin(rotation) + back.Y * Math.Cos(-rotation));
            return (temp + Origin);
        }

        private static Vector2 RotatePoint(Vector2 thePoint, Vector2 theOrigin, float theRotation)
        {
            Vector2 temp = thePoint - theOrigin;
            Vector2 rotatePoint;
            rotatePoint.X = (float)(temp.X * Math.Cos(theRotation) - temp.Y * Math.Sin(theRotation));
            rotatePoint.Y = (float)(temp.X * Math.Sin(theRotation) + temp.Y * Math.Cos(theRotation));

            return rotatePoint + theOrigin;
        }

        public static Vector2 UpperLeftCorner(collisionShape a)
        {
            Vector2 aUpperLeft = new Vector2(a.r.Left, a.r.Top);
            aUpperLeft = RotatePoint(aUpperLeft, aUpperLeft + a.rotatePoint, a.rotation);
            return aUpperLeft;
        }

        public static Vector2 UpperRightCorner(collisionShape a)
        {
            Vector2 aUpperRight = new Vector2(a.r.Right, a.r.Top);
            aUpperRight = RotatePoint(aUpperRight, aUpperRight + new Vector2(-(a.r.Width - a.rotatePoint.X), a.rotatePoint.Y), a.rotation);
            return aUpperRight;
        }

        public static Vector2 LowerLeftCorner(collisionShape a)
        {
            Vector2 aLowerLeft = new Vector2(a.r.Left, a.r.Bottom);
            aLowerLeft = RotatePoint(aLowerLeft, aLowerLeft + new Vector2(a.rotatePoint.X, -(a.r.Height - a.rotatePoint.Y)), a.rotation);
            return aLowerLeft;
        }


        public static Vector2 LowerRightCorner(collisionShape a)
        {
            Vector2 aLowerRight = new Vector2(a.r.Right, a.r.Bottom);
            aLowerRight = RotatePoint(aLowerRight, aLowerRight + new Vector2(-(a.r.Width - a.rotatePoint.X), -(a.r.Height - a.rotatePoint.Y)), a.rotation);
            return aLowerRight;
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

        private static Vector2 projected(Vector2 point, Vector2 axis)
	    {
            return
            (
               axis * (point.X * axis.X + point.Y * axis.Y) / (axis.X * axis.X + axis.Y * axis.Y)
            );
        }



        public static Vector2 circleLineDetect(Vector2 lineA, Vector2 lineB, collisionShape circle)
        {

            Vector2 v = lineB - (lineA);
            Vector2 w = circle.location - (lineA);
            float wDotv = Vector2.Dot(w, v);
            float t = Vector2.Dot(w, v) / Vector2.Dot(v, v);
            t = MathHelper.Clamp(t, 0, 1);
            Vector2 p = lineA + v * t;

            if (Vector2.DistanceSquared(p, circle.location) < circle.radius * circle.radius)
            {
                Vector2 towardsp = Vector2.Normalize(p - circle.location);
                return circle.location + (circle.radius * towardsp) - p;
            }
            return Vector2.Zero;


        }


        #region circle and rectangle collision
        private static Vector2 intersectCircleRectangle(collisionShape circle, collisionShape rectangle)
        {


            collisionShape rectangle2 = new collisionShape(new Rectangle((int)(rectangle.r.X - rectangle.rotatePoint.X), (int)(rectangle.r.Y - rectangle.rotatePoint.Y), rectangle.r.Width, rectangle.r.Height), rectangle.rotatePoint, rectangle.rotation,0);

            //Rotated Vector points of Rectangle 
            Vector2 rUL = UpperLeftCorner(rectangle2);
            Vector2 rUR = UpperRightCorner(rectangle2);
            Vector2 rLL = LowerLeftCorner(rectangle2);
            Vector2 rLR = LowerRightCorner(rectangle2);

            Vector2[] bPoints = new Vector2[] { rUL, rUR, rLL, rLR };

            int bLeft = (int)Math.Min(Math.Min(rUL.X, rUR.X), Math.Min(rLL.X, rLR.X));
            int bTop = (int)Math.Min(Math.Min(rUL.Y, rUR.Y), Math.Min(rLL.Y, rLR.Y));
            int bRight = (int)Math.Max(Math.Max(rUL.X, rUR.X), Math.Max(rLL.X, rLR.X));
            int bBottom = (int)Math.Max(Math.Max(rUL.Y, rUR.Y), Math.Max(rLL.Y, rLR.Y));

            //if (!intersectRectanglesNoRotate(new Rectangle(bLeft, bTop, bRight - bLeft, bBottom - bTop), new Rectangle((int)(circle.location.X - circle.radius), (int)(circle.location.Y - circle.radius), (int)circle.radius * 2, (int)circle.radius * 2)))
            //{
            //    return Vector2.Zero;
            //}



            Vector2 Normalisedvec;
            //Now we normalise the rectangle and circle by rotating the two objects by the rectangles rotation
            Vector2 rNUL = helper.rotatePoint2(rUL,new Vector2(rectangle2.r.X,rectangle2.r.Y),-rectangle2.rotation);
            Vector2 rNUR = helper.rotatePoint2(rUR,new Vector2(rectangle2.r.X,rectangle2.r.Y),-rectangle2.rotation);
            Vector2 rNLL = helper.rotatePoint2(rLL,new Vector2(rectangle2.r.X,rectangle2.r.Y),-rectangle2.rotation);
            Vector2 rNLR = helper.rotatePoint2(rLR, new Vector2(rectangle2.r.X, rectangle2.r.Y), -rectangle2.rotation);


            Rectangle recNormal = new Rectangle((int)rNUL.X, (int)rNUL.Y, (int)(rNUR.X - rNUL.X),(int)( rNLL.Y - rNUL.Y));



            Vector2 circleLoc = helper.rotatePoint2(circle.location, new Vector2(rectangle2.r.X, rectangle2.r.Y), -rectangle2.rotation);

            todraw9 = circleLoc;
            todraw6 = new Vector2(recNormal.Right, recNormal.Top);

            //Now we check for voronoi regions on the rectangle
            bool voronoid = false;
            Vector2 vertexVoronoi;

            //See if cirlce point fits in any voronoi region
            if (circleLoc.X  < recNormal.Left && circleLoc.Y  < recNormal.Top)
            {
                vertexVoronoi = rNUL;
                voronoid = true;
            }

            if (circleLoc.X > recNormal.Right && circleLoc.Y < recNormal.Top)
            {
                vertexVoronoi = rNUR;
                voronoid = true;
            }

            if (circleLoc.X  < recNormal.Left && circleLoc.Y > recNormal.Bottom)
            {
                vertexVoronoi = rNLL;
                voronoid = true;
            }

            if (circleLoc.X  > recNormal.Right && circleLoc.Y  > recNormal.Bottom)
            {
                vertexVoronoi = rNLR;
                voronoid = true;
            }

            if (!voronoid)
            {
                circle.rotation = 0.0f;

                Rectangle circleRec = new Rectangle((int)(circleLoc.X - circle.radius), (int)(circleLoc.Y - circle.radius), (int)circle.radius * 2, (int)circle.radius * 2);
               
                Normalisedvec = intersectRectangles(new collisionShape(circleRec, Vector2.Zero, 0,0), new collisionShape(recNormal, Vector2.Zero, 0,0));
            }
            else
            {
                circle.rotation = (float)Math.PI / 4;

                Rectangle circleRec = new Rectangle((int)(circleLoc.X), (int)(circleLoc.Y ), (int)circle.radius * 2, (int)circle.radius * 2);
            

                Normalisedvec = intersectRectangles(new collisionShape(circleRec, new Vector2(circle.radius,circle.radius), (float)Math.PI / 4,0), new collisionShape(recNormal, Vector2.Zero, 0,0));
            }

            return helper.rotatePoint2(Normalisedvec, Vector2.Zero, rectangle.rotation);


        }
        #endregion


        #region collision for 2 circles
        public static Vector2 intersectCircles(collisionShape a, collisionShape b)
        {

            float dist = Vector2.Distance(a.location, b.location);
            if (dist > a.radius + b.radius)
            {
                return Vector2.Zero;
            }
            else
            {
                return Vector2.Normalize(b.location - a.location) * (dist - (a.radius + b.radius));
            }

        }
        #endregion

        #region switch to select the correct collision detect method

        public static Vector2 ShapeSelector(collisionShape a, collisionShape b)
        {
            if (a.Flag == 0 && b.Flag == 0)
            {
                return intersectRectangles(a, b);
            }

            if (a.Flag == 0 && b.Flag == 1)
            {
                return -(intersectCircleRectangle(a, b));
            }

            if (a.Flag == 1 && b.Flag == 0)
            {
                return intersectCircleRectangle(a, b);
            }

            if (a.Flag == 1 && b.Flag == 1)
            {
                return intersectCircles(a, b);
            }

            return Vector2.Zero;
        }
        #endregion

        #region Method to calculate displacement due to mass
        public static Vector2[] displacementDueToMass(collisionShape a, collisionShape b, Vector2 aToMove)
        {

            Vector2[] ret = new Vector2[2];

            int aDirectionX;
            int aDirectionY;

            float aX = (aToMove.X * ((float)b.mass / (a.mass + b.mass)));
            if (aX > 0)
            {
                aDirectionX = (int)Math.Ceiling(aX);
            }
            else
            {
                aDirectionX = (int)Math.Floor(aX);
            }

            float aY = (aToMove.Y * ((float)b.mass / (a.mass + b.mass)));
            if (aY > 0)
            {
                aDirectionY = (int)Math.Ceiling(aY);
            }
            else
            {
                aDirectionY = (int)Math.Floor(aY);
            }

            ret[0] = new Vector2(aDirectionX,aDirectionY);
            ret[1] = new Vector2(((int)aToMove.X - aDirectionX),((int)aToMove.Y - aDirectionY));
            return ret;
        }

        #endregion



    }
}
