using DryIoc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Concurrency;
using System.Text;
using TimeRecorderApp.DAL;
using TimeRecorderApp.Models;
using TimeRecorderApp.Services;

namespace TimeRecorderApp.Singles
{
    public class BankOfHours
    {
        private static BankOfHoursDataBase databaseBank;
        private static WorkedHoursDataBase databaseWorkedH;
        public static IRequiredHoursService Instance { get; set; }
        private static TimeSpan requiredHours;
        public static TimeSpan CurrentBank { get; set; }
        private static WorkedHoursData workedHoursData;

        public static void SetCurrentBank()
        {
            databaseBank = BankOfHoursDataBase.Instance.GetAwaiter().GetResult();
            databaseWorkedH = WorkedHoursDataBase.Instance.GetAwaiter().GetResult();
            workedHoursData = getWorkedHours();

            setRiquiredHours();

            var bankOfHoursData = databaseBank.GetBankAsync().Result;
            if (bankOfHoursData == null)
            {
                BankOfHoursData data = new BankOfHoursData() { LastAtualization = DateTime.Now };
                var id = databaseBank.SaveBankAsync(data).Result;
                bankOfHoursData = data;
                bankOfHoursData.Id = id;
            }

            //bankOfHoursData.Current = new TimeSpan();
            //databaseBank.SaveBankAsync(bankOfHoursData);

            //workedHoursData.WorkedHours = requiredHours;
            //databaseWorkedH.SaveWorkedHoursAsync(workedHoursData);


            //bankOfHoursData.Current = requiredHours;
            CalculateBank(bankOfHoursData);

        }

        private static void CalculateBank(BankOfHoursData bankOfHoursData)
        {
            CurrentBank = (workedHoursData.WorkedHours - requiredHours) + bankOfHoursData.Current;
        }

        private static WorkedHoursData getWorkedHours()
        {

            var workedHoursDatabase = WorkedHoursDataBase.Instance.GetAwaiter().GetResult();

            var workedHours = workedHoursDatabase.GetWorkedHoursAsync(DateTime.Now).Result;
            if (workedHours == null)
            {
                WorkedHoursData data = new WorkedHoursData() { Date = DateTime.Now };
                var id = workedHoursDatabase.SaveWorkedHoursAsync(data).Result;
                    workedHours = data;
                    workedHours.Id = id;
            }
            return workedHours;

        }
        private static void setRiquiredHours()
        {
            requiredHours = Instance.GetRequiredHours(DateTime.Now);
        }

        public static void UpdateBankOfHours(TimeSpan time)
        {
            workedHoursData.WorkedHours += time;
            databaseWorkedH.SaveWorkedHoursAsync(workedHoursData);

            var bankOfHoursData = databaseBank.GetBankAsync().Result;
            CalculateBank(bankOfHoursData);

            bankOfHoursData.Current = CurrentBank;
            databaseBank.SaveBankAsync(bankOfHoursData);
        }

    }
 
}
