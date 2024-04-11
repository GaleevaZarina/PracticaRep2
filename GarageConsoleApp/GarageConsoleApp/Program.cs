using System;
using System.Globalization;

namespace GarageConsoleApp;

/// <summary>
/// Класс Program
/// здесь описываем логику приложения
/// вызываем нужные методы пишем обработчики и тд
/// </summary>
public class Program 
{
    public static void Main(string[] args)
    {

        // Вывод возможных команд
        bool check = true;
        while (check != false)
        {
            Console.WriteLine("ВЫБОР КОМАНДЫ");
            Console.WriteLine("0 - Просмотр типов машин\n" +
                              "1 - Добавление типа машины\n" +
                              "2 - Просмотр информации о водителях\n" +
                              "3 - Добавление нового водителя\n" + 
                              "4 - Просмотр списка категорий прав\n" +
                              "5 - Добавление новой категории прав\n" +
                              "6 - Просмотр категорий прав водителя по ID\n" +
                              "7 - Присвоение водителю категории прав\n" + 
                              "8 - Просмотр списка машин\n" +
                              "9 - Добавление новой машины в список\n" + 
                              "10 - Просмотр всех маршрутов\n" +
                              "11 - Добавление нового маршрута\n" +
                              "12 - Просмотр информации о всех рейсах \n" +
                              "13 - Добавление нового рейса\n" +
                              "14 - Закрыть программу\n");

            Console.WriteLine();
            int input = int.Parse(Console.ReadLine());

            // С помощью switch case выолняем команды введеные пользователем
            switch (input)
            {
                // Просмотр списка типов машин с помощью GetTypeCarQuery
                case 0:
                    Console.WriteLine("\nСписок типов машин: ");
                    DatabaseRequests.GetTypeCarQuery();
                    break;
                //Добавление типа машины с помощью AddTypeCarQuery(
                case 1:
                    Console.WriteLine("\nВведите тип машины: ");
                    string newType = Console.ReadLine();
                    DatabaseRequests.AddTypeCarQuery(newType);
                    Console.WriteLine("\nДобавление прошло успешно");
                    break;
                //Просмотр списка водителей с помощью GetDriverQuery
                case 2:
                    Console.WriteLine("\nСписок водителей");
                    DatabaseRequests.GetDriverQuery();
                    break;
                //Добавление нового водителя с помощью AddDriverQuery
                case 3:
                    Console.WriteLine("\nВведите имя водителя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("\nВведите фамилию водителя: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("\nВведите дату рождения водителя (гггг/мм/дд - 0001/01/01): ");
                    string birthday = Console.ReadLine();
                    CheckingBirthday(birthday);
                    DatabaseRequests.AddDriverQuery(name, surname, DateTime.Parse(birthday));
                    Console.WriteLine("\nДобавление прошло успешно");
                    break;
                // Просмотр списка категорий прав с помощью GetRightsCategoryQuery
                case 4:
                    Console.WriteLine("\nСписок категорий прав: ");
                    DatabaseRequests.GetRightsCategoryQuery();
                    break;
                // Добавление новой категории прав с помощью AddRightsCategoryQuery
                case 5:
                    Console.WriteLine("\nВведите название новой категории прав: ");
                    string newCategory = Console.ReadLine();
                    DatabaseRequests.AddRightsCategoryQuery(newCategory);
                    break;
                //Просмотр категорий прав водителей с помощью GetDriverRightsCategoryQuery
                case 6:
                    Console.WriteLine("\nВведите ID водителя, права которого хотите узнать:");
                    int idDriver = int.Parse(Console.ReadLine());
                    DatabaseRequests.GetDriverRightsCategoryQuery(idDriver);
                    break;
                //Добавление категории прав водителю с помощью AddDriverRightsCategoryQuery
                case 7:
                    Console.WriteLine("\nВведите ID водителя, которому хотите присвоить права: ");
                    idDriver = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nВведите id категории прав:");
                    int idCategory = int.Parse(Console.ReadLine());
                    DatabaseRequests.AddDriverRightsCategoryQuery(idDriver, idCategory);
                    Console.WriteLine("\nДобавление прошло успешно");
                    break;
                //Просмотр машин с помощью GetCarQuery
                case 8:
                    Console.WriteLine("\nСписок всех машин:");
                    DatabaseRequests.GetCarQuery();
                    break;
                //Добавление новой машины с помощью AddNewCar
                case 9:
                    Console.WriteLine("\nВведите название новой машины: ");
                    string nameNewCar = Console.ReadLine();
                    Console.WriteLine("\nВведите номер новой машины: ");
                    string stateNumber = Console.ReadLine();
                    Console.WriteLine("\nВведите вместимость новой машины: ");
                    int numberPessenger = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nВведите id типа новой машины: ");
                    int idTypeCar = int.Parse(Console.ReadLine());
                    DatabaseRequests.AddNewCar(nameNewCar, stateNumber, numberPessenger, idTypeCar);
                    Console.WriteLine("\nДобавление прошло успешно");
                    break;
                //Просмотр маршрутов с помощью GetItineraryQuery
                case 10:
                    Console.WriteLine("\nСписок всех маршрутов: ");
                    DatabaseRequests.GetItineraryQuery();
                    break;
                //Добавление нового маршрута с помощью AddNewItinerary
                case 11:
                    Console.WriteLine("\nВведите название нового маршрута:");
                    string nameItinerary = Console.ReadLine();
                    DatabaseRequests.AddNewItinerary(nameItinerary);
                    Console.WriteLine("\nДобавление прошло успешно");
                    break;
                //Просмотр рейсов с помощью GetRouteQuery
                case 12:
                    Console.WriteLine("\nинформация о всех рейсах: ");
                    DatabaseRequests.GetRouteQuery();
                    break;
                //Добавление нового рейса с помощью AddNewRoute
                case 13:
                    Console.WriteLine("Введите ID водителя: ");
                    idDriver = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ID машины: ");
                    int idCar = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ID маршрута: ");
                    int idItinerary = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите вместимость: ");
                    numberPessenger = int.Parse(Console.ReadLine());
                    DatabaseRequests.AddNewRoute(idDriver, idCar, idItinerary, numberPessenger);
                    break;
                //Закрытие программы
                case 14:
                    Console.WriteLine("\nЗавершение программы...");
                    check = false;
                    break;
                default:
                    Console.WriteLine("\nТакой команды нет");
                    break;
            }

        }
    }

    // проверка корректности ввода даты рождения
    public static void CheckingBirthday(string birthday)
    {
        while (true)
        {
            birthday = Console.ReadLine();
            CultureInfo enUs = new CultureInfo("en-US");
            DateTime dateTime;
            if (DateTime.TryParseExact(birthday, "yyyy/MM/dd", enUs, DateTimeStyles.None, out dateTime) != true)
                break;
            else
                Console.WriteLine("\nНеверный формат даты! Введите дату снова");
        }
    }
    
}