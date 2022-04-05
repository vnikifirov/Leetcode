using System;

namespace BinarySearchAlgo
{
    /// Task desc
    /// Given an array of integers nums which is sorted in ascending order, and an integer target,
    /// write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
    /// You must write an algorithm with O(log n) runtime complexity.
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1:
            var firstNums = new int[]{ -1, 0, 3, 5, 9, 12 };
            var frirstTarget = 9;
            var caseOneExpected = 4;

            var firstResult = BinarySearch.Search(firstNums, frirstTarget);

            Console.WriteLine($"My own Algo Bin Search result is 4: {firstResult == caseOneExpected}");

            var secondResult = Array.BinarySearch(firstNums, frirstTarget);

            Console.WriteLine($"Default Algo Bin Search result is 4: {secondResult == caseOneExpected}");

            // Example 1:
            var secondNums = new int[] { 1, 3, 5, 6 };
            var secondTarget = 5;
            var caseTwoExpected = 2;

            var thirdResult = BinarySearch.SearchInsert(secondNums, secondTarget);

            Console.WriteLine($"My own Algo SearchInsert result is 2: {thirdResult == caseTwoExpected}");

            // Example 2:
            var thirdNums = new int[] { 1, 3, 5, 6 };
            var thirdTarget = 2;
            var caseThreeExpected = 1;

            var fourthResult = BinarySearch.SearchInsert(thirdNums, thirdTarget);

            Console.WriteLine($"My own Algo SearchInsert result is 1: {fourthResult == caseThreeExpected}");

            Console.ReadKey();
        }
    }

    public class BinarySearch
    {
        public static int Search(int[] nums, int target)
        {
            int left = default(int);
            int right = nums.Length - 1;
            int middle;

            // O(log n)
            while (left <= right)
            {
                // n / 2^k = 1 => k = log 2 n
                middle = (right + left) / 2;

                if (nums[middle] == target)      
                    return middle;

                if (nums[middle] > target)
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }

        /// <summary>
        /// Return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        /// </summary>
        /// <param name="nums">Your array</param>
        /// <param name="target">Your numbet that you'd like to find</param>
        /// <return>Best case: O(log n) Worst case: O(n)</return>>
        public static int SearchInsert(int[] nums, int target)
        {
            // O(log n)
            var result = Array.BinarySearch(nums, target);

            if (result >= 0)
               return result;

            // O(n)
            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] > target)
                    return index;
            }

            // O(1)
            return nums.Length;
        }

        public static int RotatedSearch(int[] nums, int target)
        {
            return Array.FindIndex(nums, x => x == target);
        }
    }
}
