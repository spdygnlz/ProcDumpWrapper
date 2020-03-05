using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ProcDumpWrapper.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public Brush TrueBrush { get; set; } = new SolidColorBrush(Colors.Green);
        public Brush FalseBrush { get; set; } = new SolidColorBrush(Colors.DarkSlateGray);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool myValue)
            {
                return myValue ? TrueBrush : FalseBrush;
            }

            return FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
