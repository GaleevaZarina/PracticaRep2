using System;

namespace task4_counter
{
    // Класс Counter, реализующий счетчик
    class Counter
    {
        private int x = 5; // Значение перемнной по умолчанию

        // Задаем свойства
        public int X 
        {
            set { x = value; }
            get { return x; }
        }

        // Метод increase
        // Увеличивает счетчик на 1
        public void increase()
        {
            x += 1;
        }
        
        // Метод decrease
        // Уменьшает счетчик на 1
        public void decrease()
        {
            x -= 1;
        }

    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Counter counter = new Counter(); // Создание объекта класса Counter
            
            // Вывод возможных команд
            bool check = true;
            while (check != false)
            {
                Console.WriteLine("\n0 - Увеличить число\n1 - Уменьшить число\n2 - Посмотреть текущее значение\n3 - Изменить значение\n4- Закрыть программу\n");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    // Увеличение счетчика 
                    case 0:
                        counter.increase();
                        Console.WriteLine("\nУвеличиваем число:\tx = " + counter.X);
                        break;
                    // Уменьшение счетчика
                    case 1:
                        counter.decrease();
                        Console.WriteLine("\nУменьшаем число:\tx = " + counter.X);
                        break;
                    // Просмотр текущего значения
                    case 2:
                        Console.WriteLine("\nТекущее значение:\tx = " + counter.X);
                        break;
                    // Изменения значения счетчика
                    case 3:
                        Console.WriteLine("\nВведите новое значение: ");
                        counter.X = int.Parse(Console.ReadLine());
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