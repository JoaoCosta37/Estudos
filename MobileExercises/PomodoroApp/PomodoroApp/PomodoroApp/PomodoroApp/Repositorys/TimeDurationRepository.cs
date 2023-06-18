using PomodoroApp.DAL;
using PomodoroApp.Models;
using PomodoroApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroApp.Repositorys
{
    public class TimeDurationRepository
    {
        PomodoroDataBase database;

        public TimeDurationRepository()
        {
            database = PomodoroDataBase.Instance.GetAwaiter().GetResult();
        }
        public Task<List<TimeDuration>> GetTimeDurationListAsync()
        {
            var result = database.Database.Table<TimeDuration>().ToListAsync();
            if (result.Result.Count == 0)
            {
                //result = new Task<List<TimeDuration>>(new List<TimeDuration>()
                //{
                //    new TimeDuration(){TimeType=Enums.TimeType.Pomodoro, Duration=TimeSpan.FromMinutes(40)},
                //    new TimeDuration(){TimeType=Enums.TimeType.Short, Duration=TimeSpan.FromMinutes(5)},
                //    new TimeDuration(){TimeType=Enums.TimeType.Long, Duration=TimeSpan.FromMinutes(20)},
                //} );
                var timeL = new List<TimeDuration>()
                {
                    new TimeDuration(){TimeType=Enums.TimeType.Pomodoro, Duration=TimeSpan.FromMinutes(40)},
                    new TimeDuration(){TimeType=Enums.TimeType.Short, Duration=TimeSpan.FromMinutes(5)},
                    new TimeDuration(){TimeType=Enums.TimeType.Long, Duration=TimeSpan.FromMinutes(20)},
                };
                foreach(var time in timeL)
                {
                    time.Id = SaveTimeDurationAsync(time).Result;
                }
                result = Task.FromResult(timeL);
            }
            return result;
        }

        public Task<int> SaveTimeDurationAsync(Models.TimeDuration item)
        {
            if (item.Id != 0)
            {
                return database.Database.UpdateAsync(item);
            }
            else
            {
                return database.Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteTimeDurationAsync(Models.BackgColor item)
        {
            return database.Database.DeleteAsync(item);
        }
    }
}
