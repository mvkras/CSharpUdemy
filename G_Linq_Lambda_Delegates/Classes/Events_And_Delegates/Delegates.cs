using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_Linq_Lambda_Delegates.Classes
{
  public  class Delegates
    {
        public delegate void MyDelegate(); //объявили делегат его можно в классе объявлять или за ним
        
        public delegate int MyDelegate2(int a); //делегат с аргументами

        //Шаблоны делегата их можно объявлять только внутри класса
        //Нам не всегда нужно самому объявлять делегаты, можно пользоваться шаблонами
        public Action actionDelegate; //это Action - это группа делегатов, которые не возвращают нам значений, могут принмать от 0 до 16ти аргументов
        public Action<int> actionValue; //Если хотим с аргументом сделать шаблон используется дженерик <int>

        //Кроме Action, есть еще Predicate
        Predicate<int> predicate; //тоже самое, что и public delegate bool Predicate<T>(T value)
        //Возвращает булевое значение (bool) и принимает 1 аргумент

        //Func<int, string> должен принимать как минимум 1 тип и 16 других 2й тип - тип возвращаемого значения
        Func<string, int> func; //Раскрывается так:  public delegate int Func(string value);
        //Работает с методами у которых есть возвращаемое значение: public static int Method() {return 0;}

        //Объявляем методы 
        public static void Method1()
        {
            Console.WriteLine("Вызов 1го метода");
        }
        public static void Method2(int a)
        {
            Console.WriteLine("Вызов 2го метода");
            
        }
        public static int Method3(string str)
        {
            Console.WriteLine("Вызов 3го метода "+str);
            return 0;
        }
        public static void Method4()
        {
            Console.WriteLine("Вызов 4го метода");
        }
        public static int MethodValue(int x)
        {
            Console.WriteLine("Вывод со значениями: "+x);
            return x;
        }

    }
}
