using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes.Interfaces
{
    class BaseList : ICollection //наследуется от интерфейса ICollection
    {
        private object[] items;
        private int counter = 0; //счетчик чтобы отсчитывать сколько у нас объектов для вставки по индексам
        //Конструктор
        public BaseList(int initialCapacity) //начальная длина
        {
            items = new object[initialCapacity]; //проинициализируем массив массив размера initialCapacity
        }
            //Методы интерфейса ICollection
        public void Add(object obj)
        {
            items[counter] = obj; //используем counter как индекс
            counter++; //добавили элемент в массив, увеличили counter
        }

        public void Remove(object obj)
        {
            items[counter] = null;
            counter--;
        }
    }
}
