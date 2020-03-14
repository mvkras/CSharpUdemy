using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    public class Calculator
    {
        public double SqrtTreanglebyHeron(double a, double b, double c) //метод подсчета площади треугольника
        {
            double p = (a + b + c) / 2;
            double S = p * (p - a) * (p - b) * (p - c);
            S = Math.Sqrt(S); //Квадратный корень числа
            S = Math.Round(S, 4); //Форматированный вывод, 4 знака, после запятой
            return S; //Возвращаем площадь
        }
        public double SqrtBaseAndHeight(double b, double h) //метод подсчета площади треугольника
        {
            return 0.5 * b * h;
        }

        public double SqrtLength(double ab, double bc, int alpha)
        {
            double rads = alpha * Math.PI / 180; //Переводим в радианы

            return 0.5 * ab * bc * Math.Sin(rads);
        }
        
        public double Average(int [] numbers) //Метод вычисления среднего значения. Объявили переменную типа массив
        {
            double sum = 0; //Нужно посчитать сумму всех int и
            foreach (var n in numbers)
            {
                sum += n; //Складываем сумму в переменную
            }
            return sum/numbers.Length; //в качестве counter может быть длина массива затем разделить на counter, 
        }

        //С использованием Params
        public double Average2(params int[] numbers) //Перед декларацией массива пишется params, Params должен быть последним аргументом
        {
            double sum = 0; //Нужно посчитать сумму всех int и Дает возможность, передавать элементы через запятую

            foreach (var n in numbers)
            {
                sum += n; //Складываем сумму в переменную
            }
            return sum / numbers.Length; //в качестве counter может быть длина массива затем разделить на counter 
        }
        public static void TryParsed()  //Метод позволяет фильтровать данные, которые вводит пользователь, чтобы не было исключений
        {
            Console.WriteLine("Введите число:");
            string str = Console.ReadLine(); //пользователь вводит число и передается в переменную str
            bool itParsed = int.TryParse(str, out int number); //переменная позволяет проверить, тот тип данных ли он ввел
            if (itParsed)   //Если прошло удачно выведется номер (str - откуда данные брать, out int number - инициализация переменной и куда они будут выводиться)
            {
                Console.WriteLine($"Вы ввели число: {number}");
            }
            else  //если ввел бред
            {
                Console.WriteLine("Fail, it's not a number!");
            }
        }

        //Создаем метод деления с помощью out параметров, которые должны идти последними в аргументах
        public bool TryDevide(double devisible, double divisor, out double result2) //делимое, делитель частное, out параметр (возвращает результат) должен быть в конце
        {           
            /* в out параметр записывают значение, так как в  случае неудачи, туда в любом случае будет записано какое-то значение
             * поэтому следует записать значение по умолчанию (которое считаете нужным), а потом производить вычисления*/
            result2 = 0; //как правило в значение out параметра присваивают значение по умолчанию
            if(divisor == 0)
            {
                return false; //так как на нуль делить нельзя, возвращаем false
            }
            result2 = devisible / divisor; //делим значения и записываем в переменную результат            
            return true;
        }
    }
}
