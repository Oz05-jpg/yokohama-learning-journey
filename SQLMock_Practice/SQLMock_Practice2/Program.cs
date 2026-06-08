using Microsoft.Data.SqlClient;
using System.Data;

namespace SQLMock_Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ตัวอย่างการเรียกใช้ GetRepairLogs
            var employees = GetEmployees("Rayong");
            foreach (var emp in employees)//วนลูปเพื่อแสดงข้อมูลพนักงานที่ดึงมาจากฐานข้อมูล
            {
                Console.WriteLine($"Department: {emp.DeptName}, " +
                    $"Location: {emp.Location}, " +
                    $"Name: {emp.FullName}, " +
                    $"Position: {emp.Position}, " +
                    $"Hire Date: {emp.HireDate.ToShortDateString()}");
            }
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
        }


        // สร้างคลาส ViewModel เพื่อเก็บข้อมูลที่ดึงมาจากฐานข้อมูล
        class EmployeeViewModel
        {
            public string DeptName { get; set; }
            public string Location { get; set; }  // ← เพิ่ม
            public string FullName { get; set; }
            public string Position { get; set; }
            public DateTime HireDate { get; set; }
        }

        static List<EmployeeViewModel> GetEmployees(string department)
        {
            var list = new List<EmployeeViewModel>();
            //connect to database
            using (var conn = new SqlConnection("server = localhost\\SQLEXPRESS01; database = YokohamaDB; Trusted_Connection = true; TrustServerCertificate = True; "))

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetEmployeesByLocation";//กำหนดชื่อของ Stored Procedure ที่ต้องการเรียกใช้
                cmd.CommandType = CommandType.StoredProcedure;//กำหนดว่าเป็นการเรียกใช้ Stored Procedure ใน SSMS
                cmd.Parameters.AddWithValue("@Location", department);//กำหนดค่าพารามิเตอร์ที่ส่งไปยัง Stored Procedure

                conn.Open();//เปิดการเชื่อมต่อกับฐานข้อมูล

                // ExecuteScalar ใช้สำหรับดึงค่าผลลัพธ์เดียวจากฐานข้อมูล เช่น จำนวนแถว หรือค่าเฉพาะที่ต้องการ
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new EmployeeViewModel
                    {
                        DeptName = reader["DeptName"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Location = reader["Location"].ToString(),  // ← เพิ่ม
                        Position = reader["Position"].ToString(),
                        HireDate = Convert.ToDateTime(reader["HireDate"]),
                    });
                }
            }
            return list;

        }
    }
}
