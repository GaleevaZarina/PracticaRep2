using System;

namespace task3_calculation
{
    // Создание класса Calculation
    class Calculation
    {
        // Свойства класса:
        public static string calculationLine = "Miracle all around"; // Значение по умолчанию

        // Метод SetCalculation
        // Позволяет изменить значение свойства
        public static void SetCalculation()
        {
            Console.WriteLine("\nВведите новое значение строки: ");
            calculationLine = Console.ReadLine();
        }

        // Метод SetLastSymbolCalculationLine
        // Позволяет прибавить символ в конец строки 
        public static void SetLastSymbolCalculationLine()
        {
            // Проверка на корректность ввода
            bool check = true;
            while (check != false)
            {
                Console.WriteLine("\nВведите символ: ");
                string newSymbol = Console.ReadLine();
                // Если введено больше одного символа, повторить ввод
                if (newSymbol.Length > 1)
                    Console.WriteLine("\nВведите только один символ");
                else
                {
                    calculationLine += newSymbol;
                    check = false;
                }
            }
        }

        // Метод SetLastSymbolCalculationLine
        // Позволяет посмотреть значение свойства
        public static void GetCalculationLine()
        {
            Console.WriteLine(calculationLine); // Вывод строки в консоль
        }

        // Метод GetLastSymbol
        // Позволяет посмотреть последний символ строки
        // Возвращает последний символ строки
        public static string GetLastSymbol()
        {
            Console.WriteLine("\nПоследний символ строки: ");
            string lastSymbol = calculationLine[calculationLine.Length - 1].ToString();
            return lastSymbol;
        }

        // Метод DeleteLastSymbol
        // Позволяет удалить последний символ в строке
        public static void DeleteLastSymbol()
        {
            calculationLine = calculationLine.Remove(calculationLine.Length - 1);
            Console.WriteLine("\nПоследний символ удален");
        }


    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Вывод возможных команд
            bool check = true;
            while (check != false)
            {
                Console.WriteLine("\n0 - Изменить значение строки" +
                                  "\n1 - Добавить символ в конец строки" +
                                  "\n2 - Посмотреть значение строки" +
                                  "\n3 - Узнать последний символ строки" +
                                  "\n4 - Удалить последний символ строки" +
                                  "\n5 - Закрыть программу\n");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    // Изменение значения строки
                    case 0:
                        Calculation.SetCalculation();
                        break;
                    // Добавление символа в конец строки
                    case 1:
                        Calculation.SetLastSymbolCalculationLine();
                        break;
                    // Просмотр значения строки
                    case 2:
                        Calculation.GetCalculationLine();
                        break;
                    // Просмотр последнего символа строки
                    case 3:
                        Console.WriteLine(Calculation.GetLastSymbol());
                        break;
                    case 4:
                        // Удаление последнего символа строки
                        Calculation.DeleteLastSymbol();
                        break;
                    case 5:
                        // Закрытие программы
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