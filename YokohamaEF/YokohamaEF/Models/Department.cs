using System.ComponentModel.DataAnnotations;
namespace YokohamaEF.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณากรอกชื่อแผนก" )]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        //Navigation Property - 1 Department มีหลาย Employee
        public List<Employee> Employees { get; set; } = new();
    }
}
