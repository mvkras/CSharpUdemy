using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace F_Stream_FileStream
{
    class Program  //Работа с файлами и потоками
    {
        static void Main(string[] args)
        {
            FStream(); //запускаем файл стрим
            FileStream(); //практикуемся
            AutoStream();
            StreamByShvanov(); //Потоки от Вадима Шванова C#
            WriteFile();
        }

        static void FStream() //РАбота с файлами
        {
            Stream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite); //главный класс Stream для работы с файлами и потоками создали экземпляр FileStream
                                                                                                 //Прописываем путь к файлу. FileMode - режим работы с файлом, потоком, FileAccess - доступ к файлу
            try
            {
                //попытаемся записать строчку в файл
                string str = "Hello World";
                //  if(fs.CanWrite) //Могут быть потоки, которые не поддерживают запись стримов(потоков)
                //сконвертируем нашу строку в поток байтов, так как метод write имеет поток байтов
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);
                fs.Write(strInBytes, 0, strInBytes.Length); //принимает буфер поток байтовб передаем с какого байта записывать и сколько записывать 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение "+ex.Message);
            }
            finally
            {
                fs.Close(); //если есть Close и Dispose, лучше всегда вызывать Close() так как он делает что-то еще
            }         
            Console.WriteLine("Теперь читаем наш файл");
            Console.WriteLine();
            //Создадим поток для чтения, используем конструкция using
            using (Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                //будем читать по 14 байтов, объявим буфер(это некий поток байтов)
                byte[] temp = new byte[readingStream.Length]; //длина потока
                //Заведем 2 переменные
                int ReadinBytes = (int)readingStream.Length; //количество байтов, которое осталось прочитать

                int bytesRead = 0;
                //будем читать файл, пока в нем не закончатся байты
                while (ReadinBytes > 0) //пока длина больше 0 будет читать
                {
                    int n = readingStream.Read(temp, bytesRead, ReadinBytes); //будем запоминать количество вычитанных байтов
                    if (n == 0) //значит дочитали файл точно до конца
                    {
                        break; //выходим из цикла
                    }
                    //будем делать смещение кол-во прочитанных байтов изначально 0. после чтения должны инкрементировать его на n
                    bytesRead += n;
                    ReadinBytes -= n; //количество байтов на прочтение мы должны уменьшить                  
                }
                string str = Encoding.ASCII.GetString(temp, 0, temp.Length);
                Console.WriteLine(str);
            }

        }

        static void FileStream()
        {
            Stream stream = new FileStream("testingFiles.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            try
            {
                string str = "Hi, my name is Andrew and i love Dangeous and Dragons! I'm glad to see my friends every time and plays with them.";
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);
                stream.Write(strInBytes, 0, strInBytes.Length);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Обработка исплючения "+ ex);
            }
            finally
            {
                stream.Close();
            }
            //почитаем
            Console.WriteLine("Записанное сообщение:");
            using (Stream readingStream = new FileStream("testingFiles.txt", FileMode.Open, FileAccess.Read))
            {
                //создаем буфер для чтения байтов
                byte[] temp = new byte[readingStream.Length]; //длина потока

                int NotYetReadingBytes = (int)readingStream.Length; //количество байтов, которое осталось прочитать
                int AlreadyReadedBytes = 0; //то количество байтов, которое было прочитано
                while(NotYetReadingBytes > 0) //будем читать файл, пока он больше нуля
                {
                    int n = readingStream.Read(temp, AlreadyReadedBytes, NotYetReadingBytes);  //будем запоминать количество вычитеннах байтов
                    if (n == 0)
                    {
                        break;
                    }
                    AlreadyReadedBytes += n;
                    NotYetReadingBytes -= n;                   
                }
                string str = Encoding.ASCII.GetString(temp, 0, temp.Length); //перевод строки байтов в строку
                Console.WriteLine(str);
            }
        }
        
        static void AutoStream() //шорткаты, то что написали ранее есть в уже прописанных методах
        {
            string[] allLines = File.ReadAllLines("testingFiles.txt"); //прочитать все линии
            foreach(string lines in allLines) 
            {
                Console.WriteLine(lines); //вся инфа будет в 1 линию
            }

            //с разметкой, отступами, абзатцами
            string readAllText = File.ReadAllText("testingFiles.txt");
            Console.WriteLine(readAllText);

            //Прочитать не в массив, а в IEnumerable стринга, либо так же можно использовать List
            IEnumerable<string> enumerable = File.ReadAllLines("testingFiles.txt");
            foreach (string enumText in enumerable)
            {
                if(enumText == "Andrew!")
                {
                    break;                   
                }
                Console.WriteLine(enumText); //вся инфа будет в 1 линию
            }
            
        }

        //Шванов Вадим про потоки и чтение файлов
        static void StreamByShvanov()
        {                      //StreamWriter - поток для записи данных
            using (var sw = new StreamWriter("ShwanovVadimStream.txt", true, Encoding.UTF8))  //и спользованием using Позволяет создать объект с использованием только этого блока кода
            {        //При выходе за скобки, этот объект будет уничтожен методом Dispose()
                     //Объявляем объект потока в скобках using
                sw.Write("Вадим Шванов - самый топовый C# разработчик в ру сигменте"); //передаем данные, которые будут записаны
                sw.WriteLine("WriteLine - переход на новую строчку");
                sw.WriteLine("Learning Stream by using Stream");
            }
            /* Сперва нужно открыть файл(создать поток) 
             * Что-то оттуда прочитать / записать
             * Корректно закрыть
             * 
             * По умолчанию, файл перезаписывается, чтобы дописывать данные в файл, нужно передать bool параметр true
             */

            //Теперь почитаем наш файл
            using (var sr = new StreamReader("ShwanovVadimStream.txt"))
            {
                //чтобы прочитать данные, их нужно записать в переменную
                string text = sr.ReadToEnd();
                Console.WriteLine(text);
            }
            

        }

        static void WriteFile()
        {
            Stream stream = new FileStream("newFileForStream.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            try
            {
                string str = "Hello, my name is mvkras!";
                byte[] strInBytes = Encoding.UTF8.GetBytes(str);
                stream.Write(strInBytes, 0, strInBytes.Length);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stream.Close();
            }
            //Читаем файл
            using (Stream readingStream = new FileStream("newFileForStream.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] temp = new byte[readingStream.Length];

                int NotYetReaded = (int)readingStream.Length;
                int AlreadyReaded = 0;
                while(NotYetReaded > 0)
                {
                    int n = readingStream.Read(temp, AlreadyReaded, NotYetReaded);  //будем запоминать количество вычитеннах байтов
                    if (n == 0)
                    {
                        break;
                    }
                    AlreadyReaded += n;
                    NotYetReaded -= n;
                }
                string str = Encoding.ASCII.GetString(temp, 0, temp.Length); //перевод строки байтов в строку
                Console.WriteLine(str);
            }
        }

    }
}
