//เก็บขัอมูลพนักงาน
List<string> employeename = new List<string>();
List<int> hoursWorked = new List<int>();
List<double> hourlyRate = new List<double>();

//ตัวแปรสำหรับควบคุมการเพิ่มพนักงาน
string choice = "y";

//วนลูปเพื่อรับข้อมูลพนักงานจนกว่าผู้ใช้จะเลือกไม่เพิ่มพนักงานอีก
while (choice == "y")
{
    //รับข้อมูลพนักงาน
    Console.WriteLine($"ชื่อพนักงาน:");
    string name = Console.ReadLine();

    Console.WriteLine($"ชั่วโมงที่ทำงาน:");
    int hours = int.Parse(Console.ReadLine());

    Console.WriteLine($"ราคาต่อชั่วโมง:");
    double rate = double.Parse(Console.ReadLine());//parse คือการแปลงข้อมูลจาก string เป็นชนิดข้อมูลที่ต้องการ

    //เพิ่มข้อมูลพนักงานลงใน list
    employeename.Add(name);
    hoursWorked.Add(hours);
    hourlyRate.Add(rate);

    //ถามผู้ใช้ว่าต้องการเพิ่มพนักงานคนต่อไปไหม
    Console.WriteLine("เพิ่มพนักงานคนต่อไปไหม? (y/n)");
    choice = Console.ReadLine();
}


//คำนวณค่า OT
Console.WriteLine("\n ======= สรุปรายการ =======");

// วนลูปเพื่อคำนวณค่า OT สำหรับแต่ละพนักงาน
for (int i = 0; i < employeename.Count; i++)
{
    int normalHours = 40;
    double actualHours = Math.Min(hoursWorked[i], normalHours);// ชั่วโมงที่ทำงานจริงที่ไม่เกิน 40 ชั่วโมง
    double basepay = actualHours * hourlyRate[i];// เงินเดือนปกติสำหรับ 40 ชั่วโมงแรก
    double otPay = 0;

    // คำนวณค่า OT ถ้าชั่วโมงที่ทำงานเกิน 40 ชั่วโมง
    if (hoursWorked[i] > normalHours)
    {
        int otHours = hoursWorked[i] - normalHours;
        otPay = otHours * hourlyRate[i] * 1.5; // OT คิดเป็น 1.5 เท่าของค่าจ้างปกติ
    }

    // แสดงผลลัพธ์
    double totalPay = basepay + otPay;

    Console.WriteLine($"พนักงาน: {employeename[i]}");
    Console.WriteLine($"ชั่วโมงที่ทำงาน: {hoursWorked[i]} ชม.");
    Console.WriteLine($"เงินเดือนปกติ: {basepay:N2}บาท");
    Console.WriteLine($"เงิน OT: {otPay:N2}บาท");
    Console.WriteLine($"เงินเดือนรวม: {totalPay:N2}บาท");
    Console.WriteLine("-----------------------------");

}
