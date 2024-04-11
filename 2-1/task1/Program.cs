using System;

namespace task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Получение двух строк
            // строка J - драгоценности
            // строка S - камни
            Console.WriteLine("Введите строку J - драгоценности: ");
            string J = Console.ReadLine();
            Console.WriteLine("Введите строку S - камни: ");
            string S = Console.ReadLine();

            int count = 0; // счетчик камней, которые являются драгоценностями
            
            for (int i=0; i<J.Length; i++) // перебор всех драгоценностей    
            {
                for (int j=0; j<S.Length; j++) // перебор всех камней
                {
                    if(J[i] == S[j]) // если камень являются драгоценностью, то увеличивае счетчик
                    {
                        count += 1;  
                    }
                }
            }

            Console.WriteLine($"Количество Драгоценностей в строке S = {count}");
    
            
        }
    }
}