using System;
using System.Globalization;

namespace task1_student
{
    // Создание класса Student
    internal class Student
    {
        // Свойства класса:
        public static string Surname { get; set; } // Фамилия
        public static DateTime Birthday { get; set; } // Дата рождения
        public static int Group { get; set; } // Группа
        public int[] Marks = new int[5] { 4, 5, 4, 2, 3 }; // Успеваемость
        
        // Метод CreateStudent
        // Позволяет пользователю ввести данные для создания студента
        public void CreateStudent()
        {
            // Ввод фамилии студента
            Console.WriteLine("Введите фамилию студента: ");
            Surname = Console.ReadLine();
            
            // Ввод даты рождения студента
            Console.WriteLine("Введите дату рождения студента (дд.мм.гггг - 01.01.0001): ");
            // Проверка на корректность ввода даты рождения
            string dateInput;
            while (true)
            {
                dateInput = Console.ReadLine();
                CultureInfo enUs = new CultureInfo("en-US");
                DateTime dateTime;
                // Если полученную строку нельзя преобразовать в DateTime, то возобновить попытку ввода
                if (DateTime.TryParseExact(dateInput, "dd/MM/yyyy", enUs, DateTimeStyles.None, out dateTime) != true)
                {
                    Birthday = DateTime.Parse(dateInput);
                    break;
                }
                else
                    Console.WriteLine("Неверный формат даты! Введите дату снова");
            }

            // Ввод группы студента
            Console.WriteLine(" номер группы студента: ");
            Group = int.Parse(Console.ReadLine());
            
            PrintInformation(); // Вывод информации о студенте
        }
        
        // Метод EditSurname
        // Позволяет пользователю изменить фамилию студента
        public void EditSurname()
        {
            Surname = Console.ReadLine(); // Ввод новой фамилии
            PrintInformation(); // Вывод измененной информации о студенте
        }
        
        // Метод EditSurname
        // Позволяет пользователю изменить дату рождения студента
        public void EditBirthday()
        {
            // Проверка на корректность ввода даты рождения
            string dateInput;
            while (true)
            {
                dateInput = Console.ReadLine();  // Ввод новой даты рождения студента
                CultureInfo enUs = new CultureInfo("en-US");
                DateTime dateTime = new DateTime();
                // Если полученную строку нельзя преобразовать в DateTime, то возобновить попытку ввода
                if (DateTime.TryParseExact(dateInput, "dd/MM/yyyy", enUs, DateTimeStyles.None, out dateTime) != true)
                {
                    Birthday = DateTime.Parse(dateInput);
                    break;
                }
                else
                    Console.WriteLine("Неверный формат даты! Введите дату снова");
            }

            PrintInformation(); // Вывод измененной информации о студенте
        }

        // Метод EditSurname
        // Позволяет пользователю изменить номер группы студента
        public void EditGroup()
        {
            Group = int.Parse(Console.ReadLine()); // Ввод нового номера группы студента
            PrintInformation(); // Вывод измененной информации о студенте
        }

        // Метод PrintInformation
        // Выводит в консоль информацию о студенте (фамилию, дату рождения, номер группы)
        public void PrintInformation()
        {
            Console.WriteLine("\nИнформация о студенте:");
            // Преведение типа DateTime в короткий формат и конвертация в тип string
            string date = Birthday.ToShortDateString(); 
            // Вывод
            Console.WriteLine($"Фамилия: {Surname}\nДата рождения {date}\nНомер группы {Group}\n");
        }
    }

    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Student student = new Student(); // Создание объекта класса Student
            
            student.CreateStudent(); // Создание студента
            
            // Вывод в консоль возможных команд
            bool check = true;
            while (check != false)
            {
                Console.WriteLine("\nЧтобы изменить данные выберите соответствующую команду: ");
                Console.Write("0 - Изменить фамилию\n" +
                              "1 - Изменить дату рождения\n" +
                              "2 - Изменить номер группы\n" +
                              "3 - Закрыть программу\n");
                
                int input = int.Parse(Console.ReadLine()); // Ввод команды пользователем
                switch (input)
                {
                    // Изменение фамилии студента
                    case 0:
                        Console.WriteLine("\nВведите новую фамилию: ");
                        student.EditSurname();
                        break;
                    // Изменение даты рождения студента
                    case 1:
                        Console.WriteLine("\nВведите новую дату рождения (дд.мм.гггг - 01.01.0001): ");
                        student.EditBirthday();
                        break;
                    // Изменение номера группы студента
                    case 2:
                        Console.WriteLine("\nВведите новый номер группы: ");
                        student.EditGroup();
                        break;
                    // Закрытие программы
                    case 3:
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