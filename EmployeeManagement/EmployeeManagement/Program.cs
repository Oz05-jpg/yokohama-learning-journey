namespace EmployeeManagement
{
    internal class Program
    {
        static async Task Main(string[] args) //เปลี่ยนเป็น async Task เพื่อรองรับการใช้ await ในการทดสอบ Async/Await
        {
            // ===== Employee Management System =====
            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee(1, "โอ", "IT", 200, 180));
            employees.Add(new Employee(2, "เชียว", "Production", 180, 160));
            employees.Add(new Employee(3, "โค้ก", "Quality", 200, 190));
            employees.Add(new Manager(4, "จ๊อบ", "IT", 300, 170, 10000));

            Console.WriteLine("===== รายการพนักงานทั้งหมด =====");
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }

            var otEmployees = employees.Where(emp => emp.HoursWorked > 160).ToList();
            Console.WriteLine("\n===== พนักงานที่มี OT =====");
            foreach (Employee emp in otEmployees)
            {
                double otHours = emp.HoursWorked - 160;
                Console.WriteLine($"{emp.Name} — OT เกินมา {otHours} ชม.");
            }

            var sortedBySalary = employees.OrderByDescending(emp => emp.CalculateSalary()).ToList();
            Console.WriteLine("\n===== เรียง Salary มาก → น้อย =====");
            foreach (Employee emp in sortedBySalary)
            {
                Console.WriteLine($"{emp.Name} — {emp.CalculateSalary():N2} บาท");
            }

            // ===== Exception Handling + get/set =====
            Console.WriteLine("\n===== ทดสอบ get/set + try/catch =====");
            //try catch เพื่อจัดการกับข้อผิดพลาดที่อาจเกิดขึ้นเมื่อพยายามตั้งค่า HourlyRate เป็นค่าลบ
            try
            {
                Employee emp = new Employee(1, "โอ", "IT", 200, 160);
                emp.HourlyRate = -500;
                Console.WriteLine($"ค่าแรง: {emp.HourlyRate}");
            }
            catch (ArgumentException ex) //จับข้อผิดพลาดที่เกิดจากการตั้งค่า HourlyRate เป็นค่าลบ
            {
                Console.WriteLine($"❌ {ex.Message}");
                //แจ้งเตือนผู้ใช้ว่าไม่สามารถตั้งค่า HourlyRate เป็นค่าลบได้
            }

            // Async/Await
            static async Task<string> GetDataAsync()
            {
                await Task.Delay(2000); //จำลองการทำงานที่ใช้เวลานาน เช่น การดึงข้อมูลจากฐานข้อมูลหรือ API
                return "ดึงข้อมูลสำเร็จ!";
            }

            // เรียกใช้ใน Main method
            Console.WriteLine("\n==== ทดสอบ Async/Await ====");
            Console.WriteLine("เริ่มดึงข้อมูล");
            string result = await GetDataAsync();
            Console.WriteLine(result);
            Console.WriteLine("จบการทำงาน");

            //async -> บอกว่า method นี้เป็น asynchronous ซึ่งสามารถใช้ await ได้
            //await -> รอผลลัพธ์ แต่ไม่บล็อค Method อื่นๆ ให้ทำงานต่อไปได้ในระหว่างที่รอผลลัพธ์จาก GetDataAsync() ซึ่งช่วยให้โปรแกรมไม่หยุดชะงักและสามารถทำงานอื่นๆ ได้ในระหว่างนั้น
            //task -> กล่องที่ห่อผลลัพธ์ที่จะได้ในอนาคตจากการทำงานแบบ asynchronous ซึ่งสามารถใช้ await เพื่อรอผลลัพธ์ได้

        }
    }
}