using Npgsql;

namespace GarageConsoleApp;

/// <summary>
/// Класс DatabaseRequests
/// содержит методы для отправки запросов к БД
/// </summary>
public static class DatabaseRequests
{
    /// <summary>
    /// Метод GetTypeCarQuery
    /// отправляет запрос в БД на получение списка типов машин
    /// выводит в консоль список типов машин
    /// </summary>
    public static void GetTypeCarQuery()
    {
        // Сохраняем в переменную запрос на получение всех данных и таблицы type_car
        var querySql = "SELECT * FROM type_car";
        // Создаем команду(запрос) cmd, передаем в нее запрос и соединение к БД
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        // Выполняем команду(запрос)
        // результат команды сохранится в переменную reader
        using var reader = cmd.ExecuteReader();
        
        // Выводим данные которые вернула БД
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}\tНазвание: {reader[1]}");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Метод AddTypeCarQuery
    /// отправляет запрос в БД на добавление типа машины
    /// </summary>
    public static void AddTypeCarQuery(string name)
    {
        var querySql = $"INSERT INTO type_car(name) VALUES ('{name}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Метод AddDriverQuery
    /// отправляет запрос в БД на добавление водителей
    /// </summary>
    public static void AddDriverQuery(string firstName, string lastName, DateTime birthdate)
    {
        var querySql = $"INSERT INTO driver(first_name, last_name, birthdate) VALUES ('{firstName}', '{lastName}', '{birthdate}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Метод GetDriverQuery
    /// отправляет запрос в БД на получение списка водителей
    /// выводит в консоль данные о водителях
    /// </summary>
    public static void GetDriverQuery()
    {
        var querySql = "SELECT * FROM driver";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}\tИмя: {reader[1]}\tФамилия: {reader[2]}\tДата рождения: {reader[3]}");
        }
        Console.WriteLine();
    }

    /// Метод GetRightsCategoryQuery
    /// Отправляет запрос в БД на получение списка всех категорий прав
    public static void GetRightsCategoryQuery()
    {
        var querySql = "SELECT * FROM rights_category";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id категории: {reader[0]}\tНазвание категории: {reader[1]}");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Метод AddRightsCategoryQuery
    /// отправляет запрос в БД на добавление новой категорий прав
    /// </summary>
    public static void AddRightsCategoryQuery(string name)
    {
        var querySql = $"INSERT INTO rights_category(name) VALUES ('{name}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Метод AddDriverRightsCategoryQuery
    /// отправляет запрос в БД на добавление категории прав водителю
    /// </summary>
    public static void AddDriverRightsCategoryQuery(int driver, int rightsCategory)
    {
        var querySql = $"INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES ({driver}, {rightsCategory})";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Метод GetDriverRightsCategoryQuery
    /// отправляет запрос в БД на получение категорий водителей
    /// выводит в консоль информацию о категориях прав водителей
    /// </summary>
    public static void GetDriverRightsCategoryQuery(int driver)
    {
        var querySql = "SELECT dr.first_name, dr.last_name, rc.name " +
                       "FROM driver_rights_category " +
                       "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                       "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category " +
                       $"WHERE dr.id = {driver};";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Имя: {reader[0]}\tФамилия: {reader[1]}\tКатегория прав: {reader[2]}");
        }
        Console.WriteLine();
    }
    
    /// Метод GetCarQuery
    /// отправляет запрос в БД для получения данных о машинах
    /// Выводит в консоль информацию о машинах
    public static void GetCarQuery()
    {
        var querySql = "SELECT * FROM car";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}\tТип машины: {reader[1]}\tМашина: {reader[2]}\tНомер: {reader[3]}\tвместимость: {reader[4]} ");
        }
        Console.WriteLine();
    }

    /// Метод AddNewCar
    /// отправляет запрос в БД на добалвение новой машины
    public static void AddNewCar(string nameCar, string state_number, int number_pessenger, int id_type_car)
    {
        var querySql = $"INSERT INTO car(id_type_car, name, state_number, number_passengers) VALUES ({id_type_car}, '{nameCar}', '{state_number}', '{number_pessenger}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }
    
    /// Метод GetItineraryQuery
    /// Отправляет запрос в БД на просмотр всех маршрутов
    /// Выводит в консоль информацию о маршрутах
    public static void GetItineraryQuery()
    {
        var querySql = "SELECT * FROM itinerary";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}\tМаршрут: {reader[1]} ");
        }
        Console.WriteLine();
    }

    /// Метод AddNewItinerary
    /// Отправляет запрос в БД на добавление нового маршрута
    public static void AddNewItinerary(string name)
    {
        var querySql = $"INSERT INTO itinerary(name) VALUES ('{name}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    /// Метод GetRouteQuery
    /// Отправляет запрос в БД на получение данных о рейсах
    /// Выводитв консоль информацию о рейсах
    
    public static void GetRouteQuery()
    {
        var querySql = "SELECT * FROM route";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}\tId водителя: {reader[1]}\tId машины {reader[2]}\tId маршрута {reader[3] }\tКоличество пассажиров {reader[4]}");
        }
        Console.WriteLine();
    }
    
    /// Метод AddNewRoute
    /// Отправляет запрос в БД на добавление нового рейса
    public static void AddNewRoute(int idDrive, int idCar, int idItinerary, int passengerCount)
    {
        var querySql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES ('{idDrive}','{idCar}','{idItinerary}','{passengerCount}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    
}