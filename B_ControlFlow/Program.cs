using System;
using System.Diagnostics.Tracing;
using System.Net;
using System.Runtime.Serialization.Formatters;

namespace B_ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
          //HomeWork1(); //Условные выражения
            Loops(); //Циклы for, foreach
            AdvancedLoops(); //Вложенные циклы
          //WhileDoWhile(); //Циклы while Do While
            BreakContinue(); //Управление циклом break, continue
           //SwutchCase(); //Конструкция Switch Case
           //Debugging(); //Отладка основы
           //HomeWork2(); //ДЗ Числа Фибоначчи
           //Fibonacci(); //Практикуемся
           //HomeWork3();  //Вычисление среднего
           //HomeWork4(); //Вычисление факториала
           //Factorial(); //практика по факториалу
             HomeWork5(); //ДЗ 3 Попытки на аутентицикацию           
        }

//*************************************************************************************************************************************
        static void HomeWork1() //ДЗ_1 Найти максимальное из 2х чисел
        {
            Console.WriteLine("Введите 2 числа:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            string maxValue = a > b ? $"Максимальное значение: {a}" : $"Максимальное значение: {b}";
            Console.WriteLine(maxValue);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void Loops() //Циклы For, ForEach
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("В обратном порядке ");
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Вывод четных чисел в обратном порядке:");
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.WriteLine();
            //Метод foreach если не нужен доступ к индексу, а только к его значениям
            Console.WriteLine("Метод foreach");
            foreach (int value in numbers)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void AdvancedLoops() //Вложенные циклы
        {
            int[] number = { -1, 2, 3, -4, 5, 6, 1, 4, -2 };
            for (int i = 0; i < number.Length - 1; i++) //-1 так как 2й цикл будет на месте крайнего индекса и он и так будет сравнивать со свеми цифрами
            {
                for (int j = i + 1; j < number.Length; j++)
                {
                    int toI = number[i];
                    int toJ = number[j];

                    if (toI + toJ == 0)
                    {
                        Console.WriteLine($"Пара чисел: ({toI}; {toJ}) с индексами ({i}; {j})");
                    }
                }
            }
            //Триплеты 3 цикла
            for (int i = 0; i < number.Length - 2; i++) //- 2 так как 2 цикла будут перебирать все эти цифры
            {
                for (int j = i + 1; j < number.Length - 1; j++) // 1 цикл будет перебирать остальные цифры
                {
                    for (int k = j + 1; k < number.Length; k++)
                    {
                        int toI = number[i];
                        int toJ = number[j];
                        int toK = number[k];
                        if (toI + toJ + toK == 0)
                        {
                            Console.WriteLine($"Тройка чисел: ({toI}; {toJ}; {toK}) с индексами ({i}; {j}; {k})");
                        }
                    }
                }
            }

        }
//--------------------------------------------------------------------------------------------------------------------------------------       
        static void WhileDoWhile() //Циклы while Do While
        {
            int age = 0;
            while (age < 18)
            {
                Console.WriteLine("Твой возраст?");
                age = int.Parse(Console.ReadLine());
                if (age < 18)
                {
                    Console.WriteLine("Слишком молодой, попробуй еще");
                }
            }
            Console.WriteLine($"Возраст {age}");

            do  //Хотя бы раз сработает
            {
                Console.WriteLine("Твой возраст?");
                age = int.Parse(Console.ReadLine());
                if (age < 18 && age != 0)
                {
                    Console.WriteLine("Должно быть больше 18");
                }
            }
            while (age < 18);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void BreakContinue() //Управление циклом break, continue
        {
            int[] numbers = { 2, 1, 5, 6, 3, 4 }; //Будет вложенный массив. На каждой внутренней итерации, выводит то кол-ва букв, которое в массиве
            char[] letter = { 'a', 'b', 'c', 'd', 'e', 'f' }; //вывод будет таким: a, ab, abc, abcd, abcde....
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Number: {numbers[i]}");

                for (int j = 0; j < letter.Length; j++) //Внутренний цикл
                {
                    if (numbers[i] == j) //Выходим из цикла, когда i становится равно j
                        break;
                    Console.Write($"{letter[j]}");
                }
                Console.WriteLine(); //Отделяем выводы внутренних циклов
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void SwutchCase() //Конструкция Switch Case
        {
            Console.WriteLine("Сколько лет вы в браке?");
            int weddingAge = int.Parse(Console.ReadLine());
            string name = string.Empty; //Проинициализировали строку
            switch (weddingAge)
            {
                case 5:
                    name = "Деревянная свадьба!";
                    break;
                case 10:
                    name = "Янтарная свадьба!";
                    break;
                case 15:
                    name = "Стеклянная свадьба!";
                    break;
                default:
                    name = "Юбилей еще в переди!";
                    break;
            }
            Console.WriteLine($"Вы в браке уже: {weddingAge} лет - {name}");

            Console.WriteLine("Введите число месяца:");
            int numberOfSeason = int.Parse(Console.ReadLine());
            string season = string.Empty; //Проинициализировали строку

            switch (numberOfSeason)
            {
                case 1:
                case 2:
                case 12:
                    season = "Зима";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Весна";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Лето";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Осень";
                    break;
            }
            Console.WriteLine(season);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void Debugging() //Отладка основы
        {
            Console.WriteLine("Укажите длины сторон треугольника: ");
            double a = GetDouble(); //Вместо Parse и ReadLine - сделали отдельный метод и вставили в строку
            double b = GetDouble();
            double c = GetDouble();
            double p = (a + b + c) / 2;  //Предположим, что забыли скобки
            double S = p * (p - a) * (p - b) * (p - c);
            S = Math.Sqrt(S); //Квадратный корень числа
            S = Math.Round(S, 4); //Форматированный вывод, 4 знака, после запятой
            Console.WriteLine($"Площадь по формуле Герона равна: {S}");


            //Метод, который возвращает double по формуле Герона
            static double GetDouble() //Метод возвращает double с формулы Герона
            {
                return double.Parse(Console.ReadLine());
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWork2() //ДЗ Числа Фибоначчи
        {
            /*Числа фибоначчи описываются следующей последовательностью: 1, 1, 2, 3, 5, 8, 13, 21...
             *Первые два числа - единицы. Все последующие числа вычисляются как сумма двух предыдущих.
             *Задание: запросить у пользователя кол-во чисел Фибоначчи, которое он хотел бы сгенерировать (вычислить), 
             *собственно, произвести генерацию (вычисление). 
             *В процессе генерации записывать числа в массив. 
             *После генерации вывести вычисленные числа.
             */
            Console.WriteLine("Введите число Фибоначчи:");
            int n = int.Parse(Console.ReadLine());  //Введенное значение помещаем в переменную n
            int[] fibonacciNumbers = new int[n]; //То число, которое хочет ввести пользователь, помещаем n в массив

            int a0 = 0;   //Создали 2 переменные
            int a1 = 1;
            fibonacciNumbers[0] = a0;  //записали эти переменные в массив
            fibonacciNumbers[1] = a1;

            for (int i = 2; i < n; i++) //Так как первые 2 числа вычислили в ручную, начинаем со 2го индекса
            {
                int a = a0 + a1; //Вычисляем следующее число Фибоначчи (Следующее число - это сумма 2х предидущих)
                fibonacciNumbers[i] = a; //Записываем по индексу i новое число

                a0 = a1; //апдейтим a0 и a1
                a1 = a;  //последнее вычисленное число
            }
            foreach (int currentNumber in fibonacciNumbers) //проходимся по результату в цикле foreach
            {
                Console.WriteLine($"Количество чисел: {currentNumber}");
            }
            Console.ReadLine();
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void Fibonacci() //числа Фибоначчи
        {
            Console.WriteLine("Enter number:");
            int n = int.Parse(Console.ReadLine());
            int[] fibonacci = new int[n];

            int a0 = 0;
            int a1 = 1;
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            for (int i = 2; i < n; i++)
            {
                int a = a0 + a1; //новое значение 
                fibonacci[i] = a;
                a0 = a1; //меняем местами
                a1 = a;
            }
            foreach (int current in fibonacci)
            {
                Console.WriteLine($"Fibonacci numbers: {current}");
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWork3() //Д/З Вычисление среднего
        {
            /*Запросить у пользователя не более 10 целых положительных чисел.
             * Пользователь может прекратить приём чисел, введя 0.
             * После прекращения приёма целых чисел
             * (это происходит в случае если было введено 10 чисел, либо пользователь ввёл 0, чтобы не вводить все 10)
             * подсчитать среднее значение целых положительных чисел КРАТНЫХ 3м и вывести на консоль.              
             */
            int[] numbers = new int[10]; //Выделяем память в массиве под 10 элементов
            int counter = 0; //Необходим счетчик, который будет считать, сколько цифр ввел пользователь
            Console.WriteLine("Введите 10 цифр");
            while (counter < 10) //Запускаем цикл while count <10
            {
                int num = int.Parse(Console.ReadLine());
                numbers[counter] = num; //инетатор
                counter++; //После того как мы отпарсили, нужно увеличить counter

                if (num == 0) //Если пользователь вводит 0, выходим из цикла
                {
                    break;
                }
            }
            //Посчитаем средне-арифметическое чисел, кратных 3м
            int sum = 0;
            int count = 0; //чтобы посчитатть средне-арифметическое

            foreach (int n in numbers)
            {
                if (n > 0 && n % 3 == 0) //Кратно 3м
                {
                    sum += n;
                    count++;
                }
            }

            double average = (double)sum / count; //Привести sum к double и поделить на counter
            Console.WriteLine("Среднее значение " + average);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWork4() //Д/З Вычисление факториала
        {
            /* Факториалом числа является произведение этого числа
             * на все предшествующие этому числу числа (кроме 0).
             * Факториал в математике записывается через восклицательный знак.
             * Например 5! = 5*4*3*2*1 = 120. Особые случаи: 0! = 1. 1! = 1.
             * 
             * Задача: запросить у пользователя число, 
             * факториал которого необходимо вычислить и произвести вычисление.
             * Затем вывести результат вычисления. 
             * Восклицательный знак запрашивать не надо, 
             * кроме того, в C# такой операции нет. 
             * Для вычисления факториала надо производить перемножение.             
             * */
            Console.WriteLine("Введите число для факториала:");
            int n = int.Parse(Console.ReadLine());

            long factorial = 1; //Заведем факториал, по умолчанию равен 1 (факториал нуля равен 1)

            for (int i = 1; i <= n; i++)
            {
                factorial *= i; //Перемножаем текущее значение факториала на i
            }
            Console.WriteLine($"Факториал числа {n} равен: {factorial}.");
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void Factorial() //Практика по факториалу
        {
            Console.WriteLine("Введите факториал");
            int x = int.Parse(Console.ReadLine());

            long factorial = 1;
            for (int i = 1; i <= x; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
//--------------------------------------------------------------------------------------------------------------------------------------
        static void HomeWork5() //Д/З 3 Попытки на аутентификацию
        {
            /* Предположим, что логин\пароль для входа в систему: johnsilver\qwerty.
             * Запросить у пользователя логин и пароль. 
             * Дать пользователю только три попытки для ввода корректной пары логин\пароль. 
             * Если пользователь произвёл корректный ввод, вывести на консоль: 
             * "Enter the System"  и прекратить запрос логина\пароля.
             * Если пользователь ошибся трижды - вывести "The number of available tries have been exceeded" 
             * прекратить запрос пары логин\пароль.                       
             */
            string login = "mvkras";
            string password = "2501";
            int counter = 0;            
            
            while (counter < 3)
            {
                Console.WriteLine("Enter your login");
                string userLogin = Console.ReadLine();
                Console.WriteLine("Enter your password");
                string userPassword = Console.ReadLine();
                              
                if (userLogin == login && userPassword == password)
                {
                    Console.WriteLine("You enter in System!");
                    break;
                }
                counter++; //инкрементируем количество попыток               
            }
            if (counter == 3)
            {
                Console.WriteLine("Wrong login and password, you are blocked!");
            }         
        }
//--------------------------------------------------------------------------------------------------------------------------------------
      
    }
}
