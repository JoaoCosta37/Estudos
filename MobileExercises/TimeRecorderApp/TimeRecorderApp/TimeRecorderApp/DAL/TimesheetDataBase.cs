using DryIoc.Messages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeRecorderApp.Models;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.Forms.Internals;

namespace TimeRecorderApp.DAL
{
    public class TimesheetDataBase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TimesheetDataBase> Instance = new AsyncLazy<TimesheetDataBase>(async () =>
        {
            var instance = new TimesheetDataBase();
            CreateTableResult result = await Database.CreateTableAsync<TimesheetData>();

            return instance;
        });
        public TimesheetDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<TimesheetData> GetTimesheetByIdAsync(int id)
        {
            return Database.Table<TimesheetData>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<TimesheetData> GetTimesheetAsync(string timerDate)
        {
            return Database.Table<TimesheetData>().Where(i => i.TimerDate == timerDate && !i.Ended).FirstOrDefaultAsync();
        }
        public Task<int> SaveTimesheetAsync(TimesheetData item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteTimesheetAsync(TimesheetData item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
