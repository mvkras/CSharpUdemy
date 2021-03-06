﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpUdemy
{
    class Program
    {
        static void Main(string[] args)
        {
            Types(); //Вызываем нашу функцию
            Literals(); //Вызываем литералы
        //  Overflow(); //Вызываем переполнение функций (Overflow), не путать с перегрузкой! Overloaded
            Arithmetic_Operations(); //Арифметические операции
            StaticMethods(); //Статический (относятся к типу int.Parse()) и не статические методы x.Concat()
            ApiBase(); //Вызываем метод базового API
            EmptyString(); //Тема пустые строки
        // StringChanges(); //Изменение строк
            StrBuilder(); //Используется для считывания строк StringBUilder работает быстрее всех
            FormatString(); //Формат строк
            SpecialFormat(); //Специализированный формат строк
            EqualString(); //Сравнивание строк
         // ReadingFromConsole(); //Работа с консолью, чтение с консоли
            ParsingTypes(); //Преобразование типов, парсинг
            MathMethods(); //Класс Math, его функции (округление, взятие квадратного корня)
            MassivesBegin(); //Введение в массивы
            DateAndTime(); //Знакомство с DateTime
         // HomeWork1(); //Домашнее задание 1
         // HomeWork2(); //Домашнее задание 2 Формула Герона                           
            HomeWork3(); //Домашнее задание 3 Профиль пользователя Индекс массы тела
         
        }
        
       
 //********************************************************************************************************************************************       
        //Создаем отдельную функцию, для наших прошлых записей
        static void Types() //Типы данных
        {
            int x = 24;
            float y = 12.12f;
            Dictionary<int, string> dict = new Dictionary<int, string>(); //Работа со словарями
                                                                          //var dict = new Dictionary<int, strung>();   тоже самое можно записать так 
            decimal money = 3.0m; //для денежных операций и постфикс m (money)
            Console.WriteLine("int x = "+ x +"; float y = " + y + "f");
            Console.WriteLine("Количество денег на счете: " + money + "$");
            Console.WriteLine(); //Перенос строки для разделения
        }
//---------------------------------------------------------------------------------------------------------------------------------------------
        static void Literals() //Литералы
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
//---------------------------------------------------------------------------------------------------------------------------------------------
        static void Overflow() //переполнение, не путать с перегрузкой! (overloaded). 
            //Когда переходим максимальное значение, которое может содержать данный тип - мы возвращаемя к его минимальному значению. 
            //Как правило - это ошибка в логике, такого быть не должно. (Нежелательная ошибка)
        {
            checked //Чтобы видеть это переполнение, необходимо обвернуть ее в математическую конструкцию. Раздел checked
            {
                uint x = uint.MaxValue; //MaxValue - свойство (максимальное значение числа) Возвращает самое большое число, которое может быть представленно данным типом
                Console.WriteLine("Самое большое число x = " + x); //выводим наше значение переменной x
                x = x + 1; //в памяти будет прибавлено 1 и присвоится это значение x
                Console.WriteLine("Измененное значение " + x); //будет 0, так как это значение больше данного типа данных               
            }
           
        }
//---------------------------------------------------------------------------------------------------------------------------------------------
        static void Arithmetic_Operations() //Арифметические операции
        {
            int x = 1;
            x += 2;
            Console.WriteLine("Значение x = " + x);
            x++; //Постфиксный инкремент
            ++x; //Префиксный инкремент
            int j = 5;
            int k = j++; //к k прибавили j(5), затем j увеличилось на +1 // Постфиксный инкремент
            Console.WriteLine("Постфиксный инкремент: j++ приоритет у него ниже, чем у присваивания");
            Console.WriteLine("j = " + j + "; k = " + k); //j = 6; k = 5;
            Console.WriteLine(); //Пустая строка
            k = ++j; //Префиксный инкремент //j стало 7 (т.к. 6+1), k стало 7, так как взяло значение у j
            Console.WriteLine("Префиксный инкремент: ++j приоритет у него выше, чем у присваивания");
            Console.WriteLine("j = " + j + "; k = " + k);  //j = 7; k = 7;
            Console.WriteLine();

            int a = 2;
            int b = 2;
            int c = 5;
            int d = 7;
            int e = a - b + c * d;
            int f = a + b * 2;
            Console.WriteLine("Значение e = " + e);
            Console.WriteLine("Значение f = " + f);
            Console.WriteLine();

            Console.WriteLine("Операция остаток от деления %");
            a = 4 % 2; //Остаток от деления 0, так как делится на цело четное (0,2,4,6)
            b = 5 % 2; //Остаток от деления 1 нечетное (1,3,5,7)
            Console.WriteLine("Остаток от a = " + a + "; Остаток от b = " + b); //Позволяет определять четность нечетность числа
            Console.WriteLine();

            Console.WriteLine("Операторы сравнения bool");
            bool areEqual = a == b;
            Console.WriteLine("Значения a и b равны? " + areEqual);
            bool areBigger = a > b;
            Console.WriteLine("а больше b? " + areBigger);
        }
//---------------------------------------------------------------------------------------------------------------------------------------------
        static void StaticMethods() //Статические и не статические методы
        {
            //static относится непосредственно к типу данных: string.Метод()/Свойство_MaxValue; Не статические уровня экземпляра
            string name = "John";
            bool isContainsJ = name.Contains('J');
            Console.WriteLine("Буква J содержится в имени? " + isContainsJ);
            string len = name.Substring(1);
            Console.WriteLine("Чтение с индекса 1: "+len);
            int x = 25;
            string s = x.ToString(); //Переводит значение в строку
            Console.WriteLine("Перевод числового значения в строку: " + s);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        static void ApiBase() //Базовый API Работа со строками
        {
            string name = "James Donovan";
            bool isContainsD = name.Contains('D');
            Console.WriteLine("переменная name содержит D? " + isContainsD);
            bool isContainsM = name.Contains('M');
            Console.WriteLine("Переменная name содержит M? " + isContainsM);
           string s = name.Insert(2, "M");
            Console.WriteLine("Поменяли буквы на M: " + s);
            int index = name.IndexOf('D'); //найдем индекс строки
            Console.WriteLine("Индекс строки буквы D равен: " + index); // отсчет с нуля
            int length = name.Length;
            Console.WriteLine("Длина строки name равна: " + length); //отсчет идет с 1
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void EmptyString() //Пустые строки
        {
            string empty = "";
            string whiteSpace = " "; //1 пробел
            string notEmpty = "текст"; //не пустая строка
            string nullString = null;  //присвоили значение null - ничто. Объект пуст, его нет
            Console.WriteLine("Пустая строка: " + empty);
            Console.WriteLine("Строка с 1 пробелом: " + whiteSpace);
            Console.WriteLine("Не пустая строка с каким-то текстом: " + notEmpty);
            Console.WriteLine("Присвоили значение null: " + nullString); //null - отсутствие экземпляра

            //Методы, позволяющие определять их состояние:    
            //1) Метод: Строка Null или пустая строка?
            bool isNullOrEmpty = string.IsNullOrEmpty(empty); //метод определяет пустая строка или null
            Console.WriteLine("empty - Null или пустая строка? " + isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(whiteSpace);
            Console.WriteLine("whiteSpace - Null или пустая строка? " + isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine("notEmpty - Null или пустая строка? " + isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine("nullString - Null или пустая строка? " + isNullOrEmpty);

            //2) Метод: Строка null или есть пробел (whiteSpace)
            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine("empty - Строка null или есть пробел? " + isNullOrWhiteSpace);
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(whiteSpace);
            Console.WriteLine("whiteSpace - Строка null или есть пробел? " + isNullOrWhiteSpace);
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine("notEmpty - Строка null или есть пробел? " + isNullOrWhiteSpace);
            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine("nullString - Строка null или есть пробел? " + isNullOrWhiteSpace);
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void StringChanges() //Изменение строк
        {
            //Concat, Trim, Insert, Split, Replace, Remove
        }
 //----------------------------------------------------------------------------------------------------------------------------------------------
        static void StrBuilder() //для формирования строк, работает быстрее всех при считывании большого объема информации
        {
            StringBuilder sb = new StringBuilder(); //Создали экземпляр класса освободили под нее память
            sb.Append("Home"); //Для заполнения StringBuilder строчками используется Append экземплярный метод
            sb.Append(" sweet");
            sb.Append(" home!");
            Console.WriteLine(sb);
            string str = sb.ToString();
            Console.WriteLine(str);
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void FormatString() //Формат строк
        {
            string name = "John";
            int age = 26;
            string str = string.Format("My name is {0}, i'm {1} years old.", name, age );
            string str2 = "My name is " + name + " and i'm " + age; //Конкатенация
            string str3 = $"Hi, i'm {name} and i'm {age}"; //Интерпалирование строк
            string str4 = $"My name is \n{name} and i'm \n{age} years old" ;//Перенос строки \n
            string str5 = $"{name} are u home? \t or you are walking on the streets?"; //Табуляция tab \t 
            string str6 = $"Senior {name} {Environment.NewLine}will come to us?";//Для правильного отображения перевода новой строки в кроссплатформенных приложениях используется {Enviroment.NewLine}
            string str7 = $"How old are u? \"{age}\"";//Использование кавычек в строке либо каких-то знаков (Экранирование)
            string str8 = $"{age} of {name} contains: C:\\Windows\\tmp\\NewFolder\\"; //экранирование через слэш
            string str9 = @"C:\Windows\tmp\NewFolder\"; //Экранирование как есть с помощью собаки @
            Console.WriteLine(str);  //Вывод данных, через Format
            Console.WriteLine(str2); //Конкатенация строк
            Console.WriteLine(str3); //Интраполирование строк $"{name}, {age}"
            Console.WriteLine(str4); //перенос строки под windows \n
            Console.WriteLine(str5); //табуляция \t
            Console.WriteLine(str6); //для правильного отображения переноса строки на других платформах
            Console.WriteLine(str7); //Экранирование \знак текст \знак
            Console.WriteLine(str8); //Продолжение экранирование
            Console.WriteLine(str9); //Экранирование как есть с помощью собаки @           
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void SpecialFormat() //Специализированные форматы вывода строк
        {
            int answer = 42;
            Console.OutputEncoding = Encoding.UTF8; //Чтобы выводились рубли, нужно прописать такую кодировку
            double money = 65.8;
            double dollar = 25;
            //Прописываем команду для знака доллара
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string result = string.Format("{0:d}", answer);//Воспользуемся специальным форматированием d - вывод целых чисел
            string result2 = string.Format("{0:f}", answer); //Вывод с точной
            string result3 = string.Format("{0:C}", money); //Для форматирования в денежном формате
            string result4 = $"{money:C}"; //либо так
            string result5 = $"{dollar:C}";//Выводим доллары
            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
            Console.WriteLine(result5);
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void EqualString() //Сравнивание строк
        {
            string str1 ="abcde";
            string str2 ="abcde";
            string str3 = "James Donovan";
            string str4 = "JAMES DONOVAN";
            string str5 = "Autobahn"; //Национальные различия одного и того же слова
            string str6 = "Highway"; //Culture национальные различия одного и того же слова
            bool isEqual = str1.Equals(str2);
            Console.WriteLine($"Равны ли строки? {isEqual}"); //Вывод через интрополяцию
            isEqual = str3.Equals(str4, StringComparison.OrdinalIgnoreCase); //Игнорирует регистр
            Console.WriteLine($"Верны ли эти строки? {isEqual}");
            isEqual = str5.Equals(str6, StringComparison.CurrentCulture);
            Console.WriteLine($"Национальные различия одного и того же слова: {isEqual}");
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
       static void ReadingFromConsole() //Работа с консолью, чтение с консоли
        {
            Console.WriteLine("Hello! Please, enter your name:");
           string name = Console.ReadLine(); //Для ввода информации
            Console.WriteLine($"Welcome back, {name}!");
            Console.WriteLine("Enter your age");
            string age = Console.ReadLine();
            int convert = int.Parse(age); //Для преобразования строки в число используется Parse();
            Console.WriteLine($"Hi, {name}, your age is {convert}, not bad!");
            Console.WriteLine("Enter your balance:");
            string money = Console.ReadLine();
            decimal convertMoney = decimal.Parse(money);
            Console.WriteLine($"Your balance is: {convertMoney}$, thanks!");
            Console.Clear(); // Очищает консоль от прошлых записей
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
       static void ParsingTypes() //Преобразование типов, Парсинг
        {
            byte b = 110;
            int i = b;
            long l = i;
            float f = i;
            i = (int)f;
            b = (byte)i; //Указываем тип, к которому хотим привести переменную (явное преобразование/преведение)
            Console.WriteLine(b);
            Console.WriteLine(i);

            string str = "25";
            int convertStr = int.Parse(str);
            Console.WriteLine(convertStr);

            int x = 5;
            float result = (float)x / 2;           
            Console.WriteLine($"Преобразование типа в float: {result}"); //String через Parse, остальные через явные преобразования          
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void MathMethods() //Класс Math (округление, взятие квадратного корня)
        {
            Console.WriteLine("Возведение числа 2 в степень 3: " + Math.Pow(2, 3)); //Возведение числа 2 в степень 3
            Console.WriteLine("Квадратный корень из 9: " + Math.Sqrt(9));  //Квадратный корень из 9 = 3
            Console.WriteLine("Округление числа: " + Math.Round(145.87));  //Округление Round
            Console.WriteLine("Округление к четному числу, ис-пя в финансовых операциях: " + Math.Round(145.87, MidpointRounding.ToEven)); //округление к ближайшему четному числу, исп-ся в финансовых операциях
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void MassivesBegin() //Введение в массивы
        {
            //Способы объявления массива:

            //1) Способ:
            int[] a1;
            a1 = new int[10];
            Console.WriteLine("Длина массива равна: " + a1.Length);
            //2) Способ:
            int[] a2 = new int[5]  {5, 12, 22, -1, -6 }; //инициализация массива
            Console.WriteLine("Обращаемся к последнему элементу массива: " + a2[a2.Length-1]); //Обращаемся к последнему элементу массива
            //3) Способ:
            int[] a3 = new int[5] { 1, 3, 2, 4, 5 }; //Инициализация массива и его объявление
            Console.WriteLine("Обращение к массиву по индексу " + a3[1]+", "+a3[4]); //Обращение к массиву по индексу

            //4) Способ:
            int[] x = { 1, 2, 4, 17, 20, 15, 10, 8, 3, 5, 10 };
            Console.WriteLine("Массив числел: ");
            for (int i = 0; i < x.Length; i ++)
            Console.Write(x[i]);
            Console.WriteLine();
            //Вывод типа строка string
            string str = "Какой-то текст";
            char first = str[0];  //Вывод первой буквы по индексу нуль
            char last = str[str.Length - 1]; //вывод крайней буквы по индексу -1
            Console.WriteLine(first+", "+ last);
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void DateAndTime() //Знакомство с DateTime
        {
            DateTime now = DateTime.Now; //Текущее время
            Console.WriteLine($"Текущее время: {now}");
            DateTime newDate = DateTime.Now;
            DateTime k = newDate.AddDays(15); //прибавили 15 дней к текущей дате
            Console.WriteLine("Новая дата " + k);
            DateTime date = new DateTime(2016, 01, 15);
            TimeSpan ts = now - date; //Вычитание 2х дат
            //Тоже самое: что и 
            ts = now.Subtract(date);
            Console.WriteLine(ts.Days); //Вывод в днях          
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWork1() //Домащнее задание 1
        {
            //1. Запросить имя пользователя. Вывести Hello, [имя пользователя].
            /*2. Запросить у пользователя два целых числа и сохранить в двух переменных. Вывести значения.
                 Обменять значения переменных: 
                 например, если в переменной x было записано число 3, а в y число 5, 
                 сделать так, чтобы в y стало 3, а в x стало 5. 
                 Вывести значения после обмена.
              3. Запросить у пользователя целое число. Вывести количество цифр числа. 
                 Например, в числе 156 - 3 цифры.          
             */
            //1. пункт ДЗ
            Console.WriteLine("Введите пожалуйста свое имя: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hi, {name}! Welcome back!");

            //2. пункт ДЗ
            Console.WriteLine("Введите 2 целых числа:");
            string a = Console.ReadLine(); //Либо так без доп переменных: int a = int.Parse(Console.ReadLine());
            string b = Console.ReadLine();  // int b = int.Parse(Console.ReadLine());                    
            int convertA = int.Parse(a);
            int convertB = int.Parse(b);
            Console.WriteLine($"Первое число: {convertA}, второе число: {convertB}");

            int tmp = convertA;  //вводим новую переменную меняем значение месатми
            convertA = convertB;
            convertB = tmp;           
            Console.WriteLine($"Измененное значение 1: {convertA}");   //Меняем значения местами               
            Console.WriteLine($"Измененное значение 2: {convertB}");

            //3. пункт ДЗ
            Console.WriteLine("Введите любое целове число:");
            string number = Console.ReadLine();                              
            Console.WriteLine($"Число: {number} имеет {number.Length} цифр(ы)"); //Сколько чисел имеет введенная цифра
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWork2() //Формула Герона Д/З
        {
            /*Запросить у пользователя длины трёх сторон треугольника. 
             * Длины могут быть представлены дробными значениями.             
             * После получения длин сторон - использовать формулу Герона для вычисления площади треугольника.
             * Чтобы жизнь не казалась мёдом найдите формулу самостоятельно.
               После вычисления площади - вывести результат на консоль.
            */

            Console.WriteLine("Укажите длины сторон треугольника: ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double p = (a + b + c) / 2;
            double S = p * (p - a) * (p - b) * (p - c);
            S = Math.Sqrt(S); //Квадратный корень числа
            S = Math.Round(S, 4); //Форматированный вывод, 4 знака, после запятой
            Console.WriteLine($"Площадь по формуле Герона равна: {S}");
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
         static void HomeWork3() //Профиль пользователя Индекс массы телаД/З 
        {
            /*Запросить у пользователя: 
             * фамилию, 
             * имя, 
             * возраст, 
             * вес, 
             * рост.
             Высчитать ИМТ (индекс массы тела) по формуле 
             ИМТ = вес (кг) / (рост (м) * рост (м))

             Сформировать единую строку, в следующем формате:
             Your profile:
             Full Name: фамилия, имя
             Age: возрост
             Weight: вес
             Height: рост
             Body Mass Index: ИМТ
             Вывести сформированную строку на консоль.           
             */
            Console.WriteLine("Пожалуйста, введите Вашу Фамилию: ");
            string surname = Console.ReadLine();
           
            Console.WriteLine("Введите Ваше имя:");
            string name = Console.ReadLine();
           
            Console.WriteLine("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Укажите вес: ");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Ваш рост: ");
            double height = double.Parse(Console.ReadLine());

            double indexMassBody = weight / (height/100 * height/100);
            indexMassBody = Math.Round(indexMassBody, 2); //округление до 2х знаков после запятой
            
            Console.Write ($"Ваш профиль: {Environment.NewLine}" +
                              $"Полное имя:{surname} {name}{Environment.NewLine}" +
                              $"Возраст: {age}{Environment.NewLine}" +
                              $"Вес: {weight}{Environment.NewLine}" +
                              $"Рост: {height}{Environment.NewLine}" +
                              $"Индекс Массы Тела: {indexMassBody}");
            if (indexMassBody > 18 && indexMassBody < 24)
            {
                Console.WriteLine(" - ИМТ в норме!");
            }
            else if (indexMassBody > 24)
            {
                Console.WriteLine(" - ИМТ превышает норму!");
            }
            else if (indexMassBody < 18)
            {
                Console.WriteLine(" - ИМТ ниже нормы!");
            }
        }
//----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
