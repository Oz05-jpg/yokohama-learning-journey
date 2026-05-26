using System.ComponentModel.DataAnnotations;

namespace YokohamaEF.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        [Range(0, 9999)]
        public double HourlyRate { get; set; }

        [Range(0, 744)]
        public int HoursWorked { get; set; }
        [Range(0, 999999)]
        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }
        public Department? DepartmentNav { get; set; }

    }
}
