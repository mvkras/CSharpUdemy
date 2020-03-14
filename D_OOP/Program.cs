using D_OOP.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace D_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Character warrior = new Character("Human"); //У каждого класса свое предназначение, Класс кошка не может создавать ракеты...
            string charactierInfo = warrior.GetRace();
            warrior.Hit(35);
            Console.WriteLine($"Ваша раса: {charactierInfo}, Здоровье персонажа: {warrior.GetHealth()}, Броня: {warrior.armor}");
                        
            Character archer = new Character("Wood Elf", 60);
           int armorInfo = archer.armor;         
            Console.WriteLine($"Ваша раса: {archer.GetRace()}, Здоровье персонажа: {archer.GetHealth()}, Броня: {armorInfo}");
                
           
            Calculator calc = new Calculator();           
            double result = calc.SqrtLength(ab: 8, bc: 12, alpha: 45); //Именованные аргументы Ctrl + .(точка). Выбираем add argument ->
            result = Math.Round(value: result, digits: 2);
            Console.WriteLine("Площадь равна: "+result);
            
           double avg = calc.Average(numbers: new int[] { 1, 2, 3, 4 }); //инициализация массива Average (именованные аргументы)
            Console.WriteLine("Среднее значение: "+avg);
            //С помощью params можно передавать значения массива через запятую
            double avg2 = calc.Average2( 1, 2, 3, 4 ); //инициализация массива Average. 
            Console.WriteLine("Инициализация среднего значения: "+avg2);

            
          //  Calculator.TryParsed(); //С использованием статического метода, без использования экземпляра
            

            Calculator divider = new Calculator();
            if(divider.TryDevide( 5, 2, out double result2))
            {
                Console.WriteLine($"Результат деления равен: {result2}");
            }
            else
            {
                Console.WriteLine("Fail не получилось поделить");
            }

            //Создадим экземпляр структуры
            PointVal a; //это экземпляр структуры, тоже самое, что и PointVal a = new PointWal();
            a.x = 5;
            a.y = 8;

            //Создадим еще одну структуру b
            PointVal b = a;
            b.x = 4;
            b.y = 6;

            a.LogValues();
            b.LogValues();


            Console.WriteLine("Данные после struct (структуры)");
            //Создадим Экземпляр для класса

            PointRef c = new PointRef();  
            c.x = 5;
            c.y = 8;

            //Создадим еще одну структуру b
            PointRef d = c;
            d.x = 4;
            d.y = 6;

            c.LogValues();
            d.LogValues();

            List<int> list = new List<int>();
            AddNumbers(list);
            foreach(int value in list)
            {
                Console.WriteLine("Вывод List "+value);
            }
            
            Swap(8, 6);
            SwapAuto(); //Значения вводит пользователь
            SwapFromFull(); //С защитой от дурака
            
        }
//**************************************************--------МЕТОДЫ--------*********************************************************
        static void AddNumbers(List<int> numbers) //лист это класс (ссылочный тип)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        static void Swap(int a, int b) //функция принимает 2 числа и меняет их местами
        {
            Console.WriteLine($"Original a = {a}, b = {b}");

            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"Swap values a = {a}, b = {b}");
        }

        static void SwapAuto()
        {
            Console.WriteLine("Введите 2 значения");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Значение 1 = {a}, Значение 2 = {b}");
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"Поменялись местами: Значение 1 = {a}, Значение 2 = {b}");

        }

        //Метод защиты от дурака 
        static void SwapFromFull()
        {
            Console.WriteLine("Введите 2 значения");
            string str = Console.ReadLine();
            bool itParsedA = int.TryParse(str, out int a);
            
            if (itParsedA)
            {
                Console.WriteLine($"Защита 1 = {a}");
            }
            else
            {
                Console.WriteLine("Пользователь ввел не цифры для значения 1");
            }

            string str2 = Console.ReadLine();
            bool itParsedB = int.TryParse(str2, out int b);
            if (itParsedB)
            {
                Console.WriteLine($"Защита 2 = {b}");
            }
            else
            {
                Console.WriteLine("Пользователь не ввел цифры для значения 2");
            }
                
            
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"Защита поменялись местами: Значение 1 = {a}, Значение 2 = {b}");
            
        }

    }
}
