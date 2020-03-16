using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes
{
    public class Car
    {
        protected string name;
        protected string color;
        protected double engine;
        protected double speed;

        public Car(string name, string color, double engine, double speed) //конструктор
        {
            this.name = name;
            this.color = color;
            this.engine = engine;
            this.speed = speed;
        }
        public virtual void CarInfo()
        {
            Console.WriteLine("Show info of that car....");
            Console.Write($"Марка машины: {name}, Цвет: {color}");
            Console.WriteLine();
        }
    }
}
