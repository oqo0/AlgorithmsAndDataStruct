using System;

namespace Task2
{
    class Test
    {
        public static void BinarySearch(int expectedValue, int realValue)
        {
            if (expectedValue == realValue)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("True.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("False.");
                Console.ResetColor();
            }
        }
    }
    class Task2
    {
        public static void Main()
        {
            var array = new int[] {1, 3, 6, 8, 9};
            
            Test.BinarySearch(1, BinarySearch(array, 3));
            Test.BinarySearch(-1, BinarySearch(array, 9999));
            Test.BinarySearch(0, BinarySearch(array, 1));
            Test.BinarySearch(4, BinarySearch(array, 9));
            Test.BinarySearch(-1, BinarySearch(array, -100));
        }

        /// <summary>
        /// Нахождение элемента в массиве
        /// Асимптотическая сложность - O(N)
        /// Так как кол-во выполняемых операций напрямую зависит от длинны массива.
        /// </summary>
        public static int BinarySearch(int[] array, int value)
        {
            int min = 0, max = array.Length - 1;

            while (min <= max)
            {
                int middle = (min + max) / 2;

                if (array[middle] == value)
                    return middle;
                
                if (value < array[middle])
                    max = middle - 1;
                
                if (value > array[middle])
                    min = middle + 1;
            }

            return -1;
        }
    }
}