using System;
using System.Collections.Generic;
using System.Text;

namespace H_HomeWorks.ComplexNumbers
{
    class Events //события когда мы работали в WindowsForms с формочками, кнопками При нажатии на кнопку - происходило какое-то событие
    {
        public  delegate void MyDelegate();  //создадим делегат

        public event MyDelegate Event; //создаем собитие на основе делегата

        public event Action EventAction; //Либо можно с помощью шаблона Action

        public event EventHandler EventHandler; //Чаще всего в событиях используется этот шаблон для передачи каких-либо параметров
    }
}
