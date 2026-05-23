using Microsoft.Data.SqlClient;
using System.Data;

// สร้างการเชื่อมต่อกับ SQL Server
string connectionString = "Server=localhost\\SQLEXPRESS01;Database=YokohamaDB;Trusted_Connection=True;Encrypt=False;";
using (SqlConnection connection = new SqlConnection(connectionString))
{

    // เปิดการเชื่อมต่อ

    connection.Open();
    Console.WriteLine("เชื่อมต่อ SQL Server สำเร็จ!");

    // ทำงานกับฐานข้อมูลที่นี่
    string query = "SELECT * FROM Employees";
    SqlCommand command = new SqlCommand(query, connection);// สร้างคำสั่ง SQL
    SqlDataReader reader = command.ExecuteReader(); // เรียกใช้คำสั่งและรับผลลัพธ์

    Console.WriteLine("\n----- รายการพนักงาน -----");
    // อ่านข้อมูลจาก SqlDataReader
    while (reader.Read())
    {
        Console.WriteLine($"ID: {reader["Id"]} | ชื่อ: {reader["Name"]} | แผนก: {reader["Department"]}");
    }
}

// Insert
Console.WriteLine("\n----- เพิ่มพนักงานใหม่ -----");
Console.Write("ชื่อ:");
string Name = Console.ReadLine();

Console.Write("แผนก: ");
string Department = Console.ReadLine();

Console.Write("ชั่วโมงทำงาน: ");
double HoursWorked = double.Parse(Console.ReadLine());

Console.Write("กรอกอัตราค่าจ้าง/ชั่วโมง: ");
double HourlyRate = double.Parse(Console.ReadLine());

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();

    SqlCommand command = new SqlCommand("AddEmployee", connection);
    command.CommandType = CommandType.StoredProcedure;

    command.Parameters.AddWithValue("@Name", Name);
    command.Parameters.AddWithValue("@Department", Department);
    command.Parameters.AddWithValue("@HoursWorked", HoursWorked);
    command.Parameters.AddWithValue("@HourlyRate", HourlyRate);

    //INSERT/UPDATE/DELETE ใช้ ExecuteNonQuery ไม่ใช่ ExecuteReader
    int rowsAffected = command.ExecuteNonQuery();
    Console.WriteLine($"เพิ่มสำเร็จ! ({rowsAffected} row affected)");
}



// Update
Console.WriteLine("\n----- แก้ไขข้อมูลพนักงาน -----");
Console.Write("กรอก ID พนักงานที่ต้องการแก้ไข: ");
int updateId = int.Parse(Console.ReadLine());// รับ ID ของพนักงานที่ต้องการแก้ไข

Console.Write("ชื่อใหม่:");
string newName = Console.ReadLine();

Console.Write("แผนกใหม่: ");
string newDepartment = Console.ReadLine();

Console.Write("ชั่วโมงทำงานใหม่: ");
double newHoursWorked = double.Parse(Console.ReadLine());

Console.Write("กรอกอัตราค่าจ้าง/ชั่วโมง: ");
double newHourlyRate = double.Parse(Console.ReadLine());

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();

    SqlCommand command = new SqlCommand("UpdateEmployee", connection);
    command.CommandType = CommandType.StoredProcedure;

    command.Parameters.AddWithValue("@Id", updateId);
    command.Parameters.AddWithValue("@Name", newName);
    command.Parameters.AddWithValue("@Department", newDepartment);
    command.Parameters.AddWithValue("@HoursWorked", newHoursWorked);
    command.Parameters.AddWithValue("@HourlyRate", newHourlyRate);

    //INSERT/UPDATE/DELETE ใช้ ExecuteNonQuery ไม่ใช่ ExecuteReader
    int rowsAffected = command.ExecuteNonQuery();
    Console.WriteLine($"แก้ไขสำเร็จ! ({rowsAffected} row affected)");
}

//Delete
Console.WriteLine("\n----- ลบพนักงาน -----");
Console.Write("กรอก ID พนักงานที่ต้องการลบ: ");
int deleteId = int.Parse(Console.ReadLine());

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    SqlCommand command = new SqlCommand("DeleteEmployee", connection);
    // บอกว่าเราจะเรียกใช้ Stored Procedure ชื่อ "DeleteEmployee"
    command.CommandType = CommandType.StoredProcedure;
    // เพิ่มพารามิเตอร์ @Id ให้กับคำสั่ง SQL โดยใช้ค่าที่ผู้ใช้กรอก
    command.Parameters.AddWithValue("@Id", deleteId);

    // เรียกใช้คำสั่ง SQL และรับจำนวนแถวที่ถูกลบ
    int rowsAffected = command.ExecuteNonQuery();
    Console.WriteLine($"ลบสำเร็จ! ({rowsAffected} row affected)");
}
