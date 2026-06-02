using System;
using System.Collections.Generic;

namespace OOP_Practice
{
    internal class Program
    {
        //abstraction การซ่อนรายละเอียดของการทำงานของ class ไว้ภายใน class นั้นๆ และให้ผู้ใช้สามารถเข้าถึงได้ผ่าน method ที่เราได้กำหนดไว้ ซึ่งจะช่วยให้เราสามารถควบคุมการเข้าถึงข้อมูลและการทำงานของ class ได้ดีขึ้น
        public abstract class Tire
        {
            public abstract void Inspect();//Inspect เป็น method ที่เรากำหนดไว้ใน class Tire ซึ่งเป็น abstract method ซึ่งหมายความว่า class ที่สืบทอดจาก class Tire จะต้อง implement method นี้ด้วยการเขียน code ของตัวเองเพื่อกำหนดการทำงานของ method นี้ให้เหมาะสมกับ class นั้นๆ
        }

        //inheritance การสืบทอด
        public class TruckTire : Tire
        {
            public override void Inspect()
            {
                Console.WriteLine("Truck: Checking ply rating");
            }
        }

        //inheritance การสืบทอด
        public class CarTire : Tire
        {
            public override void Inspect()
            {
                Console.WriteLine("Car: Checking tread depth");
            }
        }

        // main method
        static void Main(string[] args)
        {
            //polymorphism คือ การที่เราสามารถใช้ method เดียวกันกับ object ที่ต่างชนิดกันได้ โดยที่แต่ละ object จะมีการทำงานที่แตกต่างกันไปตาม class ของมัน
            List<Tire> tires = new List<Tire>
            {
                new TruckTire(),
                new CarTire()
            };

            //encapsulation คือ การที่เราสามารถซ่อนข้อมูลหรือการทำงานของ class ไว้ภายใน class นั้นๆ และให้ผู้ใช้สามารถเข้าถึงได้ผ่าน method ที่เราได้กำหนดไว้ ซึ่งจะช่วยให้เราสามารถควบคุมการเข้าถึงข้อมูลและการทำงานของ class ได้ดีขึ้น
            foreach (Tire tire in tires)
            {
                tire.Inspect();
            }

            Console.ReadLine();
        }


    }
}
