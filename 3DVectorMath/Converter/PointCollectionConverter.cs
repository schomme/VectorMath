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
    [ValueConversion(typeof(System.Windows.Media.Media3D.Point3DCollection), typeof(Vector))]
    public class PointCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var points = new Point3DCollection();

            points.Add(new Point3D(0, 0, 0));
            var vector = value as Vector;
            points.Add(new Point3D(vector.X, vector.Y, vector.Z));
            return points;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var points = value as Point3DCollection;
            var source = points?.First() ?? new Point3D(0, 0, 0);
            var target = points.Last();
            return new Vector(target.X - source.X, source.Y - target.Y, source.Z - source.Z);


        }
    }
}
