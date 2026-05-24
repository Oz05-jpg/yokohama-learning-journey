using System;
using System.Collections.Generic;
using System.Text;

namespace OTCalculator
{
    public class OTRecord
    {
        // Properties to hold the data for each record
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public double BasePay { get; set; }
        public double OTPay { get; set; }
        public double TotalPay { get; set; }
        public DateTime RecordedAt { get; set; }

    }
}
