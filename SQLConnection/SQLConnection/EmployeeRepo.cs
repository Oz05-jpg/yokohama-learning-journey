using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Data.SqlClient;

namespace SQLConnection
{
    internal class EmployeeRepo
    {
        private string _connStr = "Server=localhost\\SQLEXPRESS01;Database=YokohamaDB;Trusted_Connection=True;Encrypt=False;";

        public List<Employee> GetAll()
        {
            //คือการสร้าง List ของ Employee เพื่อเก็บข้อมูลที่ดึงมาจากฐานข้อมูล
            var list = new List<Employee>();
            using var conn = new SqlConnection(_connStr);
            conn.Open();

            //คือการสร้างคำสั่ง SQL เพื่อดึงข้อมูลจากตาราง Employees ในฐานข้อมูล
            var cmd = new SqlCommand("SELECT Id, Name, Department, HourlyRate, HoursWorked, Salary FROM Employees", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Employee
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Department = reader["Department"].ToString(),
                    HourlyRate = Convert.ToDecimal(reader["HourlyRate"]),
                    HoursWorked = Convert.ToInt32(reader["HoursWorked"]),
                    Salary = (decimal)reader["Salary"]
                });
            }
            return list;

        }

    }
}
