using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes
{
    //Наследование
    public class BankTerminal
    {
        protected int id; //Модификатор protected будет унаследован в классах-наследниках и защищен от внешнего мира
        //Создадим конструктор, чтобы каждый раз не писать конструкторы для классов наследников
        public BankTerminal(int id)
        {
            this.id = id;
        }
        public virtual void Connect() //метод - connect объявляем virtual, чтобы 1 часть наследников могла им воспользоваться, 
                                     //другая - переопределить его 
        {
            Console.WriteLine("General Connecting Protocol...."); //Реализует базовый сценарий подключения к серверу
        }
    }

    public class ModelA : BankTerminal //унаследовал поля от BankTerminal
    {
        public ModelA(int id) : base(id) //Передаем работу базовому конструктору
        {
            //с помощью такого синтаксисы мы создаем базовый конструктор и передаем туда id
        }
       public override void Connect() //Переопределим(перезапишем метод базового класса словом override)
        {
            //чтобы воспользоваться методом базового класса(базового метода), используется слово base.Метод базовый
            //затем дополняем наш метод, записывая какие-то дополнительно команды
            base.Connect();
            Console.WriteLine("Подключение терминала 1: Additional activity for ModelA"); //перезаписали/изменили метод добавив что-то новое
        }
    }

    public class ModelB : BankTerminal //унаследовал поля от BankTerminal
    {
        public ModelB(int id) : base(id) //Передаем работу базовому конструктору
        {
            //с помощью такого синтаксисы мы создаем базовый конструктор и передаем туда id
        }
        public override void Connect() //Переопределим(перезапишем метод базового класса словом override)
        {
            //чтобы воспользоваться методом базового класса(базового метода), используется слово base.Метод базовый
            //затем дополняем наш метод, записывая какие-то дополнительно команды
            
            Console.WriteLine("Подключение терминала 2: Activity for ModelB"); //перезаписали/изменили метод добавив что-то новое

        }
    }
}
