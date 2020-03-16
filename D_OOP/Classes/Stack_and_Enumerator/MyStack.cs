using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace D_OOP.Classes
{
    class MyStack<T> : IEnumerable<T> //Сделали наш класс обобщенным Generics
    {
        private T[] _items; //Везде, где использовали object заменить на Т
        public int Counter { get; private set; } //записывать чтобы могли только мы (set) реально хранимые объекты в массиве items
        //чтобы внешний код мог почитать емкость, создадим свойство capacity
        public int Capacity { get { return _items.Length; } } //только для чтения, возвращает длину массива, возвращает количество
                                                              //возможных хранимых элементов
        
        //Создадим 2 конструктора, 1 по умолчанию 
        public MyStack()
        {
            const int defaultCapacity = 4; //создаем не изменяемое значение размер массива
            _items = new T[defaultCapacity];

        }
        //конструктор позволяет в явном виде передать Capacity размерность
        public MyStack(int capacity)
        {
            _items = new T[capacity]; //создаем массив типа object такой размерности
        }

        //Реализуем операцию push
        public void Push(T item) //необходимо обработать 2 ситуации, когда массив items еще не заполнен и когда заполнен
        {
            //если заполнен
            if(_items.Length == Counter)
            {
                //временно нужно объявить массив большего размера
                T[] largerArray = new T[Counter * 2];
                //с помощью метода copy копируем наш старый массив в большего размера
                Array.Copy(_items, largerArray, Counter); //указываем количество копируемыз элементов               
                _items = largerArray; //Затем в _items записываем ссылку на наш только что созданный массив
            }
            //добавляем элемент по индексу count
            _items[Counter] = item;
            Counter++; //сдвигаем counter на +1
        }

        //Реализуем метод Pop удаления
        public void Pop()
        {
            //если человек пытается изъять элемент из пустого стэка, то мы должны выбросить исключение и сказать это не возможно
            if(Counter == 0) //если равен нулю, то Pop вызывать нельзя
            {
                throw new InvalidOperationException("Исключение: Это невозможно сделать!"); //Если выброшено исключение, дальше код выполняться не будет
            }
            //должны изъять элемент
            _items[Counter] = default(T); //не все типы поддерживают null, меняем его
            --Counter; //префиксный декремент, сначало будет сделано удаление, а затем обращение по декрементированному индексу
        }

        //Реализуем метод Peek (чтение без удаления)
        public T Peek() //должен возвратить последний элемент
        {
            //если нет значений, то ничего не будем возвращать
            if (Counter == 0) //если равен нулю, то Peek вызывать нельзя
            {
                throw new InvalidOperationException("Исключение: Это невозможно сделать!"); //Если выброшено исключение, дальше код выполняться не будет
            }
            return _items[Counter - 1]; //чтобы взять последний элемент, нужно из counter вычесть -1, так как счет с нуля идет
        }

        //   public IEnumerator<T> GetEnumerator()
        // {
        //    return new StackEnumerator<T>(_items, Counter);
        //}

        //2й ленивый способ Энумератора yield
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Counter-1; i >= 0; i--)
            {
                yield return _items[i]; //произвести

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
