using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    internal class Manager : Employee
    {
        public double Bonus { get; set; }

        // Constructor
        public Manager(int id, string name, string department,
                       double horlyRate, double hoursWorked, double bonus)
            : base(id, name, department, horlyRate, hoursWorked)
            
        {
            Bonus = bonus;// การกำหนดค่าโบนัสในคอนสตรัคเตอร์ของคลาส Manager
        }

        //คือการแทนที่เมธอด CalculateSalary() ในคลาส Manager เพื่อให้สามารถคำนวณเงินเดือนโดยรวมเงินเดือนปกติและโบนัสได้
        public override double CalculateSalary()
        {
            return base.CalculateSalary() + Bonus; // การคำนวณเงินเดือนโดยรวมเงินเดือนปกติและโบนัส
        }

        //คือการแทนที่เมธอด ToString() ในคลาส Manager เพื่อให้สามารถแสดงข้อมูลของผู้จัดการได้อย่างเหมาะสม โดยรวมข้อมูลของ ID, Name, Department และ Salary ที่คำนวณไดฺ้
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name} | Department: {Department}, Salary: {CalculateSalary():N2} บาท";
        }

    }
}
