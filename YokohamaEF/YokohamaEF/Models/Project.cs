using System.ComponentModel.DataAnnotations;
namespace YokohamaEF.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณากรอกชื่อ Project")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        //Navigation Property -> หลาย Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
