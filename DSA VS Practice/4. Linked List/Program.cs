class Progarm
{
    static void Main(string[] args)
    {
        LinkedList<int> nn = new LinkedList<int>();

        LinkedList<string> ln = new LinkedList<string>(["hellow", "there", "Subhasis"]);

        //Properties
        Console.WriteLine(ln.First.Value);//First Node Value
        Console.WriteLine(ln.First.Next.Value);//Second Node value
        Console.WriteLine(ln.Last.Value);// last node value
        Console.WriteLine(ln.Count);
        Console.WriteLine(ln.First.Previous);
        //Methods
        //Addition
        LinkedListNode<int> l1 = new LinkedListNode<int>(12);
        LinkedListNode<int> l2 = new LinkedListNode<int>(14);
        LinkedListNode<int> l3 = new LinkedListNode<int>(17);
        LinkedListNode<int> l4 = new LinkedListNode<int>(18);
        nn.AddLast(l1);//12
        nn.AddLast(13);//12, 13
        nn.AddFirst(l2);//14, 12, 13
        nn.AddFirst(16);//16, 14, 12, 13
        nn.AddBefore(l2, 10);//16, 10, 14, 12, 13
        nn.AddAfter(l2, l3);//16, 10, 14, 17, 12, 13
        //Remove Methods
        nn.RemoveFirst();//10, 14, 17, 12, 13
        nn.RemoveLast();//10, 14, 17, 12
        nn.Remove(17);//10. 14, 12
        nn.Remove(l2);//10, 12
        nn.Clear();//No elements
        // Again populate the values for testing
        nn.AddLast(l1);//12
        nn.AddLast(13);//12, 13
        nn.AddFirst(l2);//14, 12, 13
        nn.AddFirst(16);//16, 14, 12, 13
        nn.AddBefore(l2, 10);//16, 10, 14, 12, 13
        nn.AddAfter(l2, l3);//16, 10, 14, 17, 12, 13
        //Finding the values
        Console.WriteLine(nn.Find(16).Value);
        Console.WriteLine(nn.Contains(12));
        Console.WriteLine(nn.FindLast(13).ValueRef);
        //ForEach Loop for LinkedList
        foreach(var l in nn)
        {
            Console.WriteLine(l + ", ");
        }


    }

}
