using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeRecorderApp.Models
{
    public class WorkedHoursData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan WorkedHours { get; set; }
    }
}
