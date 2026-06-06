using Microsoft.Data.SqlClient;
using System.Data;
namespace SP_Practice
{
    internal class Program
    {
        static void Main(string[] args) //เรียกใช้ฟังก์ชันต่างๆ ที่เราเขียนไว้ หรือ metods ที่เราเตรียมไว้
        {
            GetMachinesByStatus("Active");
            //AddMachine("Lathe-01", "Active", "Floor D");
        }

        //GET : sp_GetMachinesByStatus
        static void GetMachinesByStatus(string status)
        {
            string connStr =
                "Server=localhost\\SQLEXPRESS01;Database=YokohamaDB;Trusted_Connection=True;Encrypt=False;";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand("sp_GetMachinesByStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;//บอกว่าเราจะใช้ SP ไม่ใช่คำสั่ง SQL ธรรมดา
                    cmd.Parameters.AddWithValue("@Status", status);//เอาค่าที่ส่งเข้ามาใส่ในพารามิเตอร์ของ SP


                    using (var reader = cmd.ExecuteReader())//รัน SP และรับผลลัพธ์มาเป็น DataReader
                    {
                        while (reader.Read())
                            Console.WriteLine($"{reader["MachineName"]} - {reader["Status"]} - {reader["Location"]}");
                    }

                    //ExecuteReader() ใช้สำหรับ SP ที่คืนค่ากลับมาเป็นชุดข้อมูล (เช่น SELECT) ส่วน
                    //ExecuteNonQuery() ใช้สำหรับ SP ที่ไม่คืนค่ากลับมา (เช่น INSERT, UPDATE, DELETE)

                }

            }
        }

        //INSERT : sp_InsertMachine
        static void AddMachine(string name, string status, string location)
        {
            string connStr =
                "Server=localhost\\SQLEXPRESS01;Database=YokohamaDB;Trusted_Connection=True;Encrypt=False;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand("sp_AddMachine", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MachineName", name);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Location", location);

                    //ExecuteNonQuery() จะคืนค่าจำนวนแถวที่ถูกกระทบ (เช่น จำนวนแถวที่ถูกเพิ่ม, แก้ไข, หรือลบ)
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Added {rows} row(s)");
                    //ถ้า SP มีการใช้ OUTPUT parameter หรือ RETURN value เราสามารถดึงค่ากลับมาได้ด้วย cmd.Parameters["@OutputParam"].Value หรือ cmd.ExecuteScalar() ตามแต่กรณี
                }
            }
        }
    }
}
