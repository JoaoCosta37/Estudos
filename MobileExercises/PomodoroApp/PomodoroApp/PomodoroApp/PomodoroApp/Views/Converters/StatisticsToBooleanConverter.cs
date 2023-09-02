using ImTools;
using PomodoroApp.Enums;
using PomodoroApp.Singles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;

namespace PomodoroApp.Views.Converters
{
    public class StatisticsToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int initialPosition = -1;
            var progress = (int)value;
            var param = (string)parameter;
            if (progress == initialPosition)
            {
                return false;
            }
            var resulçt = (int)Enum.Parse(typeof(TimeType), param);
            if ((int)Enum.Parse(typeof(TimeType), param) <= progress)
            {
                return true;
            }
            return false;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
