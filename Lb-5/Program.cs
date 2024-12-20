using System;

class Program
{
    public delegate bool ComparisonDelegate(int a, int b);

    static void Main(string[] args)
    {
        int[] numbers = { 5, 3, 8, 6, 2, 7, 4, 1 };

        Console.WriteLine("Початковий масив:");
        PrintArray(numbers);

        BubbleSort(numbers, (a, b) => a > b);
        Console.WriteLine("\nМасив після сортування за зростанням:");
        PrintArray(numbers);

        BubbleSort(numbers, (a, b) => a < b);
        Console.WriteLine("\nМасив після сортування за спаданням:");
        PrintArray(numbers);
    }

    static void BubbleSort(int[] array, ComparisonDelegate compare)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (compare(array[j], array[j + 1]))
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}