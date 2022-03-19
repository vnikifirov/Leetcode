using System;
using System.Collections.Generic;

namespace ValidateStackSequences
{

    /*
        Given two integer arrays pushed and popped each with distinct values, return true if this could have been the result
        of a sequence of push and pop operations on an initially empty stack, or false otherwise.

        Example 1:

        Input: pushed = [1,2,3,4,5], popped = [4,5,3,2,1]
        Output: true
        Explanation: We might do the following sequence:
        push(1), push(2), push(3), push(4),
        pop() -> 4,
        push(5),
        pop() -> 5, pop() -> 3, pop() -> 2, pop() -> 1
        Example 2:

        Input: pushed = [1,2], popped = [1,2] 
        Output: false
        Explanation: 1 cannot be popped before 2.
 

        Constraints:

        1 <= pushed.length <= 1000
        0 <= pushed[i] <= 1000
        All the elements of pushed are unique.
        popped.length == pushed.length
        popped is a permutation of pushed. 
    
     */

    class Program
    {
        static void Main(string[] args)
        {
            var pushed = new int[] { 1, 2, 3, 4, 5 }; 
            var popped = new int[] { 4, 5, 3, 2, 1 };

            var pushedSecond = new[] { 1, 2, 3, 4, 5 };
            var poppedSecond = new[] { 4, 3, 5, 1, 2 };

            var result = StackValidator.ValidateStackSequences(pushed, popped);
            var resultSecond = StackValidator.ValidateStackSequences(pushedSecond, poppedSecond);

            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Result: {resultSecond}");
            Console.ReadKey();
        }
    }

    public class StackValidator
    {
        public static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            /*
            if (!(pushed.Length >= 1 && pushed.Length <= 1000))        
                return false;

            if(!(popped.Length >= 1 && popped.Length <= 1000))
                return false;

            if (pushed.Length != popped.Length)
                return false;
            */

            // LIFO
            // Space complicity O(N)
            var stack = new Stack<int>();
            int j = 0;
            // Time complicity O(N)
            for (int i = 0; i < pushed.Length; i++)
            {
                stack.Push(pushed[i]);
                // Time complicity O(N)
                while (j < popped.Length)
                {
                    if (stack.Count > 0 && stack.Peek() == popped[j])
                    {
                        j++;
                        stack.Pop();
                    }
                    else
                    {
                        break;
                    }
                }

                // stack -> 1, 2
                // popped -> 2, 1
            }

            // Space complicity O(N), Time complicity O(N^2)
            return stack.Count == 0;
        }
    }
}
