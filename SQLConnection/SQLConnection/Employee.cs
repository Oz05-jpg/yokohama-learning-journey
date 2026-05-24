using System;
using System.Collections.Generic;
using System.Text;

namespace SQLConnection
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public decimal Salary { get; set; }
    }
}
