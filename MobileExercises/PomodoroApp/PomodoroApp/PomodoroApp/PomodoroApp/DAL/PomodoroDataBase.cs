using PomodoroApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.DAL
{
    public class PomodoroDataBase
    {
        public SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<PomodoroDataBase> Instance = new AsyncLazy<PomodoroDataBase>(async () =>
        {
            var instance = new PomodoroDataBase();
            var result = await instance.Database.CreateTablesAsync<BackgColor, TimeDuration, PomodoroControl>();
            return instance;
        });
        public PomodoroDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
    }
}
