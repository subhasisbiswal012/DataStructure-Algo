class Node
{
    public int element;
    public Node next;
    public Node(int e, Node n)
    {
        element = e;
        next = n;
    }
}

class CircularLinkedList
{
    public Node head;
    public Node tail;
    public int size;

    public CircularLinkedList()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public int length()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void addLast(int e)
    {
        Node newest = new Node(e, null);
        if(IsEmpty())
        {
            newest.next = newest;
            head = newest;
        }
        else
        {
            newest.next = tail.next;
            tail.next = newest;
        }
        tail = newest;
        size++;
    }

    public void addFirst(int e)
    {
        Node newest = new Node(e, null);
        if(IsEmpty())
        {
            newest.next = newest;
            head = newest;
            tail = newest;
        }
        else
        {
            tail.next = newest;
            newest.next = head;
            head = newest;
        }
        size++;
    }

    public void addAnywhere(int e, int pos)
    {
        if(pos <= 0 || pos >= size)
        {
            Console.WriteLine("Invalid Entry");
        }
        Node newest = new Node(e, null);
        Node p = head;
        int i = 1;
        while(i < pos-1)
        {
            p = p.next;
            i++;
        }
        newest.next = p.next;
        p.next = newest;
        size++;
    }

    public int removeFirst()
    {
        if(IsEmpty())
        {
            Console.WriteLine("The LinkedList is empty");
            return -1;
        }
        int e = head.element;
        tail.next = head.next;
        head = head.next;
        size--;
        if(IsEmpty())
        {
            head = null;
            tail = null;
        }
        return e;
    }


    public int removeLast()
    {

        if (IsEmpty())
        {
            Console.WriteLine("The LinkedList is empty");
            return -1;
        }
        Node p = head;
        int i = 1;
        while(i < length()-1)
        {
            p = p.next;
            i++;
        }
        tail = p;
        p = p.next;
        tail.next = head;
        int e = p.element;
        size--; ;
        return e;
    }

    public int removeAnywhere(int position)
    {
        if(position <= 0 || position >= size-1)
        {
            Console.WriteLine("Invalid Position");
            return -1;
        }
        Node p = head;
        int i = 1;
        while(i < position-1)
        {
            p = p.next;
            i++;
        }
        int e = p.next.element;
        p.next = p.next.next;
        size--;
        return e;
    }

    public void display()
    {
        Node p = head;
        int i = 0;
        while(i < length())
        {
            Console.WriteLine(p.element + ", ");
            p = p.next;
            i++;
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        CircularLinkedList n = new CircularLinkedList();
        n.addLast(12);
        n.addLast(25);
        n.addLast(67);
        n.display();
        Console.WriteLine("Szie: " + n.size);
        n.addLast(90);
        n.addLast(789);
        n.display();
        Console.WriteLine("Size now is :" + n.size);
        n.addFirst(23);
        n.addFirst(45);
        n.display();
        Console.WriteLine("Size now is :" + n.size);
        n.addAnywhere(99, 4);
        n.display();
        Console.WriteLine("Size now is :" + n.size);
        n.removeFirst();
        n.display();
        Console.WriteLine("Size now is :" + n.size);
        n.removeLast();
        n.display();
        Console.WriteLine("Size now is :" + n.size);
        n.removeAnywhere(3);
        n.display();
        Console.WriteLine("Size now is :" + n.size);

    }

}
