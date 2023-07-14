using PomodoroApp.Enums;
using PomodoroApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PomodoroApp.Views.Converters
{
    public class TimeListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (List<TimeDuration>)value;
            var timeType = (string)parameter;

            var timeDuration = list.Where((x) => Enum.GetName(typeof(TimeType), x.TimeTypeValue) == timeType).FirstOrDefault();
            return timeDuration.Duration.ToString("mm", culture.DateTimeFormat);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
