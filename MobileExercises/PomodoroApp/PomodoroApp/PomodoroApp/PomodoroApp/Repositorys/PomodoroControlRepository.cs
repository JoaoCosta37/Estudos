using PomodoroApp.DAL;
using PomodoroApp.Models;
using System;
using System.Collections.Generic;
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
                var control = new PomodoroControl();
                control.Id = this.SavePomodoroControlAsync(control).Result;
                result = control;
            }
            return Task.FromResult(result);
        }
        public Task<int> SavePomodoroControlAsync(Models.PomodoroControl item)
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

        public Task<int> DeletePomodoroControlAsync(Models.BackgColor item)
        {
            return database.Database.DeleteAsync(item);
        }
    }
}
