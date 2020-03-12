using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace C_ArraysCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ArraysClass(); //Класс Array
            List(); //Коллекция List
            Dictionary(); //Словари (Ключ - значение. Ассоциативный ряд)
            StackAndQueue(); //Стек и очередь

        }

//*************************************************************************************************************************************
        static void ArraysClass() //Класс Array
        {          
            Array myArray = new int[5]; //тоже самое, что и выше. Так как это класс Array, он имеет и кое-какие методы
            myArray.SetValue(8, 0); //С помощью SetValue - устанавливаем значение 8 - значение 0 - индекс
            myArray.SetValue(2, 1);
            Console.WriteLine("Значение по индексу 0: " + myArray.GetValue(0)); //Чтобы получить значение, необходимо прописать GetValue(0) - индекс.
            Console.WriteLine("Значение по индексу 1: "+myArray.GetValue(1));  //Так как при обращении к типу Array не имеем доступа по индексу

            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int index = Array.BinarySearch(a,6); //Метод Binary Search - возвращает индекс найденного элемента
            Console.WriteLine($"Индекс элемента 6: {index}"); //Бмнарный поиск работает только на упорядоченном массиве. Иначе надо отсортировать
            int[] b = { 0, 4, 2, 3, 1, -1, -2, -3, 5, 6, -4, -5 };
            Array.Sort(b);
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i]+" ");
            }
            Console.WriteLine();
            int[] c = new int[5];
            Array.Copy(a, c, 5); //Copy позволяет копировать массивы a-какой массив копируем,  c- куда копируем  5- количество элементов которые копируем
            foreach (int copyValue in c)
            {
                Console.WriteLine("Скопированный массив из 5 элементов: " + copyValue);
            }
            Array.Reverse(a); //Переворачивает массив
            Console.WriteLine("Reverse массива:");
            foreach (var reverseValues in a)
            {
                Console.Write(+reverseValues+" ");
            }
            Console.WriteLine();
        }
//-------------------------------------------------------------------------------------------------------------------------------------
        static void List() //Коллекция List
        {
            var intList = new List<int>() { 1, 4, 5, 2, 3, 0, 6 }; //можно записать сразу значение
            intList.Add(7);//Чтобы добавить значение, используется метод Add
            Console.Write("List: ");
            foreach (var values in intList)
            {
                Console.Write(values+" ");
            }                 
            int[] array = { -5, 4, 10, 8, -6 };           
            intList.AddRange(array); //В лист можно добавлять так же целый массив с помощью AddRange(что добавляем)
            Console.WriteLine();
            Console.Write("Добавленный список: ");
            foreach (var values in intList)
            {
                Console.Write(values + " ");
            }
            Console.WriteLine();
          if (intList.Remove(-5)) //Удаление элемента из списка, удаляет первое попадание из списка Remove(значение элемента)
            {
                Console.WriteLine("Удаление прошло успешно!");
            }
            //Если хотим сделать удаление по индексу, используется RemoveAt(индекс)
            // Поменять местами Reverse()
            bool contains = intList.Contains(3); //Contains(3) - содержится ли определенный элемент в листе 
            int min = intList.Min(); //Находит минимальный элемент в листе 
            int max = intList.Max(); //Находит максимальный элемент в листе
            Console.WriteLine($"Есть ли цифра 3? {contains}, min = {min}, max = {max}");
            int indexOf = intList.IndexOf(7); //нахождение элемента по индексу
            int lastIndexOf = intList.LastIndexOf(4);
            Console.WriteLine($"{indexOf} {lastIndexOf}");
            //В цикле for у него вместо intList.Length  intList.Count
            for (int i = 0; i < intList.Count; i++)
            {
                Console.Write(intList[i] + " ");
            }
            Console.WriteLine();
        }
//-------------------------------------------------------------------------------------------------------------------------------------
        static void Dictionary() //Словари (ключ - значение. Например тот же словарь: Слово - ключ; описание слова - значение)
        {
            var people = new Dictionary<int, string>(); //через var Dictionary<тип ключа, тип значения>
            people.Add(1, "John");  //поиск по ключам происходит очень быстро, так как они упорядоченны
            people.Add(2, "Sam");
            people.Add(3, "Dean");
            people.Add(4, "Mike");
            people.Add(5, "Andrew");
            people.Add(6, "Constantine");
            //Либо такая запись добавления:
          var  fighters = new Dictionary<int, string>()
            {
                { 7, "Winchester" }, //Ключи одинаковыми быть не могут!
                { 8, "Ron" }, 
                { 9, "Pavel" }
            };
            //Вытаскивание по ключу значение
            string namePeople = people[1];
           string nameFighters = fighters[8];
            Console.WriteLine(namePeople+ " " +nameFighters);
            var key = people.Keys;  //количество ключей
            foreach (int values in key)
            {
                Console.WriteLine(values);
            }
            //Тоже самое можно пройтись по значениям ключей с помощью people.Values
            var descr = people.Values;
            foreach (var value in descr)
            {
                Console.WriteLine(value);
            }
            //Чтобы узнать как ключ, так и значение - используется просто цикл foreach к словарю
            Console.WriteLine("Информация о людях:");
            foreach (var info in people)
            {
                Console.WriteLine(info);
            }
            //Можно запросить количество элементов в словаре, через свойство people.Count
            int count = people.Count;
            Console.WriteLine("Количество людей в словаре: "+count);
            //Содержится ли ключ people.ContainsKey(2)
            bool containsKey = fighters.ContainsKey(9);
            Console.WriteLine(containsKey);
            //Тоже самое со значениями people.ContaintValue("John")
            //people.Remove(1) bool
            //people.TryAdd возвращает bool
            if(fighters.TryAdd(10, "Malder"))
            {
                Console.WriteLine("Success! Name was added!");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            //TryGetValue(2, our string val) попытаться найти значение по ключу и передать ее в эту переменную, которую объявили
          people.TryGetValue(2, out string val);
            Console.WriteLine(val);
            //Метод people.Clear() удаляет все пары ключ - значения
        }
//-------------------------------------------------------------------------------------------------------------------------------------
       static void StackAndQueue() //Стек и очередь
        {

        }
    }
}
