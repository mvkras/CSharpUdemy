using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes
{
  public class Car1 : Car
    {
        public Car1(string name, string color, double engine, double speed) : base(name, color, engine, speed)
        {

        }
        public override void CarInfo()
        {
            base.CarInfo();
            Console.WriteLine($"Объем двигателя: {engine}, Скорость: {speed}");
            Console.WriteLine();
        }
    }
}
