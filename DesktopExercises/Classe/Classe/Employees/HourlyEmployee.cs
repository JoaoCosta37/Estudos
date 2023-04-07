using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Employees
{
    public class HourlyEmployee : Employee
    {
        private decimal hourlyWage;
        private decimal hoursWorked;

        public decimal HourlyWage
        {
            get { return hourlyWage; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException($"{nameof(hourlyWage)} must be greather than or equals zero");
                }
                hourlyWage = value;
            }
        }
        public decimal HoursWorked
        {
            get { return hoursWorked; }
            set
            {
                if(value < 0 || value > 168)
                {
                    throw new ArgumentException($"{nameof(hoursWorked)} must be greather than or equals zero");
                }
                hoursWorked = value;
            }
        }

        public HourlyEmployee(string firstName, string lastName, string socialSecurityNumber, decimal hourlyWage, decimal hoursWorked) : base(firstName, lastName, socialSecurityNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.HourlyWage = hourlyWage;
            this.HoursWorked = hoursWorked;
        }
        public override string ToString()
        {
            return "hourly employee:" + base.ToString();
        }

        public override decimal CalculateEarnings()
        {
            return HoursWorked * HoursWorked;
        }
    }
}
