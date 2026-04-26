using System.Collections.Concurrent;
using System.Diagnostics.Contracts;

public class Program
{
    //We have 10 Sortings algoritms but we will only learn about 3-4 Insertion , Merge, Quick, Heap

    #region Insertion Sort Algo
    public static void InsertionSortAlgo(int[] arr)
    {
        int n = arr.Length;
        //First element we will consider as sorted, so we will start with second element
       for(int i = 1;i < n;i++)
        {
            int temp = arr[i];
            int pos = i;
            while(pos > 0 && arr[pos -1] > temp)
            {
                arr[pos] = arr[pos - 1]; // shifts the larger value to right
                pos--;//Do swapping till the leftside sorted
            }
            arr[pos] = temp;//Insert it with correct position
        }
       foreach(var a in arr)
        {
            Console.Write(a + ", ");
        }
        Console.WriteLine();
    }
    #endregion

    #region Merge Sort Algo
    public static void MergeSort(int[] arr, int left, int right)
    {
        if(left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);//Sort & merge Left side
            MergeSort(arr, mid + 1, right);//Sort & merge Right Side
            MergeBoth(arr, left, mid, right);//Sort and merge both left and rigth
        }
       
    }
    public static void MergeBoth(int[] arr, int left, int mid, int right)
    {
        int i = left;
        int j = mid + 1;
        int k = left;
        int[] B = new int[arr.Length];
        while(i <= mid && j <= right)
        {
            if (arr[i] < arr[j])//(left element of one section compared with left elememnt of another section)
            {
                B[k] = arr[i];
                k++;
                i++;
            }
            else
            {
                B[k] = arr[j];
                k++;
                j++;
            }
        }
        while(i <= mid) //for remaining elements when both sections have unmatched number of elements in the leftside mainly
        {
            B[k++] = arr[i++];
        }
        while(j <= right) //for remaining elements when both sections have unmatched number of elements in the right side mainly
        {
            B[k++] = arr[j++];
        }
        for(int x = left; x <= right; x++) //It's merging the 2 sections not the whole array, that's why x = left and x <= right
        {
            arr[x] = B[x];
        }
    }
    #endregion

    #region Quick Sort Algo

    public static void QuickSort(int[] arr, int low, int high)
    {
        if(low < high)
        {
            int pivot = Partition(arr, low, high);
            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }
    }
    
    public static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[low];
        int i = low + 1;
        int j = high;

        do
        {
            while(i <= j && arr[i] <= pivot)
            {
                i++;
            }
            while(i <= j && arr[j] > pivot)
            {
                j--;
            }
            if(i < j)
            {
                swap(arr, i, j);
            }
        }
        while (i < j);
        swap(arr, low, j);
        return j;
    }
    public static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    #endregion
    static void Main(string[] args)
    {
        int[] arr = [1, 89, 34, 12, 90, 34, 109];
        InsertionSortAlgo(arr);



        Console.WriteLine("Merge Sort Start Here");
        int[] arr2 = [1, 89, 34, 12, 90, 34, 109];
        MergeSort(arr2, 0, arr2.Length-1);
        foreach (var a in arr2)
        {
            Console.Write(a + ", ");
        }
        Console.WriteLine();
        Console.WriteLine("Merge Sort Ends Here");

        Console.WriteLine("Quick Sort Started");
        int[] arr3 = [1, 89, 34, 12, 90, 34, 109];
        QuickSort(arr3, 0, arr3.Length-1);
        foreach (var a in arr3)
        {
            Console.Write(a + ", ");
        }
        Console.WriteLine();
        Console.WriteLine("Quick Sort Ends here");
    }
}
