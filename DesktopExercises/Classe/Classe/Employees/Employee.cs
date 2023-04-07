using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Employees
{
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }

        public Employee(string fName, string lName, string number)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.SocialSecurityNumber = number;
        }
        public abstract decimal CalculateEarnings();
       
        public override string ToString()
        {
            return $"Social Security Number: {SocialSecurityNumber}, {FirstName.ToUpper()} {LastName.ToUpper()}";
        }
    }
}
