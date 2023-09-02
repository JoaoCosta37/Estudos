using Newtonsoft.Json;
using PomodoroApp.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.Models
{
    public class PomodoroControl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CountToLongBreak { get; set; }
        public int DailyCount { get; set; }
        //public int DailyTotal { get; set; }
        public int DailyGoal { get; set; }
        public int Progress { get; set; }
        public int PomodoroTimesBeforeLongBreak { get; set; }

        //public bool PomodoroFinished { get; set; }

        [Column("Durations")]
        public string DurationsJson { get
            {
               return JsonConvert.SerializeObject(Durations);
            }
            set
            {
                Durations = JsonConvert.DeserializeObject<List<TimeDuration>>(value);
            }
        }

        [Ignore]
        public List<TimeDuration> Durations { get; set; }


        [Column("CurrentType")]
        public int TimeTypeValue { get; set; }
    }
}
