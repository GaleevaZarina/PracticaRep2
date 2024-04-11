using System;
using System.Collections.Generic;

namespace RomanNumbers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Ввод пользователем числа римскими цифрмаи
            Console.WriteLine("Введите число римским цифрами (I, V, X, L, C, D и M): ");
            string line = Console.ReadLine();
            
            int translate = 0; // Переменная для хранения переведенного числа
            for (int i = 0; i < line.Length; i++)
            {
                // Если i - последний символ строки, то прибавить его к translate
                if (i == line.Length - 1)
                    translate += FindNum(line[i].ToString());
                // Иначе
                else
                {
                    // Проверка на XL XC CD CM
                    // Если текущее число меньше следующего, то из следующего вычесть текущее и записать в translate
                    if (FindNum(line[i].ToString()) < FindNum(line[i + 1].ToString()))
                    {
                        translate += FindNum(line[i+1].ToString()) - FindNum(line[i].ToString());
                        i++; // Перевод цикла на следующую итерацию, т.к. следующее число уже посчитали
                    }
                    // Иначе просто складывать все числа и записывать в translate
                    else
                        translate += FindNum(line[i].ToString());
                }
                
            }
            
            Console.WriteLine($"{line} = {translate}"); // Вывод полученного переведенного числаы
            
        }
        
        // Метод FindNum
        // Параметры: символ, значение которого будем искать в словаре
        // Возвращает: число - значение полученного символа
        // Позволяет узнать какому числу равен полученный из строки символ
        public static int FindNum(string symbol)
        {
            // Словарь со значениями римских цифр
            Dictionary<string, int> numbers = new Dictionary<string, int>()
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 }
            };

            int a = 0; 

            // Перебор словаря и поиск нужного значения по ключу
            foreach (var item in numbers)
                if (symbol == item.Key)
                {
                    a = item.Value; // присвоение переменной найденного значения
                    break;
                }
            
            return a;
        }
        
    }
}