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
        public int Count { get; set; }
        public bool PomodoroFinished { get; set; }
        public int DailyTotal { get; set; }
        public int PomodoroTimesBeforeLongPause { get; set; }


        [Column("Durations")]
        public string DurationsJson { get; set; }
        [Ignore]
        public List<TimeDuration> Durations
        {
            get { return JsonConvert.DeserializeObject<List<TimeDuration>>(DurationsJson); }
            set { DurationsJson = JsonConvert.SerializeObject(value);}
        }


        [Column("CurrentType")]
        private int currentType { get; set; }

        [Ignore]
        public TimeType CurrentType
        {
            get => (TimeType)currentType;
            set
            {
                currentType = (int)value;
            }
        }
    }
}
