using PomodoroApp.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PomodoroApp.Views.Converters
{
    public class TimeTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var timeT = (TimeType)value;
            //switch (timeT)
            //{
            //    //case TimeType.Pomodoro:
            //    //    return timeT.ToString();
            //}
                return "HELOO";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
