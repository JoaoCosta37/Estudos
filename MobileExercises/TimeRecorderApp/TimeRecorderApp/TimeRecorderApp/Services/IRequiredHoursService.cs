using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeRecorderApp.Services
{
    public interface IRequiredHoursService
    {
        TimeSpan GetRequiredHours(DateTime currentDate);
    }
}
