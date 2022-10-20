namespace VectorLib
{
    public class Vector : IEquatable<Vector>
    {
        /// <summary>
        /// GUID of the Vector
        /// </summary>
        private Guid _guid { get; }

        /// <summary>
        /// X-Component of the Vector
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y-Component of the Vector
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Z-Component of the Vector
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Length of the Vector
        /// </summary>
        public double Length => Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

        /// <summary>
        /// Creates a new Vector with the given components
        /// </summary>
        /// <param name="x">X-Component</param>
        /// <param name="y">Y-Component</param>
        /// <param name="z">Z-Component</param>
        public Vector(double x, double y, double z)
        {
            this._guid = new Guid();
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Creates a null vector (0,0,0)
        /// </summary>
        public Vector() : this(0, 0, 0) {}

        #region Overrides

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Vector v) return this.GetHashCode() == v.GetHashCode();
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this._guid, this.X, this.Y, this.Z);
        }

        #endregion

        public bool Equals(Vector? other)
        {
            return this.Equals(other);
        }

    }
}