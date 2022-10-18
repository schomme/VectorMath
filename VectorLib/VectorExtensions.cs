using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VectorLib
{
    public static class VectorExtensions
    {
        public static Vector Negate(this Vector v1)
        {
            return Multiply(v1, -1);
        }
        public static Vector Add(this Vector v1, Vector v2)
        {
            return new Vector(
                v1.X + v2.X,
                v1.Y + v2.Y,
                v1.Z + v2.Z
            );
        }
        public static Vector Subtract(this Vector v1, Vector v2)
        {
            return new Vector(
                v1.X - v2.X,
                v1.Y - v2.Y,
                v1.Z - v2.Z
            );
        }
        public static Vector Multiply(this Vector v1, double factor)
        {
            return new Vector(
                v1.X * factor,
                v1.Y * factor,
                v1.Z * factor
            );
        }
        public static Vector Divide(this Vector v1, double quotient)
        {
            return new Vector(
                v1.X / quotient,
                v1.Y / quotient,
                v1.Z / quotient
            );
        }
        public static double ScalarProduct(this Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        public static Vector CrossProduct(this Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }
        public static double AngleBetween(this Vector v1, Vector v2, bool inDegrees = false)
        {
            var radians = Math.Acos(v1.ScalarProduct(v2) / (v1.Length * v2.Length));
            return inDegrees ? radians * 180 / Math.PI : radians;
        }

    }
}
