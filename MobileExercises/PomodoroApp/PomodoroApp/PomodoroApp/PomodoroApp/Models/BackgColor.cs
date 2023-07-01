using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PomodoroApp.Models
{
    public class BackgColor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("Color")]
        public string ColorHex { get; set; }
        [Ignore]
        public Color Color
        {
            get => Color.FromHex(ColorHex);
            set => ColorHex = value.ToHex();
        }
    }
}
