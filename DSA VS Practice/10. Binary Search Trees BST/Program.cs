class Node
{
    public int Element;
    public Node? Left;
    public Node? Right;

    public Node(int element, Node? left, Node? right)
    {
        Element = element;
        Left = left;
        Right = right;
    }
}
class BinarySearchTree
{
    public Node? Root;
    public BinarySearchTree()
    {
        Root = null;
    }

    #region Insert Methods
    public void Insert(Node? tempRoot, int e)
    {
        Node? temp = null;
        while (tempRoot != null)
        {
            temp = tempRoot;
            if(e == tempRoot.Element)
            {
                return;
            }
            else if(e > tempRoot.Element)
            {
                tempRoot = tempRoot.Right;
            }
            else if(e < tempRoot.Element)
            {
                tempRoot = tempRoot.Left;
            }
        }
        Node n = new Node(e, null, null);

        if(Root != null && temp != null)
        {
            if(e < temp.Element)
            {
                temp.Left = n;
            }
            else
            {
                temp.Right = n;
            }
        }
        else
        {
            Root = n; 
        }
    }

    public Node InsertRecursion(Node tempRoot, int e)
    {
        if(tempRoot != null)
        {
            if(e < tempRoot.Element)
            {
                tempRoot.Left =  InsertRecursion(tempRoot.Left, e);
            }
            else if(e > tempRoot.Element)
            {
                tempRoot.Right =  InsertRecursion(tempRoot.Right, e);
            }
        }
        else
        {
            Node n = new Node(e, null, null);
            tempRoot = n;
        }

        return tempRoot;
    }

    #endregion


    #region Traversal Methods
    public void InOrderTraversal(Node tempRoot)
    {
        if(tempRoot != null)
        {
            InOrderTraversal(tempRoot.Left);
            Console.Write(tempRoot.Element + ", ");
            InOrderTraversal(tempRoot.Right);
        }
    }

    public void PreOrderTraversal(Node tempRoot)
    {
        if(tempRoot != null)
        {
            Console.Write(tempRoot.Element + ", ");
            PreOrderTraversal(tempRoot.Left);
            PreOrderTraversal(tempRoot.Right);
        }
    }

    public void PostOrdertraversal(Node temproot)
    {
        if(temproot != null)
        {
            PostOrdertraversal(temproot.Left);
            PostOrdertraversal(temproot.Right);
            Console.Write(temproot.Element + ", ");
        }
    }

    public void LevelOrderTraversal()
    {
        Queue<Node> q = new Queue<Node>();
        Node t = Root;
        Console.Write(t.Element + ", ");
        q.Enqueue(t);
        while(q.Count != 0)
        {
            t = q.Dequeue();
            if(t.Left != null)
            {
                Console.Write(t.Left.Element + ", ");
                q.Enqueue(t.Left);
            }
            if(t.Right != null)
            {
                Console.Write(t.Right.Element + ", ");
                q.Enqueue(t.Right);
            }
        }
    }

    #endregion

    #region Search Element Exist
    public bool ContainsIterative(int key)
    {
        Node temptRoot = Root;
        while(temptRoot != null)
        {
            if (temptRoot.Element == key)
                return true;
            else if (key < temptRoot.Element)
                temptRoot = temptRoot.Left;
            else if (key > temptRoot.Element)
                temptRoot = temptRoot.Right;
        }
        return false;
    }

    public bool ContainsRecursive(Node tempRoot, int Key)
    {
        if(tempRoot != null)
        {
            if(tempRoot.Element == Key)
            {
                return true;
            }
            else if(Key < tempRoot.Element)
            {
                return ContainsRecursive(tempRoot.Left, Key);
            }
            else if(Key > tempRoot.Element)
            {
                return ContainsRecursive(tempRoot.Right, Key);
            }
        }
        return false;
    }

    #endregion

    #region Delete Element

    public bool Delete(int e)
    {
        // --- STEP 1: Search for the node to delete ---
        // 'current' is the node we are examining
        // 'parent' tracks the parent of 'current' so we can re-link after deletion
        Node current = Root;
        Node parent = null;

        while (current != null && current.Element != e)
        {
            parent = current;                  // Save parent before moving down
            if (e < current.Element)
                current = current.Left;        // Go left if target is smaller
            else
                current = current.Right;       // Go right if target is larger
        }

        // --- STEP 2: Element not found ---
        if (current == null)
        {
            Console.WriteLine("Element not found");
            return false;
        }

        // --- STEP 3: Node has TWO children ---
        // We can't simply remove a node with two children because it would
        // disconnect the tree. Instead, we REPLACE its value with the
        // in-order predecessor (largest value in the LEFT subtree),
        // then delete that predecessor node instead (which has at most 1 child).
        //
        //        50                 40
        //       /  \     →        /  \
        //      30   80           30   80
        //       \                 \
        //        40  ← predecessor (largest in left subtree)
        //
        if (current.Left != null && current.Right != null)
        {
            // Find the in-order predecessor:
            // Go one step left, then as far right as possible
            Node predecessor = current.Left;
            Node predecessorParent = current;  // Track predecessor's parent for re-linking

            while (predecessor.Right != null)
            {
                predecessorParent = predecessor;  // ✅ track predecessor's parent correctly
                predecessor = predecessor.Right;
            }

            // Copy predecessor's value into the node we wanted to delete.
            // The node is now logically deleted — we just need to remove the predecessor.
            current.Element = predecessor.Element;

            // Now focus deletion on the predecessor node instead,
            // since it holds the value we just copied up.
            // The predecessor has at most ONE child (only a left child, never a right).
            current = predecessor;
            parent = predecessorParent;
        }

        // --- STEP 4: Find the single child of the node to delete (if any) ---
        // At this point 'current' has AT MOST one child
        // (either a leaf, or one child on one side).
        //
        // Case A: has left child only  →  child = left
        // Case B: has right child only →  child = right
        // Case C: leaf node (no children) → child = null
        Node child = null;
        if (current.Left != null)
            child = current.Left;
        else
            child = current.Right;   // This is also null if current is a leaf, which is fine

        // --- STEP 5: Re-link the parent to bypass the deleted node ---
        if (current == Root)
        {
            // Deleting the root: its only child (or null) becomes the new root
            Root = child;
        }
        else
        {
            // Attach the child to the correct side of the parent
            if (current == parent.Left)
                parent.Left = child;   // current was a left child → replace with its child
            else
                parent.Right = child;  // current was a right child → replace with its child
        }

        return true;
    }

