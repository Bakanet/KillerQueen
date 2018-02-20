using System;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram
{
    public class Vector2
    {
        // Don't forget to implement me!
        public static readonly Vector2 Zero = new Vector2(0, 0);

        public Vector2(double x, double y)
        {
            if (double.IsInfinity(x) || double.IsNaN(x) || double.IsInfinity(y) || double.IsNaN(y))
                throw new ArgumentException("Invalid arguments to Vector2");
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.X, -v.Y);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(double factor, Vector2 v)
        {
            return new Vector2(factor * v.X, factor * v.Y);
        }

        public static Vector2 operator *(Vector2 v, double factor)
        {
            return new Vector2(factor * v.X, factor * v.Y);
        }

        public static Vector2 operator /(double factor, Vector2 v)
        {
            return new Vector2(factor / v.X, factor / v.Y);
        }

        public static Vector2 operator /(Vector2 v, double factor)
        {
            return new Vector2(v.X / factor, v.Y / factor);
        }

        // Returns the norm of the vector.
        public double Norm()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        // Returns the normalized form of the vector.
        public Vector2 Normalized()
        {
            double norm = Norm();
            return new Vector2(X / norm, Y / norm);
        }

        // Returns the distance between two vectors.
        public static double Dist(Vector2 v1, Vector2 v2)
        {
            Vector2 distance = v1 - v2;
            return distance.Norm();
        }

        // Don't worry about me for now, you'll meet me again later on during the practical.
        public static double Dot(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        // Do not edit this method.
        public override string ToString()
        {
            return "[" + Json.Escape(X) + ", " + Json.Escape(Y) + "]";
        }
    }
}
