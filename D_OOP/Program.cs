using D_OOP.Classes;
using D_OOP.Classes.Polymorphism;
using D_OOP.ShvanovVadomOOP;
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
      //      SwapAuto(); //Значения вводит пользователь
       //     SwapFromFull(); //С защитой от дурака

            //Bankomat наследование inheritence
            ModelA terminalA = new ModelA(252);
            terminalA.Connect();
            ModelB terminalB = new ModelB(758);
            terminalB.Connect();

            //Car наследование
            Car1 bmw = new Car1("Bmw", "Black", 2.6, 289.7);
            bmw.CarInfo();
            Car2 dodge = new Car2("Dodge", "Yellow", 6.0, 382.3);
            dodge.CarInfo();

            Console.WriteLine();

            //Полиформизм (1 метод для каждого класса осуществляет свою операцию папка Polymorphism)
            Rectangle rectangle = new Rectangle(width: 17.5, height: 22.3);
            rectangle.Area();
            rectangle.Perimeter();
            rectangle.Draw();

            Console.WriteLine();

            Triangle triangle = new Triangle(a: 5.2, b: 6.3, c: 7.5);
            triangle.Area();
            triangle.Perimeter();
            triangle.Draw();
            Console.WriteLine();
            Console.WriteLine();
            /*Так как мы переопределили все эти методы, вызывающий код может унифицированно работать со всеми этими типами/классами
             * используя базовый класс/абстрактный, записать экземпляр абстрактного класса можно в виде массива и передать туда наши 
             * классы - наследники в этот массив*/
            Shapes[] shapes = new Shapes[2];
            shapes[0] = new Triangle(6.3, 8.2, 9.7);
            shapes[1] = new Rectangle(22.4, 18.7);
            //Пройдемся foreach, используя базовый(абстрактный класс)
            foreach (var shape in shapes)
            {
                shape.Area();
                shape.Draw();
                shape.Perimeter();               
            }
            Console.WriteLine();
            Console.WriteLine();
            Do(triangle);

            MyStack<int> ms = new MyStack<int>(); //у нас 2 перегрузки массива (по умолчанию 4 элемента), либо выбрать размер какой необходим
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            Console.WriteLine(ms.Peek());//Выведем последний добавленный элемент
            ms.Pop(); //удалим последний элемент
            Console.WriteLine(ms.Peek());
            ms.Push(3);
            ms.Push(4);
            ms.Push(5); //чтобы произошло расширение стека, чтобы убедиться, что ничего не падает
            Console.WriteLine(ms.Peek());

            //Вадим Шванов
            ShvanovCar shamovCar = new ShvanovCar();
            shamovCar.CarInfo();
            ShvanovCar shCar = new ShvanovCar("F1", 260);
            shCar.CarInfo();
           
            RandomNumbers();




        }
//**************************************************--------МЕТОДЫ--------*********************************************************
        static void RandomNumbers()
        {
            Random rand = new Random();
           int a = rand.Next(0, 15);
            Console.WriteLine(a);
        }
        static void Do(Shapes shapess)
        {
            shapess.Draw();
            shapess.Perimeter();
            shapess.Area();
        }
           
        
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
