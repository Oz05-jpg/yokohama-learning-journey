using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics
{
    internal class Contractor : IPayable //คลาสผู้รับเหมา
    {
        public string Name;
        public double ProjectFee;

        public Contractor(string name, double projectFee)
        {
            Name = name;//กำหนดค่าชื่อผู้รับเหมา
            ProjectFee = projectFee;//กำหนดค่าค่าจ้างโครงการของผู้รับเหมา
        }
        //Method - ฟังก์ชันการทำงานของผู้รับเหมา
        public double CalculateTotalPay()//ฟังก์ชันคำนวณเงินค่าจ้างโครงการของผู้รับเหมา
        {
            return ProjectFee;//คืนค่าเงินค่าจ้างโครงการของผู้รับเหมา
        }

    }
}
