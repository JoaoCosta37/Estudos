using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeRecorderApp.DAL;
using TimeRecorderApp.Models;

namespace TimeRecorderApp.Services
{
    public class RequiredHoursService : IRequiredHoursService
    {
        public TimeSpan GetRequiredHours(DateTime currentDate)
        {
            TimeSpan requiredHours;
            int day = 1;
            var auxiliarDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            while(day <= currentDate.Day)
            {
                var dayOfWeek = auxiliarDate.DayOfWeek;
                if(dayOfWeek != DayOfWeek.Sunday && dayOfWeek != DayOfWeek.Saturday)
                {
                    requiredHours += TimeSpan.FromHours(8);
                }
                day++;
            }
            return requiredHours;
        }
    }
}
