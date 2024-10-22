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
            if (System.Convert.ToInt32(parameter) == 1)
            {
                var result =  time.TotalMinutes.ToString();  
                return result;
            }
            string format = @"mm\:ss";
            if (time >= TimeSpan.FromMinutes(60))
            {
                format = @"hh\:mm\:ss";
            }
            return $"{time.ToString(format, culture.DateTimeFormat)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
