using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace VerifyingAlienDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstCaseWords = new string[] { "hello", "leetcode" };
            var firstCaseOrder = "hlabcdefgijkmnopqrstuvwxyz";
            var firstCaseExpected = true;

            var firstCaseIsSorted = VerifyingDictionaryAlien.IsAlienSorted(firstCaseWords, firstCaseOrder);

            var secondCaseWords = new string[] { "apple", "app" };
            var secondCaseOrder = "abcdefghijklmnopqrstuvwxyz";
            var secondCaseExpected = false;

            var secondCaseIsSorted = VerifyingDictionaryAlien.IsAlienSorted(secondCaseWords, secondCaseOrder);

            Console.WriteLine($"First case is sorted: {firstCaseExpected == firstCaseIsSorted}");
            Console.WriteLine($"Second case is sorted: {secondCaseExpected != secondCaseIsSorted}");

            Console.ReadKey();
        }
    }

    public class AlienComparer : IComparer<string>
    {
        private string _order;
        private Dictionary<char, int> _weightOfwords;

        public AlienComparer(string order)
        {
            _order = order;

            // O(1) because alpha is limited 
            int counterWords = 0;
            _weightOfwords = _order.ToDictionary(key => key, key => counterWords++);

            // O(1) because alpha is limited 
            //_weightOfwords = _order.ToDictionary(key => key, key => order
            //    .ToList() // O(N)
            //    .FindIndex(x => x == key)); // O(log N)
        }

        public int Compare([AllowNull] string x, [AllowNull] string y)
        {
            if (x == y)
                return 0;

            // O(M) where M is length of word
            for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
            {
                if (x[i] != y[i])
                    return _weightOfwords[x[i]] < _weightOfwords[y[i]] ? -1 : 1;
            }

            return x.Length < y.Length ? -1 : 1;
        }
    }

    public class VerifyingDictionaryAlien
    {
        // Return => O(N log N)
        public static bool IsAlienSorted(string[] words, string order)
        {
            // A, B, C, D ...
            // Be
            // Deal
            // Call
            // Alphabet
            // Asorting => ASC

            // O(N log N)
            var sortedWords = words.OrderBy(x => x, new AlienComparer(order));
            // For SequenceEqual -> O(N)
            return Enumerable.SequenceEqual(words, sortedWords);
        }
    }
}
