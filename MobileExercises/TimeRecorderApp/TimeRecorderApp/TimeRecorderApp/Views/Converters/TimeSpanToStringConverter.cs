using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TimeRecorderApp.Views.Converters
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (TimeSpan)value;
            string format = @"d\D\ hh\h\ mm";
            if(System.Convert.ToInt32(parameter) == 1)
            {
                format = @"hh\:mm";
            }
            else if (System.Convert.ToInt32(parameter) == 2)
            {
                format = "ss";
            }
            return $"{time.ToString(format, culture.DateTimeFormat)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
