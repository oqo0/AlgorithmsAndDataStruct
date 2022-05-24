namespace Lesson8
{
    class Lesson8
    {
        static void Main()
        {
            Console.WriteLine(
                String.Join(", ", Sort.BucketSort(new[] { 3, 6, 8, 12, 100, 200, 500 }))
                );
            Console.WriteLine(
                String.Join(", ", Sort.BucketSort(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }))
            );
            Console.WriteLine(
                String.Join(", ", Sort.BucketSort(new[] { 0, 0, 0, 1, 0, 0 }))
            );
            Console.WriteLine(
                String.Join(", ", Sort.BucketSort(new[] { 10000, 900, 10, 1 }))
            );
            
            Console.ReadKey();
        }
    }
}