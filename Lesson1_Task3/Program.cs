using System;

namespace AlgorithmsAndDataStruct
{
    static class AlgorithmsAndDataStruct
    {
        public static void Main()
        {
            // 0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610
            // функции рабоют правильно в обоих случаях
            
            FibonacciRecursion(0, 1);
            
            Console.WriteLine();
            
            FibonacciLoop();
        }
        
        static void FibonacciRecursion(int n1, int n2)
        {
            Console.Write(n1 + " ");
            if (n1 < 500)
                FibonacciRecursion(n2, n1 + n2);
        }

        static void FibonacciLoop()
        {
            for (int o = 0, t = 1; o < 500; o += t, t += o)
            {
                Console.Write(o + " " + t + " ");
            }
        }
    }
}