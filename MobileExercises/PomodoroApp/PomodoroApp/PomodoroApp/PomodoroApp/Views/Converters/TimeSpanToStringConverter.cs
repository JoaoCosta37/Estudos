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
            if(time >= TimeSpan.FromMinutes(60))
            {
                format = @"hh\:mm\:ss";
            }
            if (System.Convert.ToInt32(parameter) == 1)
            {
                //format = time.TotalMinutes >= 10 ? "mm" : "%m";
               var result =  time.TotalMinutes.ToString();  
                return result;
            }
            return $"{time.ToString(format, culture.DateTimeFormat)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
