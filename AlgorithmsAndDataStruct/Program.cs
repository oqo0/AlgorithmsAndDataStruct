using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson4
{
    public class BenchmarkTests
    {
        public static HashSet<string> hashSet = new HashSet<string>();
        public static string[] array = new string[50000];
        
        static Random rnd = new Random();
        
        [Benchmark]
        public void ContainsInHashSet()
        {
            string searchedValue = rnd.Next(1, 100000).ToString();
            Console.WriteLine(hashSet.Contains(searchedValue));
        }
        
        [Benchmark]
        public void ContainsInArray()
        {
            string searchedValue = rnd.Next(1, 100000).ToString();
            Console.WriteLine(array.Contains(searchedValue));
        }
    }
    class Lesson4
    {
        public static void Main()
        {
            Random rnd = new Random();
            
            // заполним массив
            for (int i = 0; i < BenchmarkTests.array.Length; i++)
            {
                BenchmarkTests.array[i] = rnd.Next(1, 100000).ToString();
            }
            
            // заполним hashSet
            for (int i = 0; i < 50000; i++)
            {
                BenchmarkTests.hashSet.Add(rnd.Next(1, 100000).ToString());
            }
            
            BenchmarkSwitcher.FromAssembly(typeof(Lesson4).Assembly).Run();
            
            /*
            Результаты замеров:
            |            Method |     Mean |    Error |   StdDev |   Median |
            |------------------ |---------:|---------:|---------:|---------:|
            | ContainsInHashSet | 127.3 us |  7.55 us | 22.03 us | 129.1 us |
            |   ContainsInArray | 120.0 us | 11.34 us | 33.43 us | 132.7 us |
            */
        }
    }
}