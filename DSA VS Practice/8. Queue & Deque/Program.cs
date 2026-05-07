using System;
using System.Collections.Generic;

class Program
{

    //First Non-Repeating Character in a Stream
    static void FirstNonRepeating(string stream)
    {
        Queue<char> queue = new Queue<char>();

        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char ch in stream)
        {
            // Increase frequency
            if (freq.ContainsKey(ch))
                freq[ch]++;
            else
                freq[ch] = 1;

            // Add to queue
            queue.Enqueue(ch);

            // Remove repeating chars from front
            while (queue.Count > 0 && freq[queue.Peek()] > 1)
            {
                queue.Dequeue();
            }

            // Print answer
            if (queue.Count > 0)
                Console.Write(queue.Peek());
            else
                Console.Write("#");
        }
    }

    static void Main()
    {
        string stream = "aabc";

        FirstNonRepeating(stream);
    }
}