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
        
        public double Average(int [] numbers) //Метод вычисления среднего значения
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
    }
}
