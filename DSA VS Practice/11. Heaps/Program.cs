class Heap
{
    public int[] data;
    public int maxSize;
    public int currentSize;

    public int Length
    {
        get { return currentSize; }
    }

    public bool IsEmpty
    {
        get { return currentSize == 0; }
    }


    public void Insert(int value)
    {
        if (currentSize == maxSize)
        {
            Console.WriteLine("Heap is full. Cannot insert new value.");
            return;
        }
        currentSize++;
        int index = currentSize;
        while (index > 1 && value > data[index / 2]) //Here data[index / 2] is the parent node of the current index
                                                     //Here index > 1 because the root node is at index 1 and it has no parent, so we stop the loop when we reach the root node.
        {
            data[index] = data[index / 2]; //Here we are moving the parent node down to the current index because the value we want to insert is greater than the parent node, so we need to move the parent node down to make space for the new value.
            index /= 2; //Here we are moving up the tree by dividing the index by 2 to get the parent node's index.
        }
        data[index] = value;
    }

    public int Max()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Heap is empty. No maximum value.");
            return -1; // Return -1 or throw an exception to indicate the heap is empty
        }
        return data[1]; // The maximum value in a max heap is always at index 1
    }

    public void Display()
    {
        for (int i = 1; i <= currentSize; i++)
        {
            Console.Write(data[i] + " ");
        }
        Console.WriteLine();
    }

    public int Delete()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Heap is empty. Cannot delete value.");
            return -1; // Return -1 or throw an exception to indicate the heap is empty
        }
        int deletedRoot = data[1]; // Store the root value to return later
        data[1] = data[currentSize]; // Move the last element to the root
        data[currentSize] = -1;
        currentSize--; // Decrease the size of the heap
        int i = 1;//Root index
        int j = 2 * i; // Left child index
        while (j < currentSize)
        {
            if (data[j] < data[j + 1]) // Compare left and right child
            {
                j++; // Move to the right child if it's greater
            }
            if (data[i] < data[j]) // Compare parent with the larger child
            {
                //swap parent and child
                int temp = data[i];
                data[i] = data[j];
                data[j] = temp;
                // Move down the tree
                i = j;
                j = 2 * i;
            }
            else // If the parent is greater than or equal to the larger child, we are done
            {
                break;
            }
        }
        return deletedRoot; // Return the deleted root value
    }

    public void HeapSort(int[] arr)
    {
        int n = arr.Length;
        Heap heap = new Heap();
        // Build the heap
        for (int i = 0; i < n; i++)
        {
            heap.Insert(arr[i]);
        }
        // Extract elements from the heap and store them back in the array  
        for (int i = n - 1; i >= 0; i--)
        {
            arr[i] = heap.Delete();
        }

    }

    public Heap()
    {
        maxSize = 10;
        data = new int[maxSize];
        currentSize = 0;
        for (int I = 0; I < data.Length; I++)
        {
            data[I] = -1;
        }
    }

    static void Main(string[] args)
    {
        Heap heap = new Heap();
        heap.Insert(10);
        heap.Insert(20);
        heap.Insert(5);
        heap.Insert(15);
        heap.Display();

        int[] ints = { 12, 345, 13, 4325, 123, 4525 };
        heap.HeapSort(ints);
        Console.WriteLine("Sorted array:");
        foreach (int num in ints)
        {
            Console.Write(num + " ");
        }
    }
}