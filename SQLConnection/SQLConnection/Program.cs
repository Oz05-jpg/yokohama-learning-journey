using SQLConnection;

var repo = new EmployeeRepo();
var employees = repo.GetAll();

//กรอกเฉพาะ IT
var itEmployees = employees.Where(e => e.Department == "IT").ToList();
//เรียงตามเงินเดือนจากมากไปน้อย
var sorted = employees.OrderByDescending(e => e.Salary).ToList();
//เงินเดือนเฉลี่ย
var avgSalary = employees.Average(e => e.Salary);
//หาคนเดือนสูงสุด
var maxSalary = employees.MaxBy(e => e.Salary);//MaxBy คือ การหาคนที่มีเงินเดือนสูงสุด โดยจะคืนค่าของ Employee ที่มีเงินเดือนสูงสุดมาให้เรา

//แสดงผลลัพธ์
foreach (var emp in itEmployees)
{
    Console.WriteLine($"{emp.Name} - {emp.Department} - {emp.Salary:N0}");
}
Console.WriteLine($"เฉลี่ย: {avgSalary:N0}");
Console.WriteLine($"เงินเดือนสูงสุด: {maxSalary.Name} - ({maxSalary.Salary:N0})");
