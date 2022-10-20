namespace VectorLib
{
    public static class VectorExtensions
    {
        /// <summary>
        /// Negates a vector
        /// </summary>
        /// <param name="v1">vector to negate</param>
        /// <returns>a new negated vector</returns>
        public static Vector Negate(this Vector v1)
        {
            return Multiply(v1, -1);
        }

        /// <summary>
        /// Creates the sum of two vectors <code>v1+v2</code>
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>a new Vector</returns>
        public static Vector Add(this Vector v1, Vector v2)
        {
            return new Vector(
                v1.X + v2.X,
                v1.Y + v2.Y,
                v1.Z + v2.Z
            );
        }

        /// <summary>
        /// Creates the difference of two vectors <code>v1-v2</code>
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>a new Vector</returns>
        public static Vector Subtract(this Vector v1, Vector v2)
        {
            return new Vector(
                v1.X - v2.X,
                v1.Y - v2.Y,
                v1.Z - v2.Z
            );
        }

        /// <summary>
        /// Multiplies a vector with a given factor <code>v1 * factor</code>
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="factor">Factor</param>
        /// <returns>a new Vector</returns>
        public static Vector Multiply(this Vector v1, double factor)
        {
            return new Vector(
                v1.X * factor,
                v1.Y * factor,
                v1.Z * factor
            );
        }

        /// <summary>
        /// Devides a vector with a given quotient <code>v1 / quotient</code>
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="quotient">Quotient</param>
        /// <returns>a new Vector</returns>
        public static Vector Divide(this Vector v1, double quotient)
        {
            return new Vector(
                v1.X / quotient,
                v1.Y / quotient,
                v1.Z / quotient
            );
        }

        /// <summary>
        /// Creates the scalar product of two vectors <code>v1•v2</code>
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>a new Vector</returns>
        public static double ScalarProduct(this Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        /// <summary>
        /// Creates the cross product of two vectors <code>v1 x v2</code>
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>a new Vector</returns>
        public static Vector CrossProduct(this Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        /// <summary>
        /// Calculates the angle between two vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <param name="inDegrees">defines if the output is in radians or degrees</param>
        /// <returns>the Angle in radians(default) or degrees</returns>
        public static double AngleBetween(this Vector v1, Vector v2, bool inDegrees = false)
        {
            var radians = Math.Acos(v1.ScalarProduct(v2) / (v1.Length * v2.Length));
            return inDegrees ? radians * 180 / Math.PI : radians;
        }
    }
}
