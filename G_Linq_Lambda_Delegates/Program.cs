using G_Linq_Lambda_Delegates.Classes;
using System;
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

            
        }

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
    }

    
   
}
