using PomodoroApp.Enums;
using PomodoroApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace PomodoroApp.Views.Converters
{
    public class TimeListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (List<TimeDurationViewModel>)value;
            var timeType = (string)parameter;

            var timeDuration = list.Where((x) => Enum.GetName(typeof(TimeType), x.TimeType) == timeType).FirstOrDefault();
            //var format = timeDuration.Duration.TotalMinutes >= 10 ? "mm" : "%m";
            return timeDuration.Duration.TotalMinutes.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
