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

        #region Methods

        public Vector Negate()
        {
            return new Vector(-this.X, -this.Y, -this.Z).Negate();
        }

        public Vector Add(Vector v)
        {
            return new Vector(
                this.X + v.X,
                this.Y + v.Y,
                this.Z + v.Z
            );
        }
        public Vector Subtract(Vector v)
        {
            return new Vector(
                this.X - v.X,
                this.Y - v.Y,
                this.Z - v.Z
            );
        }
        public Vector Multiply(double faktor)
        {
            return new Vector(
                this.X * faktor,
                this.Y * faktor,
                this.Z * faktor
            );
        }
        public Vector Divide(double quotient)
        {
            return new Vector(
                this.X / quotient,
                this.Y / quotient,
                this.Z / quotient
            );
        }
        public double ScalarProduct(Vector v)
        {
            return this.X * v.X + this.Y * v.Y + this.Z * v.Z;
        }
        public Vector CrossProduct(Vector v)
        {
            return new Vector(this.Y * v.Z - this.Z * v.Y, this.Z * v.X - this.X * v.Z, this.X * v.Y - this.Y * v.X);
        }
        public double AngleBetween(Vector v, bool inDegrees = false)
        {
            var radians = Math.Acos(this.ScalarProduct(v) / (this.Length * v.Length));
            return inDegrees ? radians * 180 / Math.PI : radians;
        }

        #endregion

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