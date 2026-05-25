using System.ComponentModel.DataAnnotations;

namespace YokohamaMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        [StringLength(100, ErrorMessage = "ชื่อไม่สามารถเกิน 100 ตัวอักษร")]
        public string? Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณากรอกแผนก")]
        public string? Department { get; set; } = string.Empty;

        [Range(0, 9999999, ErrorMessage = "เงินเดือนต้องอยู่ระหว่าง 0 - 9,999,999 ")]
        public decimal Salary { get; set; }
        
        [Range(0,9999,ErrorMessage ="Hourly Rate ต้องอยู่ระหว่าง 0 - 9,999")]
        public double HourlyRate { get; set; }
        
        [Range(0,744,ErrorMessage = "ชั่วโมงต้องอยู่ต้องระหว่าง 0 - 744")]
        public int HoursWorked { get; set; }
    }
}