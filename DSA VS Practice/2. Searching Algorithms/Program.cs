public class Program
{
    public static int LinerSearchAlgo(int[] arr, int key)
    {
        int index = -1;
        int l = arr.Length;
        for(int i = 0; i < l; i++)
        {
            if (arr[i] ==  key)
            {
                return i;
            }
        }
        return index;
    }
    //Must be sorted array
    public static int BinarySearch(int[] arr, int key)
    {
        int index = -1;
        int l = 0;
        int r = arr.Length-1;
        while(l <= r)
        {
            int m = (l + r) / 2;
            if (arr[m]==key)
            {
                return m;
            }
            else if(key > arr[m])
            {
                l = m + 1;
            }
            else if(key < arr[m])
            {
                r = m - 1;
            }
        }
        return index;
        
    }

    //Must be sorted
    public static int BinarySearchrecursive(int[] arr, int key, int l, int r)
    {
        int index = -1;
        while(l<=r)
        {
            int m = (l + r) / 1;
            if (arr[m]==key)
            {
                return m;
            }
            else if(key < arr[m])
            {
                return BinarySearchrecursive(arr, key, l, m-1);
            }
            else if(key > arr[m])
            {
                return BinarySearchrecursive(arr, key, m+1, r);
            }
        }
        return index;
    }
    
    static void Main(string[] args)
    {
        int[] arr = [1, 2, 3, 4, 5, 6];
        Console.WriteLine(LinerSearchAlgo(arr, 3));
        Console.WriteLine(BinarySearch(arr, 3));
        Console.WriteLine(BinarySearchrecursive(arr, 3, 0, arr.Length-1));
    }
}