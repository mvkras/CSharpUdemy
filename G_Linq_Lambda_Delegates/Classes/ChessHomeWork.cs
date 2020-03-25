using System;
using System.Collections.Generic;
using System.Text;

namespace G_Linq_Lambda_Delegates.Classes
{
    class ChessHomeWork
    {
        public  int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public int Raiting { get; set; }
        public int BirthDay { get; set; }

        public override string ToString()
        {
            
            return $"{Name} {Surname}, {Country}, Рейтинг: {Raiting}, {BirthDay}";
        }

        //создаем метод, который парсит строку
       public static ChessHomeWork ParseInfo(string line)
        {
            string[] parts = line.Split(';');
            return new ChessHomeWork()
            {
                ID = int.Parse(parts[0]),
                Name = parts[1].Split(',')[0].Trim(),
                Surname = parts[1].Split(',')[1].Trim(),
                Country = parts[3],
                Raiting = int.Parse(parts[4]),
                BirthDay = int.Parse(parts[6])
            };
        }

    }
}
