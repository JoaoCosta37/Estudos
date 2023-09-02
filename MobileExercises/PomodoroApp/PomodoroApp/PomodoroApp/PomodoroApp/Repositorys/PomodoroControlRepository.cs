using PomodoroApp.DAL;
using PomodoroApp.Enums;
using PomodoroApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroApp.Repositorys
{
    public class PomodoroControlRepository
    {
        PomodoroDataBase database;

        public PomodoroControlRepository()
        {
            database = PomodoroDataBase.Instance.GetAwaiter().GetResult();
        }
        public Task<PomodoroControl> GetPomodoroControlAsync()
        {
            var result = database.Database.Table<PomodoroControl>().FirstOrDefaultAsync().Result;

            if (result == null)
            {
                var control = new PomodoroControl()
                {
                    PomodoroTimesBeforeLongBreak = 4,
                    Progress = -1,
                    TimeTypeValue = (int)TimeType.POMODORO,
                    Durations = new List<TimeDuration>()
                    {
                        new TimeDuration(){TimeType=Enums.TimeType.POMODORO, Duration=TimeSpan.FromMinutes(.1)},
                        new TimeDuration(){TimeType=Enums.TimeType.SHORT, Duration=TimeSpan.FromMinutes(.1)},
                        new TimeDuration(){TimeType=Enums.TimeType.LONG, Duration=TimeSpan.FromMinutes(.1)},
                    }
                };
                control.Id = this.SavePomodoroControlAsync(control).Result.Id;
                result = control;
            }
            return Task.FromResult(result);
        }
        public Task<PomodoroControl> SavePomodoroControlAsync(Models.PomodoroControl item)
        {
            //item.CurrentType = TimeType.LONG;
            //item = editList(item);
            if (item.Id != 0)
            {
                database.Database.UpdateAsync(item);
            }
            else
            {
                database.Database.InsertAsync(item);
            }
            return Task.FromResult(item);
        }

        public Task<int> DeletePomodoroControlAsync(PomodoroControl item)
        {
            return database.Database.DeleteAsync(item);
        }
        //private PomodoroControl editList(PomodoroControl item)
        //{
        //    //var newList = item.Durations;
        //    //var current = newList.FirstOrDefault((x) => x.TimeType == item.CurrentType);
        //    //newList.Remove(current);
        //    //newList.Insert(0,current);
        //    //item.Durations = newList;
        //    var current = item.Durations.FirstOrDefault((x) => x.TimeType == item.CurrentType);
        //    item.Durations.Remove(current);
        //    item.Durations.Insert(0, current);
        //    return item;
        //}
    }
}
