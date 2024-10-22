using PomodoroApp.Enums;
using PomodoroApp.Models;
using PomodoroApp.Singles;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PomodoroApp.Factory
{
    public static class AlterValueFactory
    {
        private static int index;
        public static string PropertyName;
        public static decimal GetValue()
        {
            if (PropertyName == ValuesToAlter.POMODORO.ToString() || PropertyName == ValuesToAlter.SHORT.ToString() || PropertyName == ValuesToAlter.LONG.ToString())
            {
                //PropertyName = nameof(PomodoroControl.Durations);
                index = (int)Enum.Parse(typeof(TimeType), PropertyName);
                var result = (decimal)PomodoroControlInstance.Instance.Durations[index].TimeDuration.Duration.TotalMinutes;
                return result;
            }
            else if (PropertyName == ValuesToAlter.GOAL.ToString())
            {
                return PomodoroControlInstance.Instance.DailyGoal;
            }
            else if (PropertyName == ValuesToAlter.BEFORE.ToString())
            {
                return PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak;
            }
            else return 0;
        }
        public static void SaveNewValue(decimal newValue)
        {
            if(PropertyName == ValuesToAlter.POMODORO.ToString() || PropertyName == ValuesToAlter.SHORT.ToString() || PropertyName == ValuesToAlter.LONG.ToString())
            {
                PomodoroControlInstance.Instance.Durations[index].TimeDuration.Duration = TimeSpan.FromMinutes((double)newValue);
            }
            else if (PropertyName == "GOAL")
            {
                PomodoroControlInstance.Instance.DailyGoal = (int)newValue;
            }
            else if (PropertyName == ValuesToAlter.BEFORE.ToString())
            {
                PomodoroControlInstance.Instance.PomodoroTimesBeforeLongBreak = (int)newValue;
            }
        }
    }
}
