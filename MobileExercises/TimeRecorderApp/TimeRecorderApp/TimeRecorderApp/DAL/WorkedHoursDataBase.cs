using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using TimeRecorderApp.Models;
using Xamarin.CommunityToolkit.Behaviors;

namespace TimeRecorderApp.DAL
{
    public class WorkedHoursDataBase
    {
        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<WorkedHoursDataBase> Instance = new AsyncLazy<WorkedHoursDataBase>(async () =>
        {
            var instance = new WorkedHoursDataBase();
            CreateTableResult result = await Database.CreateTableAsync<WorkedHoursData>();
            return instance;
        });
        public WorkedHoursDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<WorkedHoursData> GetWorkedHoursAsync(DateTime currentDate)
        {
            var startOfMonth = new DateTime (currentDate.Year, currentDate.Month, 1);
            var endOfMonth = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
            //var result = Database.Table<WorkedHoursData>().FirstOrDefaultAsync().Result;
            return Database.Table<WorkedHoursData>().Where(i => i.Date >= startOfMonth  && i.Date <= endOfMonth).FirstOrDefaultAsync();
            //if(result != null)
            //{
            //}
            //return null;
            //return Database.QueryAsync<WorkedHoursData>("SELECT * FROM [WorkedHoursData] WHERE (strftime('%Y', Date) = " + currentDate.Year + " AND strftime('%m', Date) =" + currentDate.Month +")");
            //var test = Database.QueryAsync<WorkedHoursData>("SELECT * FROM [WorkedHoursData] WHERE ( YEAR([Date]) = " + currentDate.Year + " AND MONTH([Date]) = " + currentDate.Month + ")");K

            //var command = new SQLiteCommand(new SQLiteConnection(new SQLiteConnectionString(query)));
            //command.
            //return test;

            //var test = from i in Database.Table<WorkedHoursData>() where i.Date.Month == currentDate.Month && i.Date.Year == currentDate.Year select i;
        }

        public Task<int> SaveWorkedHoursAsync(WorkedHoursData item)
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

        public Task<int> DeleteWorkedHoursAsync(WorkedHoursData item)

        {
            return Database.DeleteAsync(item);
        }
    }
}
