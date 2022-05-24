namespace Lesson8;

internal static class Sort
{
    /// <summary>
    /// Блоченая сортировка
    /// Вместо рекурсивной сортировки буде вызывать сортировку вставкой
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    internal static int[] BucketSort(int[] array)
    {
        List<int>[] buckets = new List<int>[array.Length].Select(item => new List<int>()).ToArray();

        int bucketStep = (Math.Abs(array.Min()) + Math.Abs(array.Max())) / array.Length;
        if (bucketStep == 0) bucketStep = 1;
        
        foreach (var val in array)
        {
            int pos = val / bucketStep;
            buckets[pos > array.Length - 1 ? array.Length - 1 : pos].Add(val);
        }

        for (int i = 0, count = 0; i < buckets.Length; i++)
        {
            if (buckets[i].Count > 1)
                buckets[i] = InsertionSort(buckets[i].ToArray()).ToList();
            for (int k = 0; k < buckets[i].Count; k++, count++)
                array[count] = buckets[i][k];
        }
        
        return array;
    }

    private static int[] InsertionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;
            
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                    min = j;
            }
            
            (array[min], array[i]) = (array[i], array[min]);
        }

        return array;
    }
}