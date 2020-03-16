using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes.Polymorphism
{
    class Rectangle : Shapes //Класс прямоугольник (наследуется от абстрактного класса Shapes(фигура)) полиморфизм 
    {
        //создадим поля
        private readonly double width;
        private readonly double height;
        //Создадим конструктор в котором будут передаваться эти поля
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            Console.WriteLine("Drawing Rectangle..."); //Прямоугольник создан
        }
        //Имплементируем эти методы(запишем их в наш класс (Ctrl + . (точка)))
        public override void Draw() 
        {
            Console.WriteLine("Rectangle created!");
        }
        public override double Area() //Площадь треугольника
        {
            double S = width * height; //Площадь треугольника = ширина * высоту
            S = Math.Round(S, 2);
            Console.WriteLine($"Площадь прямоугольника = {S}");
            return S;
        }
       
        public override double Perimeter() //Периметр (сумма всех сторон)
        {
            double P = (width + height) * 2;
            Console.WriteLine($"Периметр прямоугольника = {P}");
            return P;
        }
    }
}
