using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Division.Helpers
{
    [ValueConversion(typeof(int), typeof(Color))]
    public class FactorToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int factor = (int)value;
            switch(factor % 3)
            {
                case 0: return Color.FromRgb(0, 0, 255);
                case 1: return Color.FromRgb(0, 255, 0);
                case 2: return Color.FromRgb(255, 0, 0);
                default: return Color.FromRgb(0, 0, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
