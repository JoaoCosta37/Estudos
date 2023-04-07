using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeRecorderApp.Models
{
    public class TimesheetData
    {
        public TimesheetData()
        {
            this.TimerDate = DateTime.Now.ToString("yyyyMMdd");
            this.Ended = false;
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TimerDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime PauseTime { get; set; }
        public bool IsRunning { get; set; }
        public DateTime EndTime { get; set; }
        public bool Ended { get; set; }
        public TimeSpan TotalPauses { get; set; }

    }
}
