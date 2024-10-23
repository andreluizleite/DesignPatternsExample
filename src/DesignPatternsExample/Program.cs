using System.Diagnostics;
using DesignPattersExample.Behavioral;

public class Program
{
    private static void Main(string[] args)
    {
        int size = 1000000;
        int[] array = new int[size];
        Random rand = new Random();

        for(int i = 0; i< size; i++)
        {
            array[i] = rand.Next(1, size);
        }


        //Arrange
        int[] quickSortArray = (int[])array.Clone();
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        Console.WriteLine("Before Quick Sort:");
        var sorter = new Sorter(new QuickSort());
        sorter.Sort(quickSortArray);
        stopwatch1.Stop();
        Console.WriteLine($"Array.Sort Time: {stopwatch1.ElapsedMilliseconds} ms.");
        
        //Merge Sorter
        int[] mergeSortArray =(int[])array.Clone();
         Stopwatch stopwatch2 = Stopwatch.StartNew();
        var sortedByMerge = new Sorter(new MergeSort());

        Console.WriteLine("Before Merge Sort:");
        sortedByMerge.Sort(mergeSortArray);
        stopwatch2.Stop();
        Console.WriteLine($"Array.Sort Time: {stopwatch2.ElapsedMilliseconds} ms.");


        int[] linqSortArray = (int[])array.Clone();
        Stopwatch stopwatch3 = Stopwatch.StartNew();
        Console.WriteLine("Before Linq Sort:");
        var sorterLinq = new Sorter(new LinqSort());
        sorterLinq.Sort(linqSortArray);
        stopwatch3.Stop();
        Console.WriteLine($"Array.Sort Time: {stopwatch3.ElapsedMilliseconds} ms");
    }
}