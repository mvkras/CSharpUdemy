using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
   class Character  //Заполняем данные класса
    {
      int health = 100; //поле здоровье
        //Объявляем свойства для чтения полей {get; set}. Свойства пишутся с public. Свойство - это оболочка над полем     
        public int GetHealth() //Свойство/метод для чтения поля здоровье, чтобы его не могли изменить
        {
            return health;
        }
        private void SetHealth(int value) //Записывать значение не на прямую. Для защиты
        {
            health = value;
        }
        public void Hit(int damage)//поведение класса задается методами. Void - пустота
        {
            if(damage > GetHealth())//Чтобы здоровье не было отрицательным
            {
               damage = GetHealth(); //Если в damage большее значение, чем здоровья у игрока, то эта разница передается в damage, а health = 0;
            }
           var health = GetHealth() - damage; //Уменьшает величину здоровья в зависимости от урона
            SetHealth(health);
        }

    }
}
