using G_Linq_Lambda_Delegates.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using static G_Linq_Lambda_Delegates.Classes.Delegates;

namespace G_Linq_Lambda_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            #region delegates
            //мы дергаем делегат и он вызывает метод, такая цепочка событий появляется, тянет за собой
            MyDelegate myDelegate = Method1; //присваеваем метод делегату и вызываем метод через делегат
            //чтобы добавить метод еще 1 к делегату, используется += метод
            myDelegate += Method4; //1 раз обращаемся к делегату, обращаемся ко всем добавленным к нему методам
            myDelegate += Method1;
            myDelegate -= Method1; //удаление метода из делегата
            myDelegate();

            Console.WriteLine(); //пробел строки

            //2й способ создания делегата и передачи в него метода:
            MyDelegate myDelegate2 = new MyDelegate(Method4); //в качестве параметра передается метод
            myDelegate2 += Method1;
            myDelegate2.Invoke(); //вызов метода

            //Совместим 2 делегата в 1м
            MyDelegate myDelegate3 = myDelegate + myDelegate2;
            Console.Write("Совмещаем 2 делегата в 3м: ");
            myDelegate3();

            //Делегат со значением
            MyDelegate2 myDelegateValue = new MyDelegate2(MethodValue);
            myDelegateValue((new Random()).Next(10, 50)); //будет возвращено рандомное число от 10 до 50
            myDelegateValue(5);

            //Шаблоны делегато Action
            Action action = Method1;
            Console.Write("Шаблон делегата Action: ");
            action();

            //Action с аргументом <int>
            Action<int> actionWithValue;
            actionWithValue = Method2;
            actionWithValue(25);

            //Func - работают с возвращаемым типом return иогут быть аргументы или нет(они идут перывми)
            Func<string, int> func;
            func = Method3;
            func("Строка");

            Func<int, int> funcWithValue = MethodValue;
            funcWithValue(15);
            Console.WriteLine();
            #endregion

            //События
            Person John = new Person();
            John.name = "John";
            John.GoToSleep += John_GoToSleep; //создаем событие, подписываемся на него (нажали на tab, создался метод)
            John.DoWork += John_DoWork;//подписываемся на событие DoWork
            John.Sleep(DateTime.Parse("20.03.20 22:59:50"));
            John.Sleep(DateTime.Parse("20.03.20 07:58:50"));
            Console.WriteLine();


            DisplayFoundFiles_WithoudLinq(@"G:\Программа для карточек стима");


        }
        //********************************************************************************************************************************************
        private static void John_DoWork(object sender, EventArgs e)
        {
            if (sender is Person) //нам нужно этот тип object привести к типу Person. в нормальном проекте причем безопасно
            {
                Console.WriteLine($"{((Person)sender).name} Time to work");  //сделали проверку, чтобы было безопасно
            }
        }

        private static void John_GoToSleep() //теперь для события, нам необходим обработчик события, нам нужно подписаться на это событие
        {
            Console.WriteLine("Time to Sleep!");
        }

        //---------------------------------------------Linq_Lyambda_Expressions--------------------------------------------------------------------

        /* Предположим надо разработать метод, который принмает путь к паапке и нам нужно взять первые 5 самых крупных файлов,
        * которые находятся в этой папке */

        public static void DisplayFoundFiles_WithoudLinq(string pathToDir) //метод поиска пути к папки без использования Linq
        {
            //забрать разные файлы с директории можно с помощью разных API
            //создадим такой тип, который называется DirectoryInfo находится в System.IO
            DirectoryInfo dirInfo = new DirectoryInfo(pathToDir); //в конструктор передается путь
            FileInfo[] files = dirInfo.GetFiles(); //Имея этот экземпляр, мы можем запросить все файлы и вернет их  оттуда. Вернет массив экзепляров fileInfo

            //теперь нам их необходимо отсортировать по длине
            Array.Sort(files, FileComparison); //10 перегрузка с делегатом говорит о том как сортировать элементы, должны передать метод, который будет вызываться внутри Sort
            //теперь запускаем цикл for в отсортированном массиве
            for (int i = 0; i < 5; i++) //выводим топ 5
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} размер файла {file.Length}");
            }
        }

        static int FileComparison(FileInfo x, FileInfo y) //должна принимать 2 экземпляра FileInfo, т.к чтобы сравнить, надо 2 экземпляра
        {
            //если хотим чтобы x был первым, он должен быть больше у и возвращать -1 должны
            //Когда они равны - возвращаем 0
            //Когда x должен идти после y возвращаем 1
            //Возвращать 1 или -1 зависит от того в каком порядке возвращать значения (по убыванию или возрастанию)
            if (x.Length == y.Length)
            {
                return 0;
            }
            if (x.Length > y.Length)
            {
                return -1;
            }
            return 1;  //На основе этого делегата FileComparison метод сортировки будет сравнивать значения и выводить большее 
        }
        //---------------------------------------------------Теперь с использованием Linq и Лямбда выражений------------------------------------------

        private static void Find_Files_With_Linq(string pathToDIr)
        {
            //конструируем DirectoryInfo
            new DirectoryInfo(pathToDIr) //как бы на экземпляре поставили точку
           .GetFiles() //получили массив fileInfo
           .OrderByDescending(file => file.Length) //GitFiles возвращает массив fileInfo на него поставили точку Нам нужно отсортировать по размеру
           .Take(5) //затем нужно взять первые 5 файлов
           .ForEach(file => Console.WriteLine($"{file.Name} размер: {file.Length}"));
        }

        //static long KeySelector(FileInfo file)
        //{
        //    return file.Length;
        //}

        

    }

    //Расширение для Linq в качестве цикла for
    public static class LinqExtention
    {
        //все методы расширения - статические
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) //принимает так же делегат
        {
            //нечто, что будем делать с каждым из экзепляров, находяшимся в source
            //можно проставить зашиту 
            if(source == null)
            {
                throw new ArgumentNullException("Нельзя чтобы source был равен null");
            }
            foreach (var item in source)
            {
                action(item); 
            }
        }
    }


}
