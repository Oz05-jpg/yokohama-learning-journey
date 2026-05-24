namespace YokohamaMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public decimal Salary { get; set; }
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }
    }
}