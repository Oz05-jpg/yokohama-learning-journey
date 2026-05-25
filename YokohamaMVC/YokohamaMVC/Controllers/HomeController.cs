using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using YokohamaMVC.Models;

namespace YokohamaMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = "โอ";
            ViewBag.Role = "IT Developer";
            ViewBag.Goal = "Yokohama 2027";
            return View();
        }

        public IActionResult Employees()
        {
            var list = new List<Employee>();
            string connStr =
                "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=YokohamaDB;" +
                "Trusted_Connection=True;TrustServerCertificate=True;";

            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("SELECT Id, Name, Department, HourlyRate, HoursWorked, Salary FROM Employees", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Employee
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Department = reader["Department"].ToString(),
                    HourlyRate = (double)reader["HourlyRate"],
                    HoursWorked = Convert.ToInt32(reader["HoursWorked"]),
                    Salary = (decimal)reader["Salary"]
                });
            }

            return View(list);
        }

        //สร้างฟอร์มเพิ่มพนักงาน
        public IActionResult Create()
        {
            return View();
        }
        //รับข้อมูลจากฟอร์มและแสดงผลในหน้า Employees
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {   
            if (!ModelState.IsValid)
            {
                return View("Create", employee);
            }

            try
            {
                string connStr =
                    "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=YokohamaDB;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;";
                using var conn = new SqlConnection(connStr);
                conn.Open();
                var cmd = new SqlCommand(
                "INSERT INTO Employees (Name, Department, HourlyRate, HoursWorked, Salary) VALUES (@Name, @Department, @HourlyRate, @HoursWorked, @Salary)",
                 conn);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@HourlyRate", employee.HourlyRate);
                cmd.Parameters.AddWithValue("@HoursWorked", employee.HoursWorked);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return Content($"เกิดข้อผิดพลาด: {ex.Message}");
            }
            return RedirectToAction("Employees");
        }

        //แสดงฟอร์มแก้ไขพนักงาน
        public IActionResult Edit(int id)
        {
            string connStr =
        "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=YokohamaDB;" +
        "Trusted_Connection=True;TrustServerCertificate=True;";

            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Employees WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            reader.Read();

            var emp = new Employee
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Department = reader["Department"].ToString(),
                HourlyRate = (double)reader["HourlyRate"],
                HoursWorked = Convert.ToInt32(reader["HoursWorked"]),
                Salary = (decimal)reader["Salary"]
            };

            return View(emp);
        }

        //รับข้อมูลจากฟอร์มแก้ไขและอัปเดตในฐานข้อมูล
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                string connStr =
                    "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=YokohamaDB;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;";
                using var conn = new SqlConnection(connStr);
                conn.Open();
                var cmd = new SqlCommand(
                "UPDATE Employees SET Name = @Name, Department = @Department, " +
                "HourlyRate = @HourlyRate, HoursWorked = @HoursWorked, " +
                "Salary = @Salary WHERE Id = @Id",
                 conn);
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@HourlyRate", employee.HourlyRate);
                cmd.Parameters.AddWithValue("@HoursWorked", employee.HoursWorked);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return Content($"เกิดข้อผิดพลาด: {ex.Message}");
            }
            return RedirectToAction("Employees");
        }

        //ลบพนักงาน
        public IActionResult Delete(int id)
        {
            try
            {
                string connStr =
                    "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=YokohamaDB;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;";
                using var conn = new SqlConnection(connStr);
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Employees WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return Content($"เกิดข้อผิดพลาด: {ex.Message}");
            }
            return RedirectToAction("Employees");
        }
    }
}