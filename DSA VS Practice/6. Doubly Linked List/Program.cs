using System.Drawing;

public class Node
{
    public int element;
    public Node next;
    public Node prev;
    public Node(int e, Node n, Node p)
    {
        element = e;
        next = n;
        prev = p;
    }
}

class DoublyLinkedList
{
    public Node head;
    public Node tail;
    public int Size;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        Size = 0;
    }

    public int Lenght
    {
        get
        {
            return Size;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return Size == 0;
        }
    }

    public void addLast(int e)
    {
        Node newest = new Node(e, null, null);
        if(IsEmpty)
        {
            head = newest;
            tail = newest;
        }
        else
        {
            tail.next = newest;
            newest.prev = tail;
            tail = newest;
        }
        Size++;
    }

    public void addFirst(int e)
    {
        Node newest = new Node(e, null, null);
        if(IsEmpty)
        {
            head = newest;
            tail = newest;
        }
        else
        {
            newest.next = head;
            head.prev = newest;
            head = newest;
        }
        Size++;
    }

    public void display()
    {
        Node p = head;
        while(p != null)
        {
            Console.Write(p.element + ", ");
            p = p.next;
        }
        Console.WriteLine();
    }

    public void addAnywhere(int e, int position)
    {
        if(position <= 0 || position >= Size)
        {
            Console.WriteLine("Negative Position not alllowed and for Position 0 use addFirst method. For the position = size we have add last method and beyond that we cannot add.");
            return;
        }
        Node newest = new Node(e, null, null);
        Node p = head;
        for(int i = 1; i < position-1;i++)
        {
            p = p.next;
        }
        newest.next = p.next;
        p.next.prev = newest;
        p.next = newest;
        newest.prev = p;
        Size++;
    }

    public int removeFirst()
    {
        if(IsEmpty)
        {
            Console.WriteLine("The LinkedList is Empty. There is nothing to remove.");
            return -1;
        }

        int e = head.element;
        head = head.next;
        Size--;
        if(IsEmpty)
        {
            tail = null;
            head = null;
        }
        else
        {
           head.prev = null;
        }

        return e;
    }

    public int removeLast()
    {
        if(IsEmpty)
        {
            Console.WriteLine("LinkedList is Empty.There is nothing to remove");
            return -1;
        }
        int e = tail.element;
        tail = tail.prev;
        tail.next = null;
        Size--;
        if(IsEmpty)
        {
            head = null;
            tail = null;
        }
        return e;
    }

    public int removeAnywhere(int position)
    {
        if(position <= 0 || position >= Size)
        {
            Console.WriteLine("For position = 0 or Size use removeFirst or removeLast repsectively. Negative and beyond the size cannot be operated.");
            return -1;
        }
        Node p = head;
        for(int i = 1; i < position -1;i++)
        {
            p = p.next;
        }
        int e = p.next.element;
        p.next = p.next.next;
        p.next.prev = p;
        Size--;

        return e;
    }

    static void Main(string[] args)
    {
        DoublyLinkedList l = new DoublyLinkedList();
        l.addLast(12);
        l.addLast(17);
        l.addLast(19);
        l.display();
        Console.WriteLine($"Size: {l.Lenght}");
        l.addFirst(9);
        l.addFirst(10);
        l.display();
        Console.WriteLine($"Size: {l.Lenght}");
        l.addAnywhere(34, 2);
        l.addAnywhere(90, 3);
        l.display();
        Console.WriteLine($"Size: {l.Lenght}");
        l.removeFirst();
        l.display();
        Console.WriteLine($"Size: {l.Lenght}");
        l.removeLast();
        l.display();
        Console.WriteLine($"Size: {l.Lenght}");
        l.removeAnywhere(3);
        l.display();
        Console.WriteLine($"Size: {l.Lenght}");

    }
}