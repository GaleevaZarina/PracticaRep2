using System;

namespace task3_numbers
{
    // Класс Numbers для хранения двух чисел (a и b)
    internal class Numbers
    {
        public static int a { get; set; } // Число a
        public static int b { get; set; } // Число b

        // Метод CreateNumbers
        // Позволяет пользователю задать числам a и b значения
        public void CreateNumbers()
        {
            Console.WriteLine("Введите число a: "); // Ввод числа a            
            a = int.Parse(Console.ReadLine());                        
            Console.WriteLine("Введите число b: "); // Ввод числа b          
            b = int.Parse(Console.ReadLine());
        }
        
        // Метод PrintNumbers
        // Позволяет посмотреть текущие значения чисел a и b
        public void PrintNumbers()
        {
            Console.WriteLine($"\nЧисло a = {a}\nЧисло b = {b}"); // Вывод значений чисел 
        }  
        
        // Метод EditNumbers
        // Позволяет пользователю изменить значения числа a или b
        public void EditNumbers()        
        {            
            // Определение числа, значение которого пользователь хочет изменить
            Console.WriteLine("\nКакое число хотите изменить?: ");            
            Console.Write("0 - Число a\n1 - Число b\n");    
            
            int input = int.Parse(Console.ReadLine());            
            switch (input)            
            {             
                // Изменение числа a
                case 0:
                    Console.Write("\na = ");                    
                    a = int.Parse(Console.ReadLine());                    
                    break;
                // Изменение числа b
                case 1:
                    Console.Write("\nb = ");                    
                    b = int.Parse(Console.ReadLine());                    
                    break;
                default:
                    Console.WriteLine("\nТакой команды нет");
                    break;
            }        
        }

        // Метод Sum
        // Позволяет вычислить сумму числа a и b
        public void Sum()
        {
            Console.WriteLine($"\n{a} + {b} = {a + b}"); // Вывод суммы чисел
        }

        // Метод HighestNumber
        // Позволяет узнать какое число больше
        public void HighestNumber()
        {
            // Вывод результата
            if (a > b)                
                Console.WriteLine($"\n{a} > {b}");            
            else if(a < b)               
                Console.WriteLine($"\n{a} < {b}");
            else
                Console.WriteLine($"\n{a} = {b}");
        }
        
    }        
    
    internal class Program    
    {        
        public static void Main(string[] args)        
        {            
            Numbers numbers = new Numbers(); // Создание объекта класса Numbers
            numbers.CreateNumbers(); // Ввод значений числам a и b
            
            // Вывод возможных команд
            bool check = true;            
            while (check != false)            
            {                
                Console.WriteLine("\nЧтобы изменить данные выберите соответствующую команду: ");                
                Console.Write("0 - Изменить значения чисел\n" +                              
                              "1 - Посмотреть значения чисел\n" +                              
                              "2 - Вычислить сумму чисел\n" +                              
                              "3 - Найти наибольшее значение\n" +                              
                              "4 - Закрыть программу\n");                
                int input = int.Parse(Console.ReadLine());                
                switch (input)                
                {           
                    // Изменение чисел
                    case 0:
                        numbers.EditNumbers();                        
                        break;   
                    // Просмотр текущего значения
                    case 1:
                        numbers.PrintNumbers();                        
                        break;  
                    // Вычисление суммы чисел
                    case 2:
                        numbers.Sum();                        
                        break;  
                    // Узнать, какое число больше
                    case 3:
                        numbers.HighestNumber();                        
                        break;   
                    // Закрытие программы
                    case 4:
                        Console.WriteLine("\nЗавершение программы...");                        
                        check = false;                        
                        break;                    
                    default:
                        Console.WriteLine("\nТакой команды нет");                        
                        break;                
                }            
            }        
        }
                    
    }
    
}