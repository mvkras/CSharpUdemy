using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes
{
    public struct PointVal //Вместо класса пишем struct по сути это одно и тоже, различие лишь в том, что не надо создавать экземпляр класса
    {                     // User tom - создали struct(структуру), вместо этого: User tom = new User(); и поля к tom должны быть заданы и определены 
        public int x;
        public int y;

        public void LogValues()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }

    }


    public class PointRef //наш класс, сверху структура
    {
        public int x;
        public int y;

        public void LogValues()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }

    }
}
