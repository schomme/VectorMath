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
        private Vector _FirstVector;
        private Vector _SecondVector;
        private Vector _ResultVector;
        private CalcMode _calcMode;
        

        public MainViewModel()
        {
            this.FirstVector = new Vector();
            this.SecondVector = new Vector();
            this.ResultVector = new Vector();
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
                    OnPropertyRaised();
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
                    OnPropertyRaised();
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
                    OnPropertyRaised();
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
                    OnPropertyRaised();
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
                    OnPropertyRaised();
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
                    OnPropertyRaised();
                }
            }
        }

        public double Xr
        {
            get
            {
                return ResultVector.X;
            }
            private set
            {
                if (value != ResultVector.X)
                {
                    _ResultVector.X = value;
                    OnPropertyRaised();
                }
            }
        }

        public double Yr
        {
            get
            {
                return ResultVector.Y;
            }
            private set
            {
                if (value != ResultVector.Y)
                {
                    _ResultVector.Y = value;
                    OnPropertyRaised();
                }
            }
        }

        public double Zr
        {
            get
            {
                return ResultVector.Z;
            }
            private set
            {
                if (value != ResultVector.Z)
                {
                    _ResultVector.Z = value;
                    OnPropertyRaised();
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
    }
}
