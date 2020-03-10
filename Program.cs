using System;
using System.Collections.Generic;

namespace CSharpUdemy
{
    class Program
    {
        static void Main(string[] args)
        {
            Types(); //Вызываем нашу функцию
            Literals(); //Вызываем литералы
            Overflow(); //Вызываем перегрузку функций (Overflow)
        }
        
       
        
        //Создаем отдельную функцию, для наших прошлых записей
        static void Types()
        {
            int x = 24;
            float y = 12.12f;
            Dictionary<int, string> dict = new Dictionary<int, string>(); //Работа со словарями
                                                                          //var dict = new Dictionary<int, strung>();   тоже самое можно записать так 
            decimal money = 3.0m; //для денежных операций и постфикс m (money)

            Console.WriteLine("Количество денег на счете: " + money + "$");
            Console.WriteLine(); //Перенос строки для разделения
        }

        static void Literals()
        {
            //Бинарная система счисления
            int x = 0b001;
            int y = 0b1100;
            int z = 0b1101;         
            Console.WriteLine("Двоичная система счисления (бинарная) x = "+ x + " у = " + y + " z = "+ z);
            //16ти ричная система счисления
            int a = 0x1F;
            int b = 0xA;
            int c = 0xFF0D;
            Console.WriteLine("16-ти ричная система счисления: a = "+ a +" b = " + b + " c = " + c);
            Console.WriteLine("4.5e2 = " + 4.5e2); //Это будет: 4.5 * 10 во 2й степени=4.5 * 100 = 450;
        }

        static void Overflow() //перегрузка функций
        {
            uint x = uint.MaxValue; //MaxValue - свойство (максимальное значение числа) Возвращает самое большое число, которое может быть представленно данным типом
            Console.WriteLine("Самое большое число x = " + x); //выводим наше значение переменной x
            x = x + 1; //в памяти будет прибавлено 1 и присвоится это значение x
            Console.WriteLine("Измененное значение " + x); //будет 0, так как это значение больше данного типа данных
        }
    }
}
