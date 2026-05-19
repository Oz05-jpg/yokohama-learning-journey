namespace OOPBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            //สร้างพนักงานตัวอย่างและเพิ่มลงในรายการ
            employees.Add(new Employee("โอ",45,600));
            employees.Add(new Employee("เชียว",30,600));
            employees.Add(new Employee("โค้ก", 50,800));
            employees.Add(new Employee("จ๊อบ", 38, 600));

            //LINQ query หาพนักงานทำ OT
            var otEmployees = employees.Where(emp => emp.HoursWorked > 40).ToList();

            Console.WriteLine("==== พนักงานที่มี OT ====");
            foreach (Employee emp in otEmployees)
            {
                Console.WriteLine($"ชื่อ: {emp.Name} \n ชั่วโมงทำงานทั้งหมด {emp.HoursWorked} ชม. - OT เกินมา : {emp.GetOTHours()}ชม");
            }

            //LINQ หาเงินเดือนเฉลี่ย
            double avgPay = employees.Average(emp => emp.CalculateTotalPay());
            Console.WriteLine($"\n==== เงินเดือนเฉลี่ยของพนักงานทั้งหมด: {avgPay:N2} บาท ====");
            
            // เรียงชื่อพนักงาน
            var sortedEmployees = employees.OrderBy(emp => emp.Name).ToList();
            Console.WriteLine("\n==== เรียงตามชื่อ ====");
            foreach (Employee emp in sortedEmployees)
            {
                Console.WriteLine(emp.Name);
            }


            Console.WriteLine("==== สรุปเงินเดือน ====");

            foreach (Employee emp in employees)//วนลูปแสดงข้อมูลพนักงานแต่ละคน
            {
                Console.WriteLine($"ชื่อ:{emp.Name}");
                Console.WriteLine($"เงินเดือนรวม: {emp.CalculateTotalPay():N2} บาท");
                Console.WriteLine("-------------------------");
            }

            Manager mgr1 = new Manager("จ๊อบ", 50, 1000, 5000);
            Console.WriteLine($"ชื่อผู้จัดการ: {mgr1.Name}");
            Console.WriteLine($"เงินเดือน + โบนัส: {mgr1.CalculateTotalPayWithBonus():N2} บาท");


            // สร้างรายการจ่ายเงินเดือนสำหรับพนักงานและผู้รับเหมา
            List<IPayable> payroll = new List<IPayable>();
            payroll.Add(new Employee("โอ", 45, 600));//เพิ่มพนักงานลงในรายการจ่ายเงินเดือน
            payroll.Add(new Contractor("บริษัท ABC", 50000));//เพิ่มผู้รับเหมาเข้ารายการจ่ายเงินเดือน

            Console.WriteLine("\n==== รายการจ่ายเงินเดือน ====");
            // วนลูปแสดงข้อมูลการจ่ายเงินเดือนของพนักงานและผู้รับเหมา
            foreach (IPayable p in payroll)
            {
                Console.WriteLine($"จ่าย: {p.CalculateTotalPay():N2} บาท");
            }

        }
    }
}
