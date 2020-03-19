using System;

namespace E_Exceptions
{
    class Program   //Обработка исключений
    {
        static void Main(string[] args)
        {
            ParseNumber();
        }

        //Попробуем у пользователя запросить какой-нибудь ввод (ввод целого числа) и попытаемся его отпарсить
         
        static void ParseNumber()
        {
            Console.WriteLine("Введите число:");
            string userValue = Console.ReadLine();
            int number = 0;
            try
            {
                number = int.Parse(userValue);  /*Если навестись на на Pase, ReadLine и другие методы, 
                                                  мы можем увидеть какие исключения могут выброситься*/
                
            }
            catch (FormatException ex) //тип исключения, можно написать 1 Exception который является главным, он ловит все исключения                                      
            {                          //Либо обрабатывать каждый по отдельности
                Console.WriteLine("Исключение "+ex.Message);
            }
            Console.WriteLine($"Пользователь ввел: {number}");

        }
    }
}
