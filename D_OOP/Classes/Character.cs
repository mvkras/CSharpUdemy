using D_OOP.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    class Character  //Заполняем данные класса
    {
        int health = 100; //поле здоровье
        //Объявляем свойства для чтения полей {get; set}. Свойства пишутся с public. Свойство - это оболочка над полем     
        string race;
        public  int armor { get; private set; } //тоже самое, что и ниже Get Set
        public string GetRace()
        {
            return race;
        }
        private void SetRace(string race)
        {
            this.race = race;
        }
        public int GetHealth() //Свойство/метод для чтения поля здоровье, чтобы его не могли изменить
        {
            return health;
        }
        private void SetHealth(int value) //Записывать значение не на прямую. Для защиты
        {
            health = value;
        }
        //-----------------------------------------------------------------------------------------------------------------
        //конструкторы
        public Character(string race) //Конструктор, который при создании экземпляра класса будет требовать задавать расу
        {
            this.race = race;
            this.armor = 30;
        }
        public Character(string race, int armor) //Конструктор, который при создании экземпляра класса будет требовать задавать расу
        {
            this.race = race;
            this.armor = armor;
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
