namespace OOPBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            //สร้างพนักงานตัวอย่างและเพิ่มลงในรายการ
            employees.Add(new Employee("โอ",45,600));
            employees.Add(new Employee("เชียว",40,600));
            employees.Add(new Employee("โค้ก", 60,800));

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
        }
    }
}
