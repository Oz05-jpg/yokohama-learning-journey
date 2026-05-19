using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics
{
    class Employee : IPayable //คลาสพนักงานที่สืบทอดมาจาก interface IPayable
    {
        //Properties - ข้อมูลของพนักงาน
        public string Name;
        public int HoursWorked;
        public double HourlyRate;

        //Constructor - ตัวสร้าง object ของพนักงาน
        public Employee(string name, int hoursWorked, double hourlyRate)
        {
            Name = name;//กำหนดค่าชื่อพนักงาน
            HoursWorked = hoursWorked;//กำหนดค่าชั่วโมงการทำงานของพนักงาน
            HourlyRate = hourlyRate;//กำหนดค่าอัตราค่าจ้างต่อชั่วโมงของพนักงาน
        }

        //Method - ฟังก์ชันการทำงานของพนักงาน
        public double CalculateTotalPay()//ฟังก์ชันคำนวณเงินเดือนของพนักงาน
        {
            int normalHours = 40;//กำหนดชั่วโมงการทำงานปกติ
            double actualHours = Math.Min(HoursWorked,normalHours);//เก็บค่าชั่วโมงการทำงานจริงของพนักงาน
            double baseSalary = actualHours * HourlyRate;//คำนวณเงินเดือนพื้นฐานโดยการคูณชั่วโมงการทำงานจริงกับอัตราค่าจ้างต่อชั่วโมง
            double otPay = 0;//กำหนดค่าเงินค่าล่วงเวลาเริ่มต้นเป็น 0


            if (HoursWorked > normalHours)
            {
                int otHours = HoursWorked - normalHours;//คำนวณชั่วโมงการทำงานล่วงเวลาของพนักงาน
                otPay = otHours * HourlyRate * 1.5;//คำนวณเงินค่าล่วงเวลาโดยการคูณชั่วโมงการทำงานล่วงเวลากับอัตราค่าจ้างต่อชั่วโมงและคูณด้วย 1.5
            }
            
            return baseSalary + otPay;//คืนค่าเงินเดือนรวมของพนักงานโดยการบวกเงินเดือนพื้นฐานกับเงินค่าล่วงเวลา
        }
    }
}
