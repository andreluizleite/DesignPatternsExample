namespace DesignPattersExample.Behavioral;

//Strategy interface
public interface ISortStrategy
{
    void Sort(int[] array);
}

//Concrete Strategy A
public class QuickSort : ISortStrategy
{
    public void Sort(int[] array)
    {
        Array.Sort(array);
        Console.WriteLine($"Array sorted using Quick Sort.");
    }
}

//Concrete Strategy B
public class MergeSort: ISortStrategy
{
   public void Sort(int[] array)
   {
        if(array.Length < 2)
            return;

        int mid = array.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];

        //Fill left and right arrays
        Array.Copy(array, 0, left, 0, mid);
        Array.Copy(array, mid, right, 0, array.Length - mid);

        //Recursivily sort both halves
        Sort(left);
        Sort(right);

        Merge(array, left, right);
   }

   private void Merge(int[] result, int[] left, int[] right)
   {
        int i =0, j=0, k=0;

        while(i < left.Length && j < right.Length)
        {
            if(left[i] <= right[j])
            {
                result[k++] = left[i++];
            }
            else
            {
                result[k++] = right[j++];
            }
        }

        while(i < left.Length)
        {
            result[k++] = left[i++];
        }

        while(j < right.Length)
        {
            result[k++] = right[j++];
        }
   }
}

//Concrete Strategy C
public class LinqSort : ISortStrategy
{
    public void Sort(int[] array)
    {
        var sortedArray = array.OrderBy(n => n).ToArray();
        Array.Copy(sortedArray, array, array.Length);

        Console.WriteLine("Array sorted using Linq Sort");
    }
}


//Context
public class Sorter
{
     private readonly ISortStrategy _sortStrategy;

     public Sorter(ISortStrategy sortStrategy)
     {
        _sortStrategy = sortStrategy;
     }

     public void Sort(int[] array)
     {
        _sortStrategy.Sort(array);
     }

}