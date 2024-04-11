using System;
using System.Collections.Generic;

namespace task1_worker
{
    // Класс Worker, описывающий сотрудника
    internal class Worker
    {
        // Свойства класса:
        public string name; // Имя сотрудника    
        public string surname; // Фамилия сотрудника        
        public int rate; // Ставка сотрудника 
        public int days; // Количество отработанных дней сотрудником

        // Метод GetSalary
        // Позволяет вычислить зарплату сотрудника
        // Возвращает зарплату (перемнную типа int)
        public int GetSalary()
        {
            int salary = rate * days;            
            return salary;
        }
    }    
    
    internal class Program    
    {  
        public static void Main(string[] args)        
        {            
            // Создание списка типа Worker для хранения всех сотрудников
            List<Worker> listOFWorkers = new List<Worker>();
            
            // Вывод возможных команд
            bool check = true;           
            while (check != false)            
            {                
                Console.WriteLine("\n0 - Добавить сотрудника\n1 - Посмотреть информацию о сотрудниках\n2 - Закрыть программу\n");                
                int input = int.Parse(Console.ReadLine());                
                switch (input)                
                {           
                    // Создание нового сотрудника
                    case 0:
                        listOFWorkers = CreateWorker(listOFWorkers);                        
                        break;
                    // Просмотр информации о всех сотрудниках
                    case 1:
                        PrintInfo(listOFWorkers);                        
                        break;
                    // Закрытие программы
                    case 2:
                        Console.WriteLine("\nЗавершение программы...");                        
                        check = false;                        
                        break;                    
                    default:
                        Console.WriteLine("\nТакой команды нет");                        
                        break;                
                }            
            }        
        }

        // Метод CreateWorker
        // Параметры: Список типа Worker (Список всех сотрудников)
        // Возвращает Обновленный список типа Worker (список сотрудников)
        // Позволяет создать нового сотрудника
        public static List<Worker> CreateWorker(List<Worker> listOfWorkers)
        {
            Worker worker = new Worker(); // Создание объекта класса Worker
            Console.WriteLine("Введите имя сотрдуника:"); // Ввод имени нового сотрудника            
            worker.name = Console.ReadLine();            
            Console.WriteLine("Введите фамилию сотрдуника:"); // Ввод фамилии нового сотрудника              
            worker.surname = Console.ReadLine();            
            Console.WriteLine("Введите ставку сотрдуника:"); // Ввод ставки нового сотрудника              
            worker.rate = int.Parse(Console.ReadLine());            
            Console.WriteLine("Введите количество отработанных дней сотрдуника:"); // Ввод количества отработанных дней сотрудником             
            worker.days = int.Parse(Console.ReadLine());                        
            listOfWorkers.Add(worker); // Добавление нового сотрудника в список listOfWorkers         
            return listOfWorkers;
        }

        // Метод PrintInfo
        // Параметры: Список типа Worker (Список всех сотрудников)
        // Ничего не возвращает
        // Позволяет просмотреть информацию о всех сотрудниках
        public static void PrintInfo(List<Worker> listOfWorkers)
        {
            // Проверка на наличие сотрудников в списке
            // Если список пуст,
            // то вывести "Список сотрудников пуст"
            if (listOfWorkers.Count > 0)
                foreach (var item in listOfWorkers) // Перебор списка listOfWorkers и вывод информации о каждом сотруднике
                    Console.Write($"\nИмя: {item.name}\tФамилия: {item.surname}\tСтавка: {item.rate}\tДни: {item.days}\tЗарплата: {item.GetSalary()}");
            else
                Console.WriteLine("\nСписок сотрудников пуст");
        }
    }
    
}