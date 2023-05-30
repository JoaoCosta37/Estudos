using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PomodoroApp.Views.Converters
{
    internal class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (TimeSpan)value;
            string format = @"mm\:ss";
            //if (System.Convert.ToInt32(parameter) == 1)
            //{
            //    format = @"hh\:mm";
            //}
            //else if (System.Convert.ToInt32(parameter) == 2)
            //{
            //    format = "ss";
            //}
            return $"{time.ToString(format, culture.DateTimeFormat)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
