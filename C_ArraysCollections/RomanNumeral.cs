using System;
using System.Collections.Generic;
using System.Text;

namespace C_ArraysCollections
{
    class RomanNumeral
    {
        private static Dictionary<char, int> map = new Dictionary<char, int>() //создали словарь
        {
            { 'I', 1 }, //ключ - значение
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };
    
        public static int Parse(string roman) //для реализации парсинга, нужно реализовать 2 правила (сложение и вычитание)
        {
            //в цикле нужно пройтись по такой строчке и в каждом цикле искать соответствие в map и между ними произвести сложение
            //либо вычитание IV = 5 - 1 = 4
            //XIV (14) = 10 - 1 + 5 = 14
            //необходимо реализовать проверку (берем 2 символа и смотрим, является ли след символ больше предидущего, если нет +, иначе -)
            int result = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                //этот метод будет производить вычитание
                if(i+1 < roman.Length && isSubtractive(roman[i], roman[i+1])) //чтобы не выйти за границы нужно проверить их
                {
                    ////либо так
                    //char letter = roman[i];
                    //result -= map[letter];
                    result -= map[roman[i]]; //использовали вложенность
                }
                else
                {
                    result += map[roman[i]]; //иначе прибавляем
                }
            }
            return result;

        }

        private static bool isSubtractive(char c1, char c2)
        {
            return map[c1] < map[c2]; //в качестве ключа используем букву, значение - цифра будет true
        }
    }
}
