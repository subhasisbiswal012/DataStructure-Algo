class MyClass
{
    //Tell if the paranthesis are balanced or not
    public static bool Isbalanced(string str)
    {
        Stack<char> s = new Stack<char>();
        foreach(char c in str)
        {
            if(c == '(' || c == '[' || c == '{')
            {
                s.Push(c);
            }
            else if(c == ')' || c == ']' || c == '}')
            {
                if (s.Count == 0) return false; // there is no opening so no meaning of closings if there are any
                char top = s.Pop();
                if((c == '(' && top != ')') ||
                    (c == '[' && top != ']') ||
                    (c == '{' && top != '}'))
                {
                    return false;
                }

            }
        }
        return s.Count == 0;
    }
    static void Main(string[] args)
    {
        
    }

}
