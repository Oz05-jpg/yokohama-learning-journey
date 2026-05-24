using Microsoft.Data.SqlClient;
using OTCalculator;
public class OTRepo
{
    // Connection string สำหรับเชื่อมต่อกับฐานข้อมูล SQL Server
    private string _connStr =
    "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=YokohamaDB;Trusted_Connection=True;TrustServerCertificate=True;";
    public void Save(string name, int hours, double rate, double basePay, double otPay, double totalPay)
    {
        using var conn = new SqlConnection(_connStr);
        conn.Open();

        var cmd = new SqlCommand(
            @"INSERT INTO OTRecords (EmployeeName, HoursWorked, HourlyRate, BasePay, OTPay, TotalPay, RecordedAt) " +
            "VALUES (@name, @hours, @rate, @basePay, @otPay, @totalPay, GETDATE())", conn);

        //เพิ่มพารามิเตอร์เพื่อป้องกัน SQL Injection และให้ค่าที่ถูกต้องกับคำสั่ง SQL
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@hours", hours);
        cmd.Parameters.AddWithValue("@rate", rate);
        cmd.Parameters.AddWithValue("@basePay", basePay);
        cmd.Parameters.AddWithValue("@otPay", otPay);
        cmd.Parameters.AddWithValue("@totalPay", totalPay);

        cmd.ExecuteNonQuery();//คือการรันคำสั่ง SQL โดยไม่ต้องการผลลัพธ์กลับมา
    }

    public List<OTRecord> GetAll()
    {
        var list = new List<OTRecord>();
        using var conn = new SqlConnection(_connStr);
        conn.Open();
        var cmd = new SqlCommand("SELECT * FROM OTRecords ORDER BY RecordedAt DESC", conn);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new OTRecord
            {
                Id = (int)reader["Id"],
                EmployeeName = reader["EmployeeName"].ToString(),
                HoursWorked = (int)reader["HoursWorked"],
                HourlyRate = (double)reader["HourlyRate"],
                BasePay = (double)reader["BasePay"],
                OTPay = (double)reader["OTPay"],
                TotalPay = (double)reader["TotalPay"],
                RecordedAt = (DateTime)reader["RecordedAt"]
            });
        }
        return list;
    }
}

