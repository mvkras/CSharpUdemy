using System;

namespace D_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Character warrior = new Character(); //У каждого класса свое предназначение, Класс кошка не может создавать ракеты...
            warrior.Hit(90);
            Console.WriteLine($"Здоровье персонажа: {warrior.GetHealth()}");
            Calculator calc = new Calculator();           
            double result = calc.SqrtLength(8, 12, 45);
            result = Math.Round(result, 2);
            Console.WriteLine("Площадь равна: "+result);
            
           double avg = calc.Average(new int[] { 1, 2, 3, 4 }); //инициализация массива Average
            Console.WriteLine("Среднее значение: "+avg);
            //С помощью params можно передавать значения массива через запятую
            double avg2 = calc.Average2( 1, 2, 3, 4 ); //инициализация массива Average. 

        }
    }
}
