using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.ShvanovVadomOOP
{
    class ShvanovCar
    {
        public string Name;
        public int Speed;

        //Конструктор
        public ShvanovCar()
        {
            Name = "Dodge";
            Speed = 85;
        }
        public ShvanovCar(string Name, int Speed)
        {
            this.Name = Name;
            this.Speed = Speed;
        }
        //методы
        public void CarInfo()
        {
            Console.WriteLine($"{Name}, {Speed}км/ч.");
        }
        public int CarSpeed(int SpeedUp)
        {
            return Speed += SpeedUp;
        }
    }
}
