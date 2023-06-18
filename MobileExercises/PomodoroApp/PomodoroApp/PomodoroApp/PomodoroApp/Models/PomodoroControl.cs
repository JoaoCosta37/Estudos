using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Models
{
    public class PomodoroControl
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int Count { get; set; }
        public bool PomodoroFinished { get; set; }
        public bool CanLongTime { get; set; }
    }
}
