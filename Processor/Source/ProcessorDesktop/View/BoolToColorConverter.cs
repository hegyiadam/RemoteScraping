using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ProcessorDesktop.View
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    public class BoolToColorConverter : IValueConverter
    {
        private readonly Color greenColor = Color.FromRgb(51, 201, 28);
        private readonly Color redColor = Color.FromRgb(201, 28, 28);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool statement = (bool)value;
            if (statement)
            {
                return new SolidColorBrush(greenColor);
            }
            return new SolidColorBrush(redColor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}