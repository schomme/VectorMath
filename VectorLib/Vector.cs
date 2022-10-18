namespace VectorLib
{
    public class Vector : IEquatable<Vector>
    {
        private Guid _guid { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double Length => Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Y * this.Y);

        public Vector(double x, double y, double z)
        {
            this._guid = new Guid();
            X = x;
            Y = y;
            Z = z;
        }
        public Vector() : this(0, 0, 0) {}

        #region Overrides

        public override bool Equals(object? obj)
        {
            if(obj is Vector v) return this.X == v.X && this.Y == v.Y && this.X == v.X;
            return false;
        }
        public override int GetHashCode()
        {   //TODO: Hash Methode überarbeiten
            return this._guid.GetHashCode();
        }

        #endregion

        public bool Equals(Vector? other)
        {
            return this.Equals(other);
        }

    }
}