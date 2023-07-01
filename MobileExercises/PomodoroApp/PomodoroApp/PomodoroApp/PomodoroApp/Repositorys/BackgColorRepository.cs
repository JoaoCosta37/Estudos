using PomodoroApp.DAL;
using PomodoroApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PomodoroApp.Repositorys
{
    public class BackgColorRepository
    {
        PomodoroDataBase database;

        public BackgColorRepository()
        {
            database = PomodoroDataBase.Instance.GetAwaiter().GetResult();
        }
        public Task<BackgColor> GetBackgColor()
        {
            var result = database.Database.Table<BackgColor>().FirstOrDefaultAsync();
            if (result.Result == null)
            {
                //this.DeleteBackgColorAsync(result.Result);
                setDefault();
                return GetBackgColor();
            }
            return result;
        }
        private void setDefault()
        {
            var bc = new BackgColor() { Color = Color.FromHex("#4f3960") };
            this.SaveBackgColorAsync(bc);
        }
        //public Task<List<BackgColor>> GetClients()
        //{
        //    return database.Database.Table<BackgColor>().ToListAsync();
        //}
        public Task<int> SaveBackgColorAsync(Models.BackgColor item)
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

        public Task<int> DeleteBackgColorAsync(Models.BackgColor item)
        {
            return database.Database.DeleteAsync(item);
        }
    }
}
