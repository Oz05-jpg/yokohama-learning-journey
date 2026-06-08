using Microsoft.Data.SqlClient;
using System.Data;
namespace SQLMock_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ตัวอย่างการเรียกใช้ GetRepairLogs
            var logs = GetRepairLogs("Production");
            foreach (var log in logs)
            {
                Console.WriteLine($"Machine: {log.MachineName}, Technician: {log.TechnicianName}, Date: {log.RepairDate}, Status: {log.Status}");
            }
        }


        class RepairLogViewModel
        {
            public string MachineName { get; set; }
            public string TechnicianName { get; set; }
            public DateTime RepairDate { get; set; }
            public string Status { get; set; }
        }

        static List<RepairLogViewModel> GetRepairLogs(string department)
        {
            var list = new List<RepairLogViewModel>();

            using (var conn = new SqlConnection("server = localhost\\SQLEXPRESS01; database = YokohamaDB; Trusted_Connection = true; TrustServerCertificate = True; "))
            using (var cmd = new SqlCommand("GetRepairLogsByDept", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Department", department);

                conn.Open();
                var reader = cmd.ExecuteReader();//คือการส่งคำสั่ง SQL ไปยังฐานข้อมูลและรับผลลัพธ์กลับมาในรูปแบบของ SqlDataReader

                while (reader.Read())
                {
                    list.Add(new RepairLogViewModel
                    {
                        MachineName = reader["MachineName"].ToString(),
                        TechnicianName = reader["TechnicianName"].ToString(),
                        RepairDate = Convert.ToDateTime(reader["RepairDate"]),
                        Status = reader["Status"].ToString()
                    });
                }

            }
            return list;
        }
    }
}

