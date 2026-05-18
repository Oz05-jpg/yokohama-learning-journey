using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics
{
    internal class Manager : Employee
    {
        public double Bonus;

        //Constructor - ตัวสร้าง object ของผู้จัดการ
        public Manager(string name, int hoursWorked,double hourlyRate, double bonus) 
            : base(name, hoursWorked, hourlyRate)//เรียกใช้ constructor ของคลาส Employee เพื่อกำหนดค่าชื่อ ชั่วโมงการทำงาน และอัตราค่าจ้างต่อชั่วโมงของผู้จัดการ
        {
            Bonus = bonus;//กำหนดค่าโบนัสของผู้จัดการ
        }

        //Method - ฟังก์ชันการทำงานของผู้จัดการ
        public double CalculateTotalPayWithBonus()
        {
            return CalculateTotalPay() + Bonus;//คืนค่าเงินเดือนรวมของผู้จัดการโดยการบวกเงินเดือนรวมที่คำนวณได้จากฟังก์ชัน CalculateTotalPay() กับโบนัส
        }
    }
}
