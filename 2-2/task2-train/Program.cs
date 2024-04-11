using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace task2_train
{
    // Создание класса Train, описывающий поезд, рейс
    internal class Train
    {
        // Свойства класса: 
        public string nameStation { get; set; } // Название пункта назначения
        public int number { get; set; } // Номер поезда
        public string time { get; set; } // Время отправления
        
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Создание объекта класса Train
            Train train = new Train(); 
            // Создание списка типа Train для хранения объектов того же типа (поездов, рейсов)
            List<Train> listOfTrains = new List<Train>(); 
            
            // Вывод возможных команд
            bool check = true;
            while (check != false)
            {
                Console.WriteLine("\n0 - Добавить рейс\n1 - Посмотреть информацию о рейсах\n2 - Закрыть программу\n");
                int input = int.Parse(Console.ReadLine()); // Ввод команды пользователем
                switch (input)
                {
                    // Создание нового рейса
                    case 0:
                        listOfTrains = CreateTrain(listOfTrains);
                        break;
                    // Получение списка всех рейсов
                    case 1:
                        PrintInfo(listOfTrains);
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
        
        // Метод CreateTrain
        // Параметры: Список типа Train (Список всех поездов)
        // Возвращает: Обновленный список типа Train (Список всех поездов)
        // Позволяет: Создать новый рейс
        public static List<Train> CreateTrain(List<Train> listOfTrain)
        {
            Train train = new Train(); // Создание объекта типа Train
            Console.WriteLine("Введите номер поезда:"); // Ввод номера поезда  
            train.number = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите пункт назначения:"); // Ввода названия пункта назначения          
            train.nameStation = Console.ReadLine();           
            Console.WriteLine("Введите время отправления (12:00):"); // Ввод времени отправления
            
            // Проверка на корректность ввода времени отправления
            while (true)
            {
                train.time = Console.ReadLine();
                string pattern = @"[1-24]\:[0-59]";
                // Если введеное время не совпадает с паттерном, повторить попытку ввода
                if (Regex.IsMatch(train.time, pattern) != true)
                    Console.WriteLine("\nНеверный формат времени\nВведите время отправления (12:00):");
                else
                    break;
            }
                                   
            listOfTrain.Add(train); // Добавление новогго рейса в список            
            return listOfTrain;
        }

        // Метод PrintInfo
        // Параметры: Список типа Train (Список всех поездов)
        // Ничего не возвращает
        // Позволяет: Посмотреть информацию о рейсе по номеру поезда
        public static void PrintInfo(List<Train> listOfTrains)
        {
            // Проверка списка listOfTrains на наличие рейсов
            // Если количество элементов = 0,
            // то вывести "Список рейсов пуст"
            if (listOfTrains.Count > 0)
            {
                Console.WriteLine("\nВведите номер поезда: "); // Ввод номера поезда
                int input = int.Parse(Console.ReadLine());
            
                // Поиск в listOfTrains поезда с введеным номером
                bool check = false; // Переменная для проверки наличия поезда в спсике
                foreach (var item in listOfTrains)
                    // Если поезд найден, то вывести информацию о нем
                    if (item.number == input)
                    {
                        Console.Write($"\nНомер поезда: {item.number}\tПункт назначения: {item.nameStation}\tВремя отправления: {item.time}\n");
                        check = true; // поезд найден
                    }
                // Если поезд не был найден, то вывести "Поезда с таким номером нет"
                if (check == false)
                    Console.WriteLine("\nПоезда с таким номером нет");
            }
            else
                Console.WriteLine("\nСписок рейсов пуст");
            
        }
        
    }

}