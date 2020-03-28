using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

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
           //MultyMassives(); //Многомерные массивы
           //SawArrays(); //Зубчатые массивы
            HomeWorkParsing(); //Парсинг Римских чисел
            BubbleSort();
            Console.WriteLine();
            Console.WriteLine(RomanNumeral.Parse("XIV")); //Парсинг римских чисел

        }

        //*************************************************************************************************************************************
        static void ArraysClass() //Класс Array
        {
            /* Массивы - это набор элементов с определенным типом данных, записанных в переменную.
             * Массивы нельзя динамически расширять, их размер задается при инициализации */

            Array myArray = new int[5]; //тоже самое, что и выше. Так как это класс Array, он имеет и кое-какие методы
            myArray.SetValue(8, 0); //С помощью SetValue - устанавливаем значение 8 - значение 0 - индекс
            myArray.SetValue(2, 1);
            Console.WriteLine("Значение по индексу 0: " + myArray.GetValue(0)); //Чтобы получить значение, необходимо прописать GetValue(0) - индекс.
            Console.WriteLine("Значение по индексу 1: " + myArray.GetValue(1));  //Так как при обращении к типу Array не имеем доступа по индексу

            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int index = Array.BinarySearch(a, 6); //Метод Binary Search - возвращает индекс найденного элемента
            Console.WriteLine($"Индекс элемента 6: {index}"); //Бмнарный поиск работает только на упорядоченном массиве. Иначе надо отсортировать
            int[] b = { 0, 4, 2, 3, 1, -1, -2, -3, 5, 6, -4, -5 };
            Array.Sort(b);
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
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
                Console.Write(+reverseValues + " ");
            }
            Console.WriteLine();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        static void List() //Коллекция List
        {
            /* List(список) - это коллекция, тип. Динамически расширяемый массив, при его заполнении, создает в 2е больший массив,
             * куда перезаписывает все данные  */

            var intList = new List<int>() { 1, 4, 5, 2, 3, 0, 6 }; //можно записать сразу значение
            intList.Add(7);//Чтобы добавить значение, используется метод Add
            Console.Write("List: ");
            foreach (var values in intList)
            {
                Console.Write(values + " ");
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
        { // Dictionary - словари, когда необходим ассоциативный ряд. "Ключ - значение". Это ассоциативный массив

            var people = new Dictionary<int, string>(); //через var Dictionary<тип ключа, тип значения>
            people.Add(1, "John");  //поиск по ключам происходит очень быстро, так как они упорядоченны
            people.Add(2, "Sam");
            people.Add(3, "Dean");
            people.Add(4, "Mike");
            people.Add(5, "Andrew");
            people.Add(6, "Constantine");
            //Либо такая запись добавления:
            var fighters = new Dictionary<int, string>()
            {
                { 7, "Winchester" }, //Ключи одинаковыми быть не могут!
                { 8, "Ron" },
                { 9, "Pavel" }
            };
            //Вытаскивание по ключу значение
            string namePeople = people[1];
            string nameFighters = fighters[8];
            Console.WriteLine(namePeople + " " + nameFighters);
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
            Console.WriteLine("Количество людей в словаре: " + count);
            //Содержится ли ключ people.ContainsKey(2)
            bool containsKey = fighters.ContainsKey(9);
            Console.WriteLine(containsKey);
            //Тоже самое со значениями people.ContaintValue("John")
            //people.Remove(1) bool
            //people.TryAdd возвращает bool
            if (fighters.TryAdd(10, "Malder"))
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
            /* Stack (стэк, колода, стопка) - это абстрактный тип данных, задает определенные правила при работе с элементами
             * на их добавление и извлечение, но не предписывает, как внутри его реализовывать. Работа с массивами.
             * LIFO - ПОСЛЕДНИЙ ПРИШЕЛ - ПЕРВЫМ ВЫШЕЛ
             * Операции:
             * а) Push - добавляет новый элемент вверх  стопки, колоды; 
             * б) Pop - удаляет верхний элемент из стопки;
             * в) Peek - посмотреть верхний элемент без его удаления (не извлекая его)
             * Используется в массивах и Linked List (связных списках)  
             * Например в текстовых редакторах, когда нажимаем назад стрелку откатить (вернуть),
             * гаратнирует, что по-другому не получится выкатить данные
             * Так как работаем с массивами - можно использовать метод foreach для просмотра элементов
             */
            var stack = new Stack<int>(); //Создадим стэк без параметров
            stack.Push(1);
            stack.Push(3);
            stack.Push(5); //Была добавлена последней, поэтому покажется этот элемент
            Console.WriteLine("Последний элемент в стопке, который добавили: " + stack.Peek()); //показывает последний элемент
            Console.WriteLine("Stack(колода, стопка)");
            foreach (var value in stack) //так как работаем с массивами, можно использовать метод foreach для просмотра всех элементов
            {
                Console.Write(value + " "); //Итерация будет с конца в начало 5, 3, 1
            }
            Console.WriteLine();

            /* Queue (очередь) -абстрактный тип данных, задает определенные правила при работе с элементами 
             * на их добавление и извлечение, но не предписывает, как внутри его реализовывать.
             * FIFO - ПЕРВЫМ ПРИШЕЛ - ПЕРВЫМ ВЫШЕЛ
               Операции:
               а) Enqueue - добавляет элемент в конец очереди;
               б) Dequeue - удаляет первый элемент из очереди;
               в) Peek - посмотреть первый элемент в очереди, без его удаления; 
            */

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine("Начальный элемент в очереди: " + queue.Peek());
            Console.WriteLine("Очередь");
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        static void MultyMassives() //Многомерные массивы
        {
            /* Двумерные массивы - это матрица.  3х мерные в 99% не встречаются
             * Одномерный массив: 1 2 3
             * 
             *                  1 2 3
             * Двумерый массив: 4 5 6
             *                  7 8 9
             * Двумерные массивы состоят из строчек и столбцов
             * Может содержать x - строчек, y - столбцов
             * Может содержать 4 столбца и 2 строки и наоборот, необязательно ему быть квадратным
             */

            int[,] a = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } }; //Создание двумерного массива [2 - количество строк, 3 количество столбцов]
            /*Вот такой массив получился:
             * 1 2 3
             * 4 5 6
             * 2 строки, 3 столбца
             */

            //Пройдемся по массиву а - выведем его элементы. Для этого необходим вложенный цикл
            Console.WriteLine("Длина двумерного массива a:");
            for (int i = 0; i < a.GetLength(0); i++) /*a.GetLength(0) - указываем размерность, у которой берем длину. 
                                                                        У каждой строки может быть разная длина. Поэтому
                                                                        Для каждой строки указываем размерность! */
            {
                Console.Write("{ ");
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]}, ");
                }
                Console.Write("}");
                Console.WriteLine();

            }
            /* Вывод такой: в цикле сперва берется 1 строка - 1 столбец
             *                                     1 строка - 2 столбец
             *                                     1 строка - 3 столбец
             *                                     2 строка - 1 столбец
             *                                     2 строка - 2 столбец
             *                                     2 строка - 3 столбец
             */
            //Тоже самое можно сделать и так:
            int[,] b = { { 8, 7, 4 }, { -5, -1, 2 } };
            Console.WriteLine("Массив b:");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                Console.Write("{ ");
                for (int j = 0; j < b.GetLength(1); j++) //Если поменять местами GetLenght(0 и 1) то будет чтение по колонкам, а не строкам
                {
                    Console.Write($"{b[i, j]}, ");
                }
                Console.Write("}");
                Console.WriteLine();
            }
            //Создадим двумерный массив и попросим пользователя его заполнить:
            Console.WriteLine("Введите значения для двумерного массива:");
            int[,] c = new int[3, 4];
            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    string str = Console.ReadLine();
                    c[i, j] = int.Parse(str);
                }
            }
            //Создаем цикл для вывода значений


            for (int i = 0; i < c.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    Console.Write($"{c[i, j]} ");

                }

            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        static void SawArrays() //Зубчатые массивы. Редко где используются
        {
            int[][] jaggedArray = new int[4][]; //Указываем 4 строки, и отдельно к каждой строке обращаемся, указываем кол-во элементов
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[1];
            jaggedArray[3] = new int[4];
            //Попросим пользователя заполнить массив:
            Console.WriteLine("Заполните зубчатый массив:");
            for (int i = 0; i < jaggedArray.Length; i++) //количество строк
            {
                for (int j = 0; j < jaggedArray[i].Length; j++) //длина i-й строки. Это столбец
                {
                    string str = Console.ReadLine(); //читаем ввод
                    jaggedArray[i][j] = int.Parse(str); //Парсим в инт, что пользователь нам ввел и передаем в массив
                }
            }
            Console.WriteLine($"Выводим элементы зубчатого массива: ");
            for (int i = 0; i < jaggedArray.Length; i++) //количество строк
            {
                for (int j = 0; j < jaggedArray[i].Length; j++) //длина i-й строки
                {
                    Console.Write($"{jaggedArray[i][j]} ");

                }
                Console.WriteLine();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWorkParsing() //Парсинг Римских чисел
        {
            /* Написать функцию, которая принимает на вход строку - римское число, 
             * возвращает это число в арабском виде.
             * Например, если передаём "XV" - должна вернуть 15, 
             * если передаём "IV" - должна вернуть 4.
             * Вот список римских символов и их отображение на арабские числа:
             * I - 1
             * V - 5
               X - 10
               L - 50
               C - 100
               D - 500
               M - 1000
               "Необходимо отметить, 
               что другие способы «вычитания» недопустимы; 
               так, число 99 должно быть записано как XCIX, но не как IC."
               Подсказка. Для решения надо реализовать два правила:
               Правила записи чисел римскими цифрами:
               a) если большая цифра стоит перед меньшей, то они складываются (принцип сложения),
               b) если меньшая цифра стоит перед большей, то меньшая вычитается из большей (принцип вычитания).
               Защиту от некорректного ввода реализовать по вашему желанию (можно не делать, но для тренировки всегда полезно).
               XIV = 10 - 1 + 5= 9 + 5 = 14
             */
        }

        static void BubbleSort() //сортировка пузырьком
        {
            int[] unsortedArray = { 1, 4, 3, 2, 6, 5, 0, 7, 9, 8, 11, 10 }; //инициализировали массив
            int temp; //наша переменная
            for (int i = 0; i < unsortedArray.Length-1; i++) //внещний цикл
            {
                for (int j = i+1; j < unsortedArray.Length; j++) //Сначала он от начала до конца пройдет по внутреннему циклу, 
                {                                               //затем +1 на внешний цикл. 
                                                               //Сперва проверит все значения с 0 индексом, затем с 1 и тд
                    if (unsortedArray[i] > unsortedArray[j]) //условие, если 1 значение больше другого - поменять местами
                    {
                        temp = unsortedArray[i];  
                        unsortedArray[i] = unsortedArray[j];
                        unsortedArray[j] = temp;
                    }                                     
                }                
            }
            foreach (var item in unsortedArray) //выводим наш цикл вновь
            {
                Console.Write($"{item} ");
            }
        }

           
    }

}

    



    

