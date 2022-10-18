using _3DVectorMath.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using VectorLib;

namespace _3DVectorMath.ViewModel
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private Vector _FirstVector = new Vector();
        private Vector _SecondVector = new Vector();
        private Vector _ResultVector = new Vector();
       
        public readonly Dictionary<string, Func<Vector, Vector, Vector>> Calculations = new Dictionary<string, Func<Vector, Vector, Vector>>() { 
            { "Add", VectorExtensions.Add },
            { "Substract", VectorExtensions.Subtract },
            { "CrossProduct", VectorExtensions.CrossProduct },
        };
        private KeyValuePair<string, Func<Vector, Vector, Vector>> _CalcSelection;


        public MainViewModel()
        {
            _CalcSelection = Calculations.First();
        }


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
                }
            }
        }
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
                }
            }
        }
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
                    this.NotifyInternProperies();                   
                }
            }
        }
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

        public Dictionary<string, Func<Vector, Vector, Vector>> CalculationsModes => Calculations;
        public double Angle 
        {
            get
            {
                if (this.FirstVector == null || this.SecondVector == null) return 0d;
                if (this.FirstVector.Length == 0 || this.SecondVector.Length == 0) return 0d;
                return this.FirstVector.AngleBetween(this.SecondVector);
            }
        }
        public double AngleDegress
        {
            get
            {
                if (this.FirstVector == null || this.SecondVector == null) return 0d;
                if (this.FirstVector.Length == 0 || this.SecondVector.Length == 0) return 0d;
                return this.FirstVector.AngleBetween(this.SecondVector, true);
            }
        }
        public double ScalarProduct
        {
            get
            {
                return this.FirstVector.ScalarProduct(this.SecondVector);
            }
        }
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
        private void UpdateResultVector()
        {
            if (this.FirstVector is null || this.SecondVector is null) return;

            this.ResultVector = this.CalcSelection.Value.Invoke(this.FirstVector, this.SecondVector);
        }

        private void NotifyInternProperies()
        {
            OnPropertyRaised(nameof(this.Angle));
            OnPropertyRaised(nameof(this.AngleDegress));
            OnPropertyRaised(nameof(this.ScalarProduct));
        }
    }
}
