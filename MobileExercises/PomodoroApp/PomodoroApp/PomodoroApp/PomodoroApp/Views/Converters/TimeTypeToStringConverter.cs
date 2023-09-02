using PomodoroApp.Enums;
using PomodoroApp.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using Xamarin.Forms;

namespace PomodoroApp.Views.Converters
{
    public class TimeTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var resource = new ResourceManager(typeof(Messages));
        
            var timeT = (TimeType)value;
            switch (timeT)
            {
                case TimeType.POMODORO: return "POMODORO";
                case TimeType.SHORT:
                    return resource.GetString("SHORT", CultureInfo.CurrentCulture);
                case TimeType.LONG: return resource.GetString("LONG", CultureInfo.CurrentCulture);

            }
            return null;


            //var text = timeT switch {
            //    TimeType.POMODORO => "POMODORO",
            //    TimeType.SHORT => resource.GetString("SHORT", CultureInfo.CurrentCulture),
            //    TimeType.LONG => resource.GetString("LONG", CultureInfo.CurrentCulture),
            //    _ => null
            //};

            //return text;



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
