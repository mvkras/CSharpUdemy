using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes.Interfaces
{
    //Интерфейсы. Объявляются они с помощью слова interface и название их начинается с заглавной буквы I
    public interface ICollection
    {
        void Add(object obj);
        void Remove(object obj);
    }

}
