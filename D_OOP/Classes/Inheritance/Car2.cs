using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes
{
    class Car2 : Car
    {
               
        public Car2(string name, string color, double engine, double speed) : base(name, color, engine, speed)
        {

        }
        public override void CarInfo()
        {
            base.CarInfo();
            Console.WriteLine($"Объем двигателя: {engine}");
        }

    }
}
