namespace EmployeeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            //พนักงานทั่วไป
            employees.Add(new Employee(1, "โอ", "IT", 200, 100));
            employees.Add(new Employee(2, "เชียว", "Production", 180, 160));
            employees.Add(new Employee(3, "โค้ก", "Qulity", 200, 190));

            //ผู้จัดการ
            employees.Add(new Manager(4, "จ๊อบ", "IT", 300, 170, 10000));

            //แสดงรายการทั้งหมด
            Console.WriteLine("===== รายการพนักงานทั้งหมด =====");
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }


            //LINQ : หาพนักงานที่ทำงานเกิน 160 ชั่วโมง
            var otEmployees = employees.Where(emp => emp.HoursWorked > 160).ToList();

            Console.WriteLine("\n===== พนักงานที่มี OT =====");
            foreach (Employee emp in otEmployees)
            {
                double otHours = emp.HoursWorked - 160;//คำนวณชั่วโมง OT
                Console.WriteLine($"{emp.Name} - OT เกินมา {otHours} ชั่วโมง");
            }

            //LINQ : เรียนเงินเดือนของพนักงานทั้งหมดจากมากไปน้อย
            var sortedBySalary = employees.OrderByDescending
            (emp => emp.CalculateSalary()).ToList();//เรียงเงินเดือนจากมากไปน้อย

            Console.WriteLine("\n===== เรียง Salary มาก -> น้อย =====");
            foreach (Employee emp in sortedBySalary)
            {
                Console.WriteLine($"{emp.Name} - {emp.CalculateSalary():N2} บาท");
            }

            // input พนักงานใหม่
            Console.WriteLine("\n==== เพิ่มพนักงานใหม่ ====");
            Console.Write("กรอก ID: ");
            int newId = int.Parse(Console.ReadLine());//ตัวแปรรับค่า ID
            //Parse คือการแปลงข้อมูลจาก string เป็น int

            Console.Write("กรอกชื่อ: ");
            string newName = Console.ReadLine();//ตัวแปรรับค่า ชื่อ

            Console.Write("กรอกแผนก: ");
            string newDept = Console.ReadLine();//ตัวแปรรับค่า แผนก

            Console.Write("กรอกค่าแรง/ชม.: ");
            double newRate = double.Parse(Console.ReadLine());//ตัวแปรรับค่า ค่าแรงต่อชั่วโมง

            Console.Write("กรอกชั่วโมงทำงาน: ");
            double newHours = double.Parse(Console.ReadLine());//ตัวแปรรับค่า ชั่วโมงทำงาน


            //สร้างพนักงานใหม่จากข้อมูลที่รับมาและเพิ่มลงใน List
            employees.Add(new Employee(newId, newName, newDept, newRate, newHours));//เพิ่มพนักงานใหม่ลงใน List

            Console.WriteLine("\n===== รายการพนักงานหลังเพิ่ม =====");
            foreach (Employee emp in employees) 
            {
                Console.WriteLine(emp.ToString());
            }

            //LINQ : หาพนักงานตามแผนก
            Console.WriteLine("\n ค้นหาพนักงานตามแผนก: ");
            string searchDept = Console.ReadLine();//ตัวแปรรับค่า แผนกที่ต้องการค้นหา

            var deptEmployees = employees
                                .Where(emp => emp.Department == searchDept)
                                .ToList();//ค้นหาพนักงานตามแผนกที่กรอกมา
            
            if(deptEmployees.Count == 0)//ถ้าไม่พบพนักงานในแผนกที่ค้นหา
            {
                Console.WriteLine("ไม่พบพนักงานในแผนนี้");
            }
            else//ถ้าพบพนักงานในแผนกที่ค้นหา
            {
                Console.WriteLine($"\n===== พนักงานในแผนก {searchDept} =====");
                foreach (Employee emp in deptEmployees)//loop แสดงพนักงานที่อยู่ในแผนกที่ค้นหา
                {
                    Console.WriteLine(emp.ToString());//ประมวลผลแสดงข้อมูลพนักงานที่ค้นหา
                }
            }


        }
    }
}