    #endregion

    #region Count Elements
    public int Count(Node tempRoot)
    {
        if(tempRoot != null)
        {
            int x = Count(tempRoot.Left);
            int y = Count(tempRoot.Right);
            return x + y + 1;
        }
        return 0;
    }


    #endregion

    #region Height of Tree
    public int Height(Node tempRoot)
    {
        if(tempRoot != null)
        {
            int x = Height(tempRoot.Left);
            int y = Height(tempRoot.Right);
            if(x > y)
            {
                return x+1;
            }
            else
            {
                return y+1;
            }
        }
        return 0;
    }


    #endregion


    static void Main(string[] args)
    {
        BinarySearchTree B = new BinarySearchTree();
        B.Insert(B.Root, 50);
        B.Insert(B.Root, 30);
        B.Insert(B.Root, 80);
        B.Insert(B.Root, 10);
        B.Insert(B.Root, 40);
        B.Insert(B.Root, 60);
        B.Insert(B.Root, 90);

        #region Traversal Application
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("Inorder Traversal");
        B.InOrderTraversal(B.Root);
        Console.WriteLine();
        B.InsertRecursion(B.Root, 70);
        Console.WriteLine("Inorder Traversal 1.1" );
        B.InOrderTraversal(B.Root);
        Console.WriteLine();

        Console.WriteLine("PreOrder Traversal B");
        B.PreOrderTraversal(B.Root);
        Console.WriteLine();

        Console.WriteLine("postOrder Traversal B");
        B.PostOrdertraversal(B.Root);
        Console.WriteLine();

        Console.WriteLine("Level Order Traversal B");
        B.LevelOrderTraversal();
        Console.WriteLine();
        Console.WriteLine("*****************************************************************************");
        #endregion
        #region Searator
        Console.WriteLine("*****************************************************************************");
        #endregion
        #region Search Element Application
        Console.WriteLine("Iterative Method");
        Console.WriteLine($"Does 50 Exist in B? : {B.ContainsIterative(50)}");
        Console.WriteLine($"Does 100 Exist in B? : {B.ContainsIterative(100)}");
        Console.WriteLine("Recursive Method");
        Console.WriteLine($"Does 50 Exist in B? : {B.ContainsRecursive(B.Root, 50)}");
        Console.WriteLine($"Does 100 Exist in B? : {B.ContainsRecursive(B.Root, 100)}");

        #endregion
        #region Searator
        Console.WriteLine("*****************************************************************************");
        #endregion
        #region Delete Appluication
        B.Delete(90);
        Console.WriteLine("Inorder Traversal");
        B.InOrderTraversal(B.Root);
        Console.WriteLine();
        #endregion
        #region Searator
        Console.WriteLine("*****************************************************************************");
        #endregion
        #region Counr Application
        Console.WriteLine($"The number of element B has : {B.Count(B.Root)}");
        #endregion

        #region Searator
        Console.WriteLine("*****************************************************************************");
        #endregion
        #region Calculate Height

        Console.WriteLine($"The height of the BST B is : {B.Height(B.Root)}");
        #endregion
        #region Searator
        Console.WriteLine("*****************************************************************************");
        #endregion

        BinarySearchTree B2 = new BinarySearchTree();
        B2.Root = B2.InsertRecursion(B2.Root, 70);
        B2.InsertRecursion(B2.Root, 80);
        B2.InsertRecursion(B2.Root, 90);

        #region Traversal Application 2
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("Inorder Traversal 2");
        B2.InOrderTraversal(B2.Root);
        Console.WriteLine();

        Console.WriteLine("PreOrder Traversal B2");
        B2.PreOrderTraversal(B2.Root);
        Console.WriteLine();

        Console.WriteLine("PostOrder Traversal B2");
        B2.PostOrdertraversal(B2.Root);
        Console.WriteLine();

        Console.WriteLine("Level Order Traversal B2");
        B2.LevelOrderTraversal();
        Console.WriteLine();
        Console.WriteLine("*****************************************************************************");
        #endregion

        #region Search Element Application
        Console.WriteLine("*****************************************************************************");
        Console.WriteLine("Iterative Method");
        Console.WriteLine($"Does 50 Exist in B2? : {B2.ContainsIterative(80)}");
        Console.WriteLine($"Does 100 Exist in B2? : {B2.ContainsIterative(100)}");
        Console.WriteLine("Recursive Method");
        Console.WriteLine($"Does 50 Exist in B2? : {B2.ContainsRecursive(B2.Root, 80)}");
        Console.WriteLine($"Does 100 Exist in B2? : {B2.ContainsRecursive(B2.Root, 100)}");

        Console.WriteLine("*****************************************************************************");
        #endregion
    }
}
