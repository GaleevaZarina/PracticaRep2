using System;

namespace task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Определение размера массива
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
      
            // Заполнение массива пользователем
            Console.WriteLine("Заполните массив любимыми целыми числами: ");
            int[] nums = new int [n];
            for (int i=0; i<n; i++)
                nums[i] = int.Parse(Console.ReadLine());
      
            // Цикл в цикле для поиска повторяющихся жлементов
            for(int i=0; i<n; i++)
            {
                int count = 0; // Счетчик повторяющихся элементов
                
                for(int j=0; j<n; j++)
                    if(nums[i] == nums[j]) // Если элемент повторяется, увеличиваем счетчик на 1
                        count += 1;
                
                // Если элемент повторился хотя бы раз
                // то выводим true и преркащаем цикл
                if(count > 1) 
                {
                    Console.WriteLine("true");
                    break;
                }
                
                // Если цикл дошел до конца массива,
                // а повторяющихся элементов нет
                // то выводим false
                if (i == nums.Length - 1 && count == 1)
                {
                    Console.WriteLine("false");
                }
                    
            }
            
        }
    }
}