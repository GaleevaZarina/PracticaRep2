using System;
using System.Collections.Generic;

namespace task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            
            int[] candidates = {2, 5, 2, 1, 2};
            int target = 5;
    
            List<List<int>>result = new List<List<int>>(); 
            Array.Sort(candidates);
    
            List<int> array = new List<int>();
            FindCombinations(candidates,target,0,array,result);
    
            foreach(List<int> combinations in result)
            {
                foreach(int num in combinations)
                    Console.Write(num + " " );  
                Console.WriteLine();
            }
    
                
        }
        public static void FindCombinations(int[] candidates, int target, int index,List<int> array, List<List<int>>result)
        {
            if(target == 0)
            {
                result.Add(new List<int>(array));
                return;
            } 
            for(int i = index; i < candidates.Length; i++)
            {
                if(candidates[i] > target)
                    break;  
                if(i > index && candidates[i] == candidates[i-1])
                    continue;
                array.Add(candidates[i]);
                int newTarget = target - candidates[i];
                int newIndex = i + 1;
                FindCombinations(candidates,newTarget,newIndex, array, result);
                array.RemoveAt(array.Count - 1);
            }
        
        }
    }  
  
    
    
}