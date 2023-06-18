using PomodoroApp.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Models
{
    public class TimeDuration
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public TimeType TimeType { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
