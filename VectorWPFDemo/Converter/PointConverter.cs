using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Media3D;
using VectorLib;

namespace _3DVectorMath.Converter
{
    [ValueConversion(typeof(Point3DCollection), typeof(Vector))]
    internal class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as Vector;
            return v == null ? new Point3D(0, 0, 0) : new Point3D(v.X, v.Y, v.Z);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Point3D p)
            {
                return new Vector(p.X, p.Y, p.Z);
            }
            return new Vector();
        }
    }
}
