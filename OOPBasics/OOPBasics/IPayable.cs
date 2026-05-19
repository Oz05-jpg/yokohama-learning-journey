using System;
using System.Collections.Generic;
using System.Text;

namespace OOPBasics
{
    internal interface IPayable//interface ที่กำหนดฟังก์ชันการคำนวณเงินเดือนหรือค่าจ้างที่ต้องจ่ายให้กับพนักงานและผู้รับเหมา
    {
        double CalculateTotalPay();
    }
}
