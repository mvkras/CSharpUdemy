using System;
using System.Net;
using System.Runtime.Serialization.Formatters;

namespace B_ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
        //    HomeWork1(); //Условные выражения
            Loops(); //Циклы for, foreach
            AdvancedLoops(); //Вложенные циклы
        //  WhileDoWhile(); //Циклы while Do While
            BreakContinue(); //Управление циклом break, continue
        //  SwutchCase(); //Конструкция Switch Case
       //   Debugging(); //Отладка основы
            HomeWork2(); //ДЗ Числа Фибоначчи
        }
 
//*************************************************************************************************************************************
        static void HomeWork1() //ДЗ_1 Найти максимальное из 2х чисел
        {
            Console.WriteLine("Введите 2 числа:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            string maxValue = a > b ? $"Максимальное значение: {a}" : $"Максимальное значение: {b}";            
            Console.WriteLine(maxValue);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
         static void Loops() //Циклы For, ForEach
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("В обратном порядке ");
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Вывод четных чисел в обратном порядке:");
            for (int i = numbers.Length-1; i >=0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.WriteLine();
            //Метод foreach если не нужен доступ к индексу, а только к его значениям
            Console.WriteLine("Метод foreach");
            foreach (int value in numbers)
            {
                Console.Write(value+" ");
            }
            Console.WriteLine();
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void AdvancedLoops() //Вложенные циклы
        {
            int[] number = { -1, 2, 3, -4, 5, 6, 1, 4, -2 };
            for (int i = 0; i < number.Length-1; i++) //-1 так как 2й цикл будет на месте крайнего индекса и он и так будет сравнивать со свеми цифрами
            {
                for (int j = i+1; j < number.Length; j++)
                {
                    int toI = number[i];
                    int toJ = number[j];

                    if(toI + toJ == 0)
                    {
                        Console.WriteLine($"Пара чисел: ({toI}; {toJ}) с индексами ({i}; {j})");
                    }
                }
            }
            //Триплеты 3 цикла
            for (int i = 0; i < number.Length-2; i++) //- 2 так как 2 цикла будут перебирать все эти цифры
            {
                for (int j = i + 1; j < number.Length-1; j++) // 1 цикл будет перебирать остальные цифры
                {
                    for (int k = j + 1; k < number.Length; k++)
                    {
                        int toI = number[i];
                        int toJ = number[j];
                        int toK = number[k];
                        if (toI + toJ + toK == 0)
                        {
                            Console.WriteLine($"Тройка чисел: ({toI}; {toJ}; {toK}) с индексами ({i}; {j}; {k})");
                        }
                    }
                }
            }

        }
//--------------------------------------------------------------------------------------------------------------------------------------       
        static void WhileDoWhile() //Циклы while Do While
        {
            int age = 0;
            while (age < 18)
            {
                Console.WriteLine("Твой возраст?");
                age = int.Parse(Console.ReadLine());
                if(age < 18)
                {
                    Console.WriteLine("Слишком молодой, попробуй еще");
                }
            }
            Console.WriteLine($"Возраст {age}");

            do  //Хотя бы раз сработает
            {
                Console.WriteLine("Твой возраст?");
                age = int.Parse(Console.ReadLine());
                if (age < 18 && age !=0)
                {
                    Console.WriteLine("Должно быть больше 18");
                }
            }
            while (age < 18);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void BreakContinue() //Управление циклом break, continue
        {
            int[] numbers = { 2, 1, 5, 6, 3, 4 }; //Будет вложенный массив. На каждой внутренней итерации, выводит то кол-ва букв, которое в массиве
            char[] letter = { 'a', 'b', 'c', 'd', 'e', 'f' }; //вывод будет таким: a, ab, abc, abcd, abcde....
            for(int i = 0; i<numbers.Length; i++)
            {
                Console.WriteLine($"Number: {numbers[i]}");
                
                for (int j = 0; j < letter.Length; j++) //Внутренний цикл
                {
                    if (numbers[i] == j) //Выходим из цикла, когда i становится равно j
                        break;
                    Console.Write($"{letter[j]}");
                }
                Console.WriteLine(); //Отделяем выводы внутренних циклов
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void SwutchCase() //Конструкция Switch Case
        {
            Console.WriteLine("Сколько лет вы в браке?");
            int weddingAge = int.Parse(Console.ReadLine());
            string name = string.Empty; //Проинициализировали строку
            switch (weddingAge)
            {
                case 5:
                    name = "Деревянная свадьба!";
                    break;
                case 10:
                    name = "Янтарная свадьба!";
                    break;
                case 15:
                    name = "Стеклянная свадьба!";
                    break;
                default:
                    name = "Юбилей еще в переди!";
                    break;
            }
             Console.WriteLine($"Вы в браке уже: {weddingAge} лет - {name}");

            Console.WriteLine("Введите число месяца:");
            int numberOfSeason = int.Parse(Console.ReadLine());
            string season = string.Empty; //Проинициализировали строку

            switch (numberOfSeason)
            {
                case 1:
                case 2:
                case 12:
                    season = "Зима";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Весна";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Лето";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Осень";
                    break;
            }
            Console.WriteLine(season);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void Debugging() //Отладка основы
        {
            Console.WriteLine("Укажите длины сторон треугольника: ");
            double a = GetDouble(); //Вместо Parse и ReadLine - сделали отдельный метод и вставили в строку
            double b = GetDouble();
            double c = GetDouble();
            double p = (a + b + c) / 2;  //Предположим, что забыли скобки
            double S = p * (p - a) * (p - b) * (p - c);
            S = Math.Sqrt(S); //Квадратный корень числа
            S = Math.Round(S, 4); //Форматированный вывод, 4 знака, после запятой
            Console.WriteLine($"Площадь по формуле Герона равна: {S}");


            //Метод, который возвращает double по формуле Герона
            static double GetDouble() //Метод возвращает double с формулы Герона
            {
                return double.Parse(Console.ReadLine());
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWork2() //ДЗ Числа Фибоначчи
        {
            /*Числа фибоначчи описываются следующей последовательностью: 1, 1, 2, 3, 5, 8, 13, 21...
             *Первые два числа - единицы. Все последующие числа вычисляются как сумма двух предыдущих.
             *Задание: запросить у пользователя кол-во чисел Фибоначчи, которое он хотел бы сгенерировать (вычислить), 
             *собственно, произвести генерацию (вычисление). 
             *В процессе генерации записывать числа в массив. 
             *После генерации вывести вычисленные числа.
             */

        }


    }
}
