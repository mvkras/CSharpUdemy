using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace D_OOP.Classes
{
    class StackEnumerator<T> : IEnumerator<T> //интерфейс Энумератор, чтобы вызывать метод foreach для класса
    {
        private readonly T[] array;
        private readonly int count;
        private int position; //заведем итератор, по умолчанию равен -1, т.к 1й элемент находится по 0-му индексу

        public StackEnumerator(T[] array, int count) //создаем конструктор, который принимает массив типа <T>
        {
            this.array = array;
            this.count = count;
            position = count;
        }
        public T Current { get { return array[position];  } } //позицию используем как курсор, индексатор

        object IEnumerator.Current { get { return Current;  } } //то что возвращается с верхнего Current будет завернуто в object

        public void Dispose() //удалить из памяти, обычно оставляют пустым
        {          
        }

        public bool MoveNext() //возвращает, если есть элемент дальше, иначе будет позвращать false
        {
            position++;
            return position >= 0; //если position меньше длины массива, который мы итерируем, это значит, что след. элемент у нас есть 
        }

        public void Reset() //сброс
        {
            position = count; //должен возвращать курсор в изначальную позичию -1
        }
    }
}
