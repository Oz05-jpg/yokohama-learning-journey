var repo = new OTRepo();

//รับข้อมูลจากผู้ใช้
List<string> employeename = new List<string>();
List<int> hoursWorked = new List<int>();
List<double> hourlyRate = new List<double>();

string choice = "y";
//วนลูปรับข้อมูลพนักงานจนกว่าจะเลือกไม่เพิ่มอีก
while (choice.ToLower() == "y")
{
    Console.Write($"ชื่อพนักงาน: ");
    string name = Console.ReadLine();
    Console.Write($"ชั่วโมงที่ทำงาน:");
    int hours = int.Parse(Console.ReadLine());
    Console.Write($"ราคาต่อชั่วโมง:");
    double rate = double.Parse(Console.ReadLine());

    employeename.Add(name);
    hoursWorked.Add(hours);
    hourlyRate.Add(rate);

    Console.Write("เพิ่มพนักงานคนต่อไปไหม? (y/n)");
    choice = Console.ReadLine();
}
//คำนวณเงินเดือนและแสดงผลลัพธ์
Console.WriteLine("\n ====== สรุปรายการ ======");
for (int i = 0; i < employeename.Count; i++)
{
    int normalHours = 40;
    double actualHours = Math.Min(hoursWorked[i], normalHours);
    double basePay = actualHours * hourlyRate[i];
    double otPay = 0;
    //ถ้าทำงานเกิน 40 ชั่วโมง ให้คำนวณ OT
    if (hoursWorked[i] > normalHours)
    {
        int otHours = hoursWorked[i] - normalHours;
        otPay = otHours * hourlyRate[i] * 1.5;
    }
    //คำนวณเงินเดือนรวม
    double totalPay = basePay + otPay;
    Console.WriteLine($"พนักงาน: {employeename[i]}");
    Console.WriteLine($"ชั่วโมงที่ทำงาน: {hoursWorked[i]} ชม.");
    Console.WriteLine($"เงินเดือนปกติ: {basePay:N2} บาท");
    Console.WriteLine($"เงิน OT: {otPay:N2} บาท");
    Console.WriteLine($"เงินเดือนรวม: {totalPay:N2} บาท");
    Console.WriteLine("-----------------------------");

    //บันทึกข้อมูลลง DB
    try
    {
        repo.Save(
            employeename[i],
            hoursWorked[i],
            hourlyRate[i],
            basePay,
            otPay,
            totalPay
        );
        Console.WriteLine("บันทึกลง DB สำเร็จ");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

//แสดงข้อมูลจาก DB
Console.WriteLine("\n ====== ประวัติ OT ทั้งหมด ======");
var history = repo.GetAll();

//วนลูปแสดงข้อมูลแต่ละเรคอร์ดในประวัติ
foreach ( var record in history)
{
    Console.WriteLine(
        $"{record.RecordedAt:dd/MM/yyyy HH:mm} | " +
        $"{record.EmployeeName} | รวม: {record.TotalPay:N2} บาท"
    );

}