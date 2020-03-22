using System;
using System.Collections.Generic;
using System.Text;

namespace G_Linq_Lambda_Delegates.Classes
{
    class Person  //создали класс для ивента(события)
    {
        public string name { get; set; }

        public event Action GoToSleep; //создадим для него событие

        public event EventHandler DoWork; //Чаще всего в событиях используется этот шаблон

        public void Sleep(DateTime now) //создадим метод для этого 
        {
            if(now.Hour <= 8)
            {
                Console.Write($"It's {now} ");
                GoToSleep?.Invoke(); //проверка на null: сокращенный вариант if(GoToSleep != null) {Вызвать событие GoToSleep();}               
            }
            else
            {
                Console.Write($"It's {now} ");
                EventArgs args = new EventArgs();
                DoWork?.Invoke(this, args); //можем передавать аргумент самого этого человека this. так же могут быть вызваны доп параменты или null
                //this - тот объект который был вызван John
            }
        }
    }
}
