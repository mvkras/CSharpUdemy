using System;
using System.Collections.Generic;
using System.Text;

namespace G_Linq_Lambda_Delegates.Interfaces
{
    class BMW : ICar
    {
        public int Move(int distance) //реализует этот интерфейс
        {
            return distance / 60; //60км/ч скорость тогда мы узначем время путь / скорость = время  
        }
    }
}
