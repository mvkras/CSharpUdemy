using G_Linq_Lambda_Delegates.Classes;
using G_Linq_Lambda_Delegates.Interfaces;
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

            //Linq
            List<int> collection = new List<int>(); //создали список
            for (var i = 0; i < 10; i++) //создали полную коллексию
            {
                collection.Add(i);
            }
            //записали с помощью запроса SQL
            var result = from item in collection //выбрали первые 5
                         where item < 5
                         select item;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();//пропуск

            //Тоже самое с помощью методов расширений
            var result2 = collection.Where(item => item < 5)
                                    .Where(item => item % 2 == 0) //четные 
                                    .OrderByDescending(item => item); 

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            //Будет создаваться коллекция наших продуктов (другой пример)
            //создадим генератор случайных чисел
            var random = new Random();
            
            List<Linq_And_Lyambda_Expressions> productCollection = new List<Linq_And_Lyambda_Expressions>();
            for (var i = 0; i < 10; i++) //создали полную коллексию
            {
                var product = new Linq_And_Lyambda_Expressions()
                {
                    Name = "Продукт " + i,
                    Energy = random.Next(10, 500)
                };
                productCollection.Add(product); //заполняем нашу коллекцию
            }
            var productResult = productCollection.Where(item => item.Energy < 200);
            foreach (var item in productResult)
            {
                Console.WriteLine(item);
            }

            //Преобразование 1 типа в другой Select. В Linq select служит для преобразования
            //Из списка продуктов мы делаем список целых чисел
            List<Linq_And_Lyambda_Expressions> products = new List<Linq_And_Lyambda_Expressions>();
            for (var i = 0; i < 10; i++) //создали полную коллексию
            {
                var product = new Linq_And_Lyambda_Expressions()
                {
                    Name = "Продукт " + i,
                    Energy = random.Next(10, 15)
                };
                products.Add(product); //заполняем нашу коллекцию
            }
            var selectCollection = products.Select(product => product.Energy); 
            foreach (var res in selectCollection) 
            {
                Console.WriteLine(res);
            }
            var orderProducts = products.OrderBy(product => product.Energy).ThenBy(product => product.Name); //на выходе получили коллекцию целых чисел
            foreach (var res in orderProducts) //чтобы упорядочить по 2м условиям нужно использовать then by. но только после OrderBy
            {
                Console.WriteLine(res);
            }
            Console.WriteLine();
            var groupByEnergy = products.GroupBy(product => product.Energy); //разобьем продукты по энергетической ценности                                                                                
            foreach (var group in groupByEnergy) //его надо перебирать с помощью цикла так как это список списка возвращает гурппированный элемент     
            {
                  
                Console.WriteLine($"Ключ: {group.Key}"); //первый элемент является ключем, 2й коллекцией элементы которые удолетворяют этому ключу
                foreach (var item in group) //здесь уже идет перебор элементов
                {
                    Console.WriteLine($"\t{item}");
                }
            }
            Console.WriteLine();
            //Linq продолжение по ChessPlayers напишем метод который выводит max, min, avg рейтинг топ 10
            static void MinMax_Avg(string file) //будет принимать путь к файлу
            {
                List<ChessPlayer> list = File.ReadAllLines(file) //начнем с чтения возвращает массив string
                                         .Skip(1) //на массиве можно вызывать точку. Пропускаем первую строчку т.к. там наименования
                                         .Select(ChessPlayer.ParseFile) //берет элемент и трансформирует в другой тип 
                                         .Where(x => x.BirthYear > 1988)
                                         .OrderByDescending(player => player.Raiting) //отсортируем по убыванию
                                         .Take(10)
                                         .ToList(); //чтобы работать со списокм метод расширения, который превращает в List
                Console.WriteLine($"The lowest raiting in top 10: " +
                    $"{list.Min(x => x.Raiting)}, max raiting: {list.Max(x => x.Raiting)}, " +
                    $"avg: {list.Average(x => x.Raiting)}");
            }

            MinMax_Avg("Top100ChessPlayers.csv");
            RemoveForEach(); //Модификация метода foreach
            RemoveAllFromList(); //С использованием RemoveAll
           
            static void RusChessPlayers(string file)
            {
                Console.WriteLine("Список Российских шахматистов: ");
                List<ChessHomeWork> list = File.ReadAllLines(file)
                                           .Skip(1)
                                           .Select(ChessHomeWork.ParseInfo) //В Select строчки передаем которые парсятся
                                           .Where(player => player.Country == "RUS")
                                           .OrderBy(player => player.BirthDay)
                                           .ToList();
                foreach (var item in list)
                {
                    Console.WriteLine($"\t{item}");
                }
                
            }
            RusChessPlayers("Top100ChessPlayers.csv");

            //Интерфейсы
            List<ICar> cars = new List<ICar>();
            cars.Add(new BMW()); //В этот список машин может добавлять наши классы
            cars.Add(new LadaSedan()); //Создали массив объектов, который можем помещать любые классы
            cars.Add(new Toyota());
            foreach(var item in cars)
            {                
                Console.WriteLine("Затраченно время машин: "+item.Move(965)+"часов");
            }
            Cyborg cyborg = new Cyborg();
            Console.WriteLine("Киборг пробежал 75 км за "+((IPerson)cyborg).Move(75)+" часа"); //явное привидение интерфейса


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

        //Модицикация цикла foreach в этом цикле нельзя ничего менять, нужно использовать цикл for и i--
        static void RemoveForEach()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= 3)
                {
                    var item = list[i];
                    list.Remove(item);
                    i--;
                }              
            }
            Console.WriteLine(list.Count);
        }

        static void RemoveFromBackSide() //удаление в обратном порядке
        {
            static void RemoveForEach()
            {
                List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };
                for (int i = list.Count-1; i >= 0; i--)
                {
                    if (list[i] <= 3)
                    {
                        var item = list[i];
                        list.Remove(item);
                        i--;
                    }
                }
                Console.WriteLine(list.Count);
            }
        }
        //3й способ Remove All 
        static void RemoveAllFromList()
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };
            list.RemoveAll(list => list <= 3);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
           
        }

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
