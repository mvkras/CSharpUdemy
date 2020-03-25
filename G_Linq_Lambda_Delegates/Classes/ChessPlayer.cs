using System;
using System.Collections.Generic;
using System.Text;

namespace G_Linq_Lambda_Delegates.Classes
{
    class ChessPlayer
    {
        public string Country { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public int Raiting { get; set; }
        public int ID { get; set; }
        
        public override string ToString() //выводи полное квалифицированное имя класса
        {
            return $"Full Name: {Name} {Surname}, Raiting = {Raiting}, from country: {Country}, born in {BirthYear}"; //выводил бы текстовое описание
        }

        //Нужен метод, который парсит строку
        public  static ChessPlayer ParseFile(string line)
        {           
            string[] parts = line.Split(';'); //Необходимо сделать Сплит (разделение)

            return new ChessPlayer()
            {
                ID = int.Parse(parts[0]),
                Surname = parts[1].Split(',')[0].Trim(),
                Name = parts[1].Split(',')[1].Trim(), //убираем лишние пробелы
                Country = parts[3],
                Raiting = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6])
            };
        }
    }
}
