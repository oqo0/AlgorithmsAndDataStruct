using System;

namespace AlgorithmsAndDataStruct
{
    static class AlgorithmsAndDataStruct
    {
        public static void Main()
        {
            IsNumberPrime(7); // простое
            IsNumberPrime(1); // простое
            IsNumberPrime(11); // простое 
            IsNumberPrime(6); // не простое 
            IsNumberPrime(80); // не простое
        }

        static void IsNumberPrime(int number)
        {
            int d = 0, i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    i++;
                }
                else
                    i++;
            }

            Console.WriteLine(d == 0 ? "Простое." : "Не простое.");
        }
    }
}