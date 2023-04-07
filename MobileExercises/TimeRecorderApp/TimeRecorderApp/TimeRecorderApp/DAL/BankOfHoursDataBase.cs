using ImTools;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeRecorderApp.Models;

namespace TimeRecorderApp.DAL
{
    public class BankOfHoursDataBase
    {
        static SQLiteAsyncConnection Database;
        public static readonly AsyncLazy<BankOfHoursDataBase> Instance = new AsyncLazy<BankOfHoursDataBase>(async () =>
        {
            var instance = new BankOfHoursDataBase();
            CreateTableResult result = await Database.CreateTableAsync<BankOfHoursData>();
            return instance;
        });
        public BankOfHoursDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<BankOfHoursData> GetBankAsync()
        {
            return Database.Table<BankOfHoursData>().FirstOrDefaultAsync();
        }
        public Task<int> SaveBankAsync(BankOfHoursData item)
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

        public Task<int> DeleteBankAsync(BankOfHoursData item)

        {
            return Database.DeleteAsync(item);
        }
    }
}
