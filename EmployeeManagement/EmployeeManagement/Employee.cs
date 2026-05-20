using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    internal class Employee : IPayable
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        
        //กำหนดให้ค่าแรงต้องมากกว่า 0 โดยใช้ private field และ public property เพื่อควบคุมการเข้าถึงและการตั้งค่า
        private double _hourlyRate;
        public double HourlyRate
        {
            get { return _hourlyRate; } // การเข้าถึงค่าแรงผ่าน property
            set// การตั้งค่า HourlyRate โดยมีการตรวจสอบว่าค่าแรงต้องมากกว่า 0
            {
                if (value <= 0)
                    throw new ArgumentException("ค่าแรงต้องมากกว่า 0");
                _hourlyRate = value;
            }
        }

        public double  HoursWorked { get; set; }

        // Constructor
        public Employee(int id, string name, string department,
                        double hourlyRate, double hoursWorked)
        {
            Id = id;
            Name = name;
            Department = department;
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Method to calculate salary
        public virtual double CalculateSalary() //คือการประกาศเมธอดที่สามารถถูกแทนที่ได้ในคลาสลูก (derived class) โดยใช้คำว่า "virtual" เพื่อให้สามารถมีการปรับแต่งพฤติกรรมของเมธอดนี้ในคลาสลูกได้
        {
            double normalHours = Math.Min(HoursWorked, 40); // ชั่วโมงปกติ
            double otHours = Math.Max(HoursWorked - 40, 0); // ชั่วโมงล่วงเวลา

            return (normalHours * HourlyRate) + (otHours * HourlyRate * 1.5); // คำนวณเงินเดือนโดยรวมชั่วโมงปกติและชั่วโมงล่วงเวลา

        }

        // Override ToString method for easy display

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name} | Department: {Department}, Salary: {CalculateSalary():N2} บาท";
        }
    }
}
