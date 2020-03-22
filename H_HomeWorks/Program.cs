using H_HomeWorks.ComplexNumbers;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace H_HomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Д/З_1 "Комплексные числа"
            Complex c1 = new Complex(1, 3);
            Complex c2 = new Complex(3, 2);
            Complex result = c1.Plus(c2);
            Console.WriteLine($"Натуральные числа: {result.NaturalsNumbers} Мнимые: {result.ImagineNumbers}");
            result = c1.Minus(c2);
            Console.WriteLine($"Натуральные числа: {result.NaturalsNumbers} Мнимые: {result.ImagineNumbers}");

            //ДЗ_2 "Угадай число от 0 до 100"
        //    GuessTheNumber();  //Игрок угадывает число
            ComputerGuessNumber(); //Компьютер угадывает число игрока

        }
        //********************************************************************************************************************************************

        //Д/З 2 "Угадай число"
    /* Разработать игру "угадай число".
       Смысл игры.
       Один из игроков загадывает число от 0 до 100 (по умолчанию), 
       а второй пытается угадать за лимитированное число попыток (5 по умолчанию).

       Когда второй игрок делает предположение о загаданном числе, 
       первый игрок сообщает о том угадано ли число, меньше ли оно загаданного, или больше. 
       Если угадано - игра завершена. 
       Если меньше или больше загаданного, то второй игрок сужает область поиска и продолжает пытаться угадывать. 
       Так происходит до тех пор пока либо число не угадано, либо исчерпано кол-во попыток.

       Загадывать может как человек, так и машина. 
       Соответственно и угадывать может как человек, так и машина. 
       Это значит, что надо реализовать два режима игры: 
       когда загадывает машина и когда загадывает человек.

       Если загадывает человек, а угадывает машина, то нужно сделать так, 
       чтобы машина пыталсь угадать число, используя алгоритм бинарного поиска.

       Пример бинарного поиска загаданного числа:
       загадано число 18, при условии, что число загадывалось в диапазоне от 0 до 100. Игрок каждый раз берёт середину, 
       т.е. на первой попытке предполагает число 50. 
       Первый игрок говорит, что загаданное число меньше. Значит число лежит между 0 и 50. 
       Тогда второй игрок снова делит диапазон на 2 и предполагает 25. 
       Первый игрок говорит, что загаднное число меньше. 
       Значит число между 0 и 25. 
       Тогда второй игрок снова делит диапазон на 2 и предполагает 12 (дробную часть мы просто срезаем). 
       Первый игрок говорит, что загаданное число больше. Значит число лежит в диапазоне между 12 и 25. 
       Второй игрок делить диапазон на два и предполагает 18. Первый игрок говорит, что число угадано. Игра завершена.

       На каждой попытке , благодаря так стратегии, диапазон поиска сужается в два раза. 
       Это и есть суть бинарного поиска. В конце игры выводится информация о том достигнута ли победа или нет. 
       Конечно же, будет необходимо реализовать диалог между игроками. */
       static void GuessTheNumber() //угадай число
        {
            Console.WriteLine();
            //Создали оператор случайных чисел
            Random rand = new Random();  
            int computerNumber = rand.Next(101);
            //Инициализируем переменную count
            int count = 1; //понадобится для счета шагов или попыток пользователя
            Console.WriteLine("Компьютер загадал число от 0 до 100, попробуйте его отгадать");
            Console.WriteLine("Введите первое число от 0 до 100:");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out int userNumber);
            // int userNumber = int.Parse(Console.ReadLine());         
            //Построим алгоритм для просчета:
            if (result)
            {
                while (count <= 5) //количество попыток
                {
                    if (userNumber > computerNumber)
                    {
                        Console.WriteLine($"Перебор! Загаданное число меньше вашего! Попытка: {count}:");
                        count++;
                    }
                    else if (userNumber < computerNumber)
                    {
                        Console.WriteLine($"Мало! Ваше число меньше загаданного! Попытка: {count}:");
                        count++;
                    }

                    else if (userNumber == computerNumber) //если задуманное число равно числу пользователя
                    {
                        Console.WriteLine($"Верно! Компьютер загадал число: {userNumber}");
                    }
                    else
                    {
                        count++; //Количество попыток становится меньше
                    }
                    if (count == 6)
                    {
                        Console.WriteLine("Вы не отгадали данное число за 5 попыток!");
                        Console.WriteLine($"Нет, это не то число! Число было: {computerNumber} ");
                        break;
                    }

                    userNumber = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
            }
            Console.WriteLine();

        }

        static void ComputerGuessNumber() //Компьютер угадывает число игрока
        {
            int counter = 1;
            Random rand = new Random();
            int  computerNumber = rand.Next(101);
            Console.WriteLine("Загадайте число для компьютера от 0 до 100:");
            string str = Console.ReadLine();
            bool result = int.TryParse(str, out int finalNumber);
            if (result)
            {
                while(counter < 6)
                {
                    if(computerNumber > finalNumber)
                    {
                        computerNumber = rand.Next(101)/2;
                        Console.WriteLine($"Значение компьютера {computerNumber} больше моего. Попытка: {counter}");
                        counter++;
                    }
                  else if (computerNumber < finalNumber)
                    {
                        computerNumber = rand.Next(51) / 2;
                        Console.WriteLine($"Значение компьютера {computerNumber} меньше моего. Попытка: {counter}");
                        counter++;
                    }
                    else if (computerNumber == finalNumber)
                    {
                        computerNumber = rand.Next(25) / 2;
                        Console.WriteLine($"Верно! это число: {finalNumber}");                       
                    }
                    else
                    {
                        counter++; //Количество попыток становится меньше
                    }
                    if (counter == 6)
                    {
                        Console.WriteLine("Вы не отгадали данное число за 5 попыток!");
                        Console.WriteLine($"Нет, это не то число! Число было: {finalNumber} ");
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Это не число! Укажите число и попробуйте снова");
            }

        }

//-----------------------------------------------------------------------------------------------------------------------------------------

    }


}
