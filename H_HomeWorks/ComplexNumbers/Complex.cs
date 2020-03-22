using System;
using System.Collections.Generic;
using System.Text;

namespace H_HomeWorks.ComplexNumbers
{
    //Д/З 1 "Комплексные числа"

    /* Разработать класс представляющий комплексное число. 
     * Класс должен содержать два свойства для представления вещестенной (double) и мнимой части (double). 
     * Сделать так, чтобы создать экземпляр класса без передачи соответствующих аргументов было невозможно.
     * 
     * Создать два метода, реализующих сложение и вычитание двух комплексных чисел. 
     * Чтобы сложить два комплексных числа необходимо по отдельности сложить их вещественные и мнимые части.
     * 
     * То есть, предположим, что мы имеет два комплексных числа. 
     * У первого вещественная часть равна 1, мнимая 2. 
     * У второго вещественная часть равна 3, мнимая 1. 
     * Результатам будет комплексное число, где вещественная часть равна 1 + 3 = 4, а мнимая равна 2 + 1 = 3.
     * 
     * Операция вычитания работает по тому же принципу, что и сложение (ну, только вычитание).
       API спроектировать таким образом, чтобы клиентский код мог написать следующий код:
       Complex c1 = new Complex(1, 1);
       Complex c2 = new Complex(1, 2);

       Complex result = c1.Plus(c2); */

   public class Complex
    {
        public double NaturalsNumbers { get; private set; } //вещественное
        public double ImagineNumbers { get; private set; } //мнимое чилсо



        public Complex(double naturalsNumbers, double imagineNumbers)
        {
            NaturalsNumbers = naturalsNumbers;
            ImagineNumbers = imagineNumbers;
        }

        private Complex()
        {
        }

        public Complex Plus(Complex other)
        {
            var complex = new Complex();
            complex.NaturalsNumbers = other.NaturalsNumbers + NaturalsNumbers;
            complex.ImagineNumbers = other.ImagineNumbers + ImagineNumbers;
            return complex;
        }

        public Complex Minus(Complex other)
        {
            var complex = new Complex();
            complex.NaturalsNumbers = other.NaturalsNumbers - NaturalsNumbers;
            complex.ImagineNumbers = other.ImagineNumbers - ImagineNumbers;
            return complex;
        }
    }
}
