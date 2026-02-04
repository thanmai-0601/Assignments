using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//fields and properties
//zero arg constructors
//parameterized constructors
//methods but not usiness logics
namespace Employee
{
    public class Emp
    {
        public Emp()
        {
            
        }
        private double bal;

        public double Bal
        {
            get { return bal; }
            set { bal = value; }
        }

        public int EmpId { get; set; }

        private string empname;

        public string EmpName
        {
            get { return empname; }
            set
            {
                if (value.Length > 10)
                {
                    throw new ApplicationException();
                }
                empname = value;
            }
        }


        public decimal EmpSalary { get; set; }
        public Emp(int empid, string empName, decimal empSalary)
        {
            EmpId = empid;
            EmpName = empName;
            EmpSalary = empSalary;
        }
        public override string ToString()
        {
            string result = string.Empty;
            result = $"Emp Id: {EmpId}, Emp Name: {EmpName}, Emp Salary: {EmpSalary}";
            return result;
        }
    }
}
