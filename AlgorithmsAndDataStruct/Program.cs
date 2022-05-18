using System;

namespace Lesson7
{
    class Lesson7
    {
        public static void Main()
        {
            // Для прямоугольного поля размера M на N клеток,
            // подсчитать количество путей из верхней левой
            // клетки в правую нижнюю. Известно что ходить
            // можно только на одну клетку вправо или вниз.
            
            Test.Do(1, PathsCount(1, 1));
            Test.Do(2, PathsCount(2, 2));
            Test.Do(35, PathsCount(5, 4));
            Test.Do(70, PathsCount(5, 5));
            Test.Do(0, PathsCount(0, 0));
            Test.Do(0, PathsCount(0, 10));
            
            Console.ReadLine();
        }

        
        /// <summary>
        /// Подсчёт кол-ва путей
        /// </summary>
        private static int PathsCount(int m, int n)
        {
            if (m <= 0 || n <= 0) return 0;
            
            int[,] matrix = new int[m, n];

            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (x == 0 || y == 0)
                    {
                        matrix[x, y] = 1;
                        continue;
                    }
                    
                    matrix[x, y] = matrix[x - 1, y] + matrix[x, y - 1];
                }
            }

            return matrix[m - 1, n - 1];
        }
    }
}