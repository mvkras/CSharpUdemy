using D_OOP.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    class Character  //Заполняем данные класса
    {
        string name;
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

            //если мы хотим вызывать эту операцию, если персонаж уже мертв, то можем проверить
            if(health == 0)
            {
                throw new InvalidOperationException("Персонаж уже сдох, хватит его бить! Изверг!"); //недействительная операция отмена действия
            }   //InvalidOperationException - вызывается тогда, когда вызвали метод в котором он не должен вызываться (при определенном условии)
        }

        //Конструктор для выбрасывания исключений
        public Character(string name, string race, int armor )
        {
            //выбросим исключение, если не хотим чтобы пользователь ввел null путем проверки 
            if (name == null)
            {
                //выбрасываем исключение, создавая инстанцию какого-либо типа исключения
                throw new ArgumentNullException("Произошла ошибка, не должно быть значение null");
            }
                //так же armor не должен быть меньше 0 и не должен быть больше 100
                if (armor > 0 || armor > 100)
                {
                    throw new ArgumentException("Броня не должна быть меньше 0 и больше 100");
                }
            //Таким образом, защитили класс Character от нелепых значений
            this.name = name;
            this.race = race;
            this.armor = armor;
            
        }
    }
}
