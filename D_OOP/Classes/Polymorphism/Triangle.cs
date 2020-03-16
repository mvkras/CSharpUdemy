using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes.Polymorphism
{
    class Triangle : Shapes
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;
         

        public Triangle(double a, double b, double c) //конструктор треугольника
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Console.WriteLine("Drawing triangle...");

        }
        public override double Area()
        {
            double p = (a + b + c) / 2; //полупериметр для формулы Герона (нахождение площади треугольника)
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            S = Math.Round(S, 2);
            Console.WriteLine($"Площадь треугольника = {S}");
            return S;
            
        }

        public override void Draw()
        {
            Console.WriteLine("Triangle created!");
        }

        public override double Perimeter()
        {
            double P = a + b + c;
            Console.WriteLine($"Периметр треугольника = {P}");
            return P;
        }
    }
}
