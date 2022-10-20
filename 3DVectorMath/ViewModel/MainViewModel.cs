using _3DVectorMath.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VectorLib;

namespace _3DVectorMath.ViewModel
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        #region Fields

        private Vector _FirstVector = new Vector();
        private Vector _SecondVector = new Vector();
        private Vector _ResultVector = new Vector();

        private ICommand _negateVector;
        private double _Faktor = 1;
        private double _Quotient = 1;

        public readonly Dictionary<string, Func<Vector, Vector, Vector>> Calculations = new Dictionary<string, Func<Vector, Vector, Vector>>() {
            { "Add", VectorExtensions.Add },
            { "Substract", VectorExtensions.Subtract },
            { "CrossProduct", VectorExtensions.CrossProduct },
        };
        private KeyValuePair<string, Func<Vector, Vector, Vector>> _CalcSelection;

        #endregion

        #region Construtor
        public MainViewModel()
        {
            _CalcSelection = Calculations.Last();
        }

        #endregion

        #region Properties

        /// <summary>
        /// First Vector
        /// </summary>
        public Vector FirstVector
        {
            get
            {
                return _FirstVector;
            }
            private set
            {
                if (value != _FirstVector)
                {
                    _FirstVector = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.X1));
                    OnPropertyRaised(nameof(this.Y1));
                    OnPropertyRaised(nameof(this.Z1));
                }
            }
        }

        /// <summary>
        /// Second Vector
        /// </summary>
        public Vector SecondVector
        {
            get
            {
                return _SecondVector;
            }
            private set
            {
                if (value != _SecondVector)
                {
                    _SecondVector = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.X2));
                    OnPropertyRaised(nameof(this.Y2));
                    OnPropertyRaised(nameof(this.Z2));
                }
            }
        }

        /// <summary>
        /// The ResultVector of the First and Second Vector
        /// </summary>
        public Vector ResultVector
        {
            get
            {
                return _ResultVector;
            }
            private set
            {
                if (value != _ResultVector)
                {
                    _ResultVector = value;
                    OnPropertyRaised();
                    this.NotifyInternProperies();
                }
            }
        }

        /// <summary>
        /// X-Component of the First Vector
        /// </summary>
        public double X1
        {
            get
            {
                return FirstVector.X;
            }
            set
            {
                if (value != FirstVector.X)
                {
                    _FirstVector.X = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.FirstVector));
                    this.NotifyInternProperies();
                }
            }
        }

        /// <summary>
        /// Y-Component of the First Vector
        /// </summary>
        public double Y1
        {
            get
            {
                return FirstVector.Y;
            }
            set
            {
                if (value != FirstVector.Y)
                {
                    _FirstVector.Y = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.FirstVector));
                    this.NotifyInternProperies();
                }
            }
        }
        /// <summary>
        /// Z-Component of the First Vector
        /// </summary>
        public double Z1
        {
            get
            {
                return FirstVector.Z;
            }
            set
            {
                if (value != FirstVector.Z)
                {
                    _FirstVector.Z = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.FirstVector));
                    this.NotifyInternProperies();
                }
            }
        }

        /// <summary>
        /// X-Component of the Second Vector
        /// </summary>
        public double X2
        {
            get
            {
                return SecondVector.X;
            }
            set
            {
                if (value != SecondVector.X)
                {
                    _SecondVector.X = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.SecondVector));
                    this.NotifyInternProperies();
                }
            }
        }

        /// <summary>
        /// Y-Component of the Second Vector
        /// </summary>
        public double Y2
        {
            get
            {
                return SecondVector.Y;
            }
            set
            {
                if (value != SecondVector.Y)
                {
                    _SecondVector.Y = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.SecondVector));
                    this.NotifyInternProperies();
                }
            }
        }

        /// <summary>
        /// Z-Component of the Second Vector
        /// </summary>
        public double Z2
        {
            get
            {
                return SecondVector.Z;
            }
            set
            {
                if (value != SecondVector.Z)
                {
                    _SecondVector.Z = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                    OnPropertyRaised(nameof(this.SecondVector));
                    this.NotifyInternProperies();
                }
            }
        }

        /// <summary>
        /// Dictionary to the Calculation options
        /// </summary>
        public Dictionary<string, Func<Vector, Vector, Vector>> CalculationsModes => Calculations;

        /// <summary>
        /// Angle between the Vectors in radians
        /// </summary>
        public double Angle
        {
            get
            {
                if (this.FirstVector == null || this.SecondVector == null) return 0d;
                if (this.FirstVector.Length == 0 || this.SecondVector.Length == 0) return 0d;
                return this.FirstVector.AngleBetween(this.SecondVector);
            }
        }

        /// <summary>
        /// Angle between the Vectors in degrees
        /// </summary>
        public double AngleDegress
        {
            get
            {
                if (this.FirstVector == null || this.SecondVector == null) return 0d;
                if (this.FirstVector.Length == 0 || this.SecondVector.Length == 0) return 0d;
                return this.FirstVector.AngleBetween(this.SecondVector, true);
            }
        }

        /// <summary>
        /// The scalar product of the first and second Vector
        /// </summary>
        public double ScalarProduct
        {
            get
            {
                return this.FirstVector.ScalarProduct(this.SecondVector);
            }
        }

        /// <summary>
        /// Calculates the diameter of the Arrow
        /// </summary>
        public double ArrowDiameter
        {
            get
            {
                if (FirstVector.Length == 0d && SecondVector.Length == 0d && ResultVector.Length == 0d) return 1d;

                return new[] { FirstVector.Length, SecondVector.Length, ResultVector.Length }.Where(i => i > 0).Min() * 0.1d;

            }
        }

        /// <summary>
        /// The selected Calculation mode. Item of the Dictionary CalculationsModes
        /// </summary>
        public KeyValuePair<string, Func<Vector, Vector, Vector>> CalcSelection
        {
            get
            {
                return this._CalcSelection;
            }
            set
            {
                if (value.Key != _CalcSelection.Key)
                {
                    _CalcSelection = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                }
            }
        }

        /// <summary>
        /// The Factor to multiply the Resultvector
        /// </summary>
        public double Faktor
        {
            get
            {
                return _Faktor;
            }
            set
            {
                if (value != _Faktor)
                {
                    _Faktor = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                }
            }
        }

        /// <summary>
        /// The Quotient to divide the Resultvector
        /// </summary>
        public double Quotient
        {
            get
            {
                return _Quotient;
            }
            set
            {
                if (value != _Quotient)
                {
                    _Quotient = value;
                    UpdateResultVector();
                    OnPropertyRaised();
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Recalculates the ResultVector with the First and Second Vector and depends on the CalcSelection, Faktor and Quotient
        /// </summary>
        private void UpdateResultVector()
        {
            if (this.FirstVector is null || this.SecondVector is null) return;
            var v = this.CalcSelection.Value.Invoke(this.FirstVector, this.SecondVector);

            v = v.Multiply(Faktor);

            if(this.Quotient != 0) v = v.Divide(this.Quotient);

            this.ResultVector = v;
        }

        /// <summary>
        /// Raises the PropertyChanged Events of dependet properties
        /// </summary>
        private void NotifyInternProperies()
        {
            OnPropertyRaised(nameof(this.Angle));
            OnPropertyRaised(nameof(this.AngleDegress));
            OnPropertyRaised(nameof(this.ScalarProduct));
            OnPropertyRaised(nameof(this.ArrowDiameter));
        }

        #endregion

        #region Commands

        /// <summary>
        /// Command to negate the Vector
        /// </summary>
        public ICommand NegateVector { 
            get 
            {
                return _negateVector ?? (_negateVector = new VectorCommandHandler((p) => {
                    if (p == FirstVector) FirstVector = p.Negate();
                    else if(p == SecondVector) SecondVector = p.Negate();
                    else if (p == ResultVector) ResultVector = p.Negate();
                }, true));
            } 
        }

        #endregion
    }
}
