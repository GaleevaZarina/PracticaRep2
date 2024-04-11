using System;

namespace task5_class
{

    internal class NomerFive
    {
        public string line { get; set; }
        public int numb { get; set; }

        public NomerFive ()
        {
            line = "chocolate";
            numb = 10;
        }
        
        public NomerFive (int inputNumb, string inputLine)
        {
            line = inputLine;
            numb = inputNumb ;
        }
        
        ~NomerFive()
        {
            Console.WriteLine("The object has been deleted.");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            NomerFive object1 = new NomerFive();
            Console.WriteLine($"numb = {object1.numb}\tline = {object1.line}");
            
            NomerFive object2 = new NomerFive(23, "Happy New Year");
            Console.WriteLine($"numb = {object2.numb}\tline = {object2.line}");
            
        }
    }
}