using _3DVectorMath.Base;
using _3DVectorMath.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VectorLib;

namespace _3DVectorMath.ViewModel
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private Vector _FirstVector = new Vector();
        private Vector _SecondVector = new Vector();
        private Vector _ResultVector = new Vector();
       
        private CalcMode _calcMode;
        

        public MainViewModel() {}


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
                    OnPropertyRaised(nameof(this.Angle));
                    OnPropertyRaised(nameof(this.AngleDegress));

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
                    OnPropertyRaised(nameof(this.FirstVector));
                    OnPropertyRaised(nameof(this.Angle));
                    OnPropertyRaised(nameof(this.AngleDegress));
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
                    OnPropertyRaised(nameof(this.Angle));
                    OnPropertyRaised(nameof(this.AngleDegress));
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
                    OnPropertyRaised(nameof(this.Angle));
                    OnPropertyRaised(nameof(this.AngleDegress));
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
                    OnPropertyRaised(nameof(this.Angle));
                    OnPropertyRaised(nameof(this.AngleDegress));
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
                    OnPropertyRaised(nameof(this.Angle));
                    OnPropertyRaised(nameof(this.AngleDegress));
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
                    OnPropertyRaised(nameof(this.Angle));
                    OnPropertyRaised(nameof(this.AngleDegress));
                }
            }
        }

        public CalcMode CalcMode
        {
            get
            {
                return _calcMode;
            }
            set
            {
                if (value != _calcMode)
                {
                    _calcMode = value;
                    OnPropertyRaised();
                }
            }
        }
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
        private void UpdateResultVector()
        {
            if (this.FirstVector is null || this.SecondVector is null) return;

            this.ResultVector = this.FirstVector.Add(SecondVector);
        }

    }
}
