using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Employees
{
    public class SalariedEmployee : Employee
    {
        private decimal weeklySalary;
        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(weeklySalary)} must be greather than or equals zero");
                }

                this.weeklySalary = value;
            }
        }

        // should - poderia / deveria  
        // would - quero/gostaria
        // must - deve
        // can - posso

        public SalariedEmployee(string firstName, string lastName, string SocialSecurityNumber, decimal weeklySalary) : base(firstName, lastName, SocialSecurityNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SocialSecurityNumber = SocialSecurityNumber;
            this.WeeklySalary = weeklySalary;
        }
        public override decimal CalculateEarnings()
        {
            return WeeklySalary;
        }
        public override string ToString()
        {
            return  "salaried employee:" + base.ToString();
        }
    }
}
