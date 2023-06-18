using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PomodoroApp.Models
{
    public class BackgColor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Color { get; set; }
    }
}
