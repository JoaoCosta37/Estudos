using PomodoroApp.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Models
{
    public class TimeDuration
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }

        [Column("TimeType")]
        public int TimeTypeValue { get; set; }

        [Ignore]
        public TimeType TimeType
        {
            get => (TimeType)TimeTypeValue;
            set
            {
                TimeTypeValue = (int)value;
            }
        }
    }
}
