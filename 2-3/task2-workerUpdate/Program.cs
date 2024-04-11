using System;
using System.Collections.Generic;

namespace task2_workerUpdate
{
    internal class Worker
    {
        private string name;

        public string Name
        {
            set { name = value;}
            get { return name; }
        }
        
        private string surname;     
        
        public string Surname
        {
            set { surname = value;}
            get { return surname; }
        }
        
        private int rate;
        
        public int Rate
        {
            set { rate = value;}
            get { return rate; }
        }
        
        private int days;
        
        public int Days
        {
            set { days = value;}
            get { return days; }
        }

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
            List<Worker> listOFWorkers = new List<Worker>();                        
            bool check = true;           
            while (check != false)            
            {                
                Console.WriteLine("\n0 - Добавить сотрудника\n1 - Посмотреть информацию о сотрудниках\n2 - Закрыть программу\n");                
                int input = int.Parse(Console.ReadLine());                
                switch (input)                
                {                    
                    case 0:
                        listOFWorkers = CreateWorker(listOFWorkers);                        
                        break;                    
                    case 1:
                        PrintInfo(listOFWorkers);                        
                        break;                    
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

        public static List<Worker> CreateWorker(List<Worker> listOfWorkers)
        {
            Worker worker = new Worker();                        
            Console.WriteLine("Введите имя сотрдуника:");            
            worker.Name = Console.ReadLine();            
            Console.WriteLine("Введите фамилию сотрдуника:");            
            worker.Surname = Console.ReadLine();            
            Console.WriteLine("Введите ставку сотрдуника:");            
            worker.Rate = int.Parse(Console.ReadLine());            
            Console.WriteLine("Введите количество отработанных дней сотрдуника:");            
            worker.Days = int.Parse(Console.ReadLine());                        
            listOfWorkers.Add(worker);            
            return listOfWorkers;
        }

        public static void PrintInfo(List<Worker> listOfWorkers)
        {
            if (listOfWorkers.Count > 0)
                foreach (var item in listOfWorkers)
                    Console.Write($"\nИмя: {item.Name}\tФамилия: {item.Surname}\tСтавка: {item.Rate}\tДни: {item.Days}\tЗарплата: {item.GetSalary()}");
            else
                Console.WriteLine("\nСписок сотрудников пуст");
        }    
    }
    
}