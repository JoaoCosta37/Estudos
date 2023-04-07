using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeRecorderApp.Models
{
    public class BankOfHoursData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime LastAtualization { get; set; }
        public TimeSpan Current { get; set; }
    }
}
