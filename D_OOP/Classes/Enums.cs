using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Classes
{
      //Перечисления - конструкция, которая позволяет передавать несколько состояний. Например: светофор (зеленый, желтый, красный)
   public enum  TrafficLight //enum вместо class 
    {
        //далее через запятую перечисляем состояния
        Red,
        Yellow,
        Green
    }

    //перечисления расы из класса Character, ее лучше передавать через enum
    public enum Race
    {
        Human,
        Elf,
        Orc,
        Dwarf
    }
    
}
