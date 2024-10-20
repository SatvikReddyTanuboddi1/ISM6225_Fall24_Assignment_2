using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // This function returns the list of numbers that are missing from an array of integers
        // that contains numbers from 1 to n (where n is the length of the array)
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Mark numbers that are present by using the index
                for (int i = 0; i < nums.Length; i++)
                {
                    // Get the correct index by taking the absolute value of nums[i] and subtracting 1
                    int index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];  // Mark the number as negative to indicate it was found
                    }
                }

                List<int> result = new List<int>();
                // If the number at index i is positive, then the number i+1 is missing
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1);  // Add the missing number to the result
                    }
                }

                return result;  // Return the list of missing numbers
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        // This function sorts an array by placing all even numbers at the beginning
        // and all odd numbers at the end. It modifies the array in place.
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                // Use a two-pointer approach to place even numbers on the left and odd numbers on the right
                while (left < right)
                {
                    if (nums[left] % 2 == 0)  // If the left number is even, move left pointer to the right
                    {
                        left++;
                    }
                    else if (nums[right] % 2 == 1)  // If the right number is odd, move right pointer to the left
                    {
                        right--;
                    }
                    else
                    {
                        // If left is odd and right is even, swap them
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                        left++;
                        right--;
                    }
                }

                return nums;  // Return the sorted array
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        // This function returns the indices of two numbers in the array that add up to the target value
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Use a dictionary to store the complement (target - num) and the index of each element
                Dictionary<int, int> map = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];  // Calculate the complement

                    // If the complement exists in the map, return the indices
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }

                    // Add the current number and its index to the map
                    map[nums[i]] = i;
                }

                return new int[0];  // If no solution found, return an empty array
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        // This function finds the maximum product of three numbers in the array
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sort the array and compare the product of the three largest numbers
                // and the product of the two smallest numbers (if negative) with the largest number
                Array.Sort(nums);
                int n = nums.Length;
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        // This function converts a decimal number to its binary representation
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0";  // Handle the case for zero

                string result = "";
                while (decimalNumber > 0)
                {
                    result = (decimalNumber % 2) + result;  // Prepend the remainder to the binary string
                    decimalNumber /= 2;  // Divide by 2 to move to the next bit
                }

                return result;  // Return the binary representation
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        // This function finds the minimum element in a rotated sorted array using binary search
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                // Use binary search to find the minimum element in the rotated array
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // If the middle element is greater than the rightmost element, the minimum is in the right half
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else  // Otherwise, the minimum is in the left half
                    {
                        right = mid;
                    }
                }

                return nums[left];  // Return the minimum element
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        // This function checks whether a given integer is a palindrome
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false;  // Negative numbers are not palindromes

                int original = x;
                int reversed = 0;

                // Reverse the number by extracting the last digit and adding it to the reversed number
                while (x != 0)
                {
                    int pop = x % 10;
                    reversed = reversed * 10 + pop;
                    x /= 10;
                }

                return original == reversed;  // Check if the original number equals the reversed number
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        // This function returns the nth Fibonacci number using an iterative approach
        public static int Fibonacci(int n)
        {
            try
            {
                if (n == 0) return 0;  // Base case for F(0)
                if (n == 1) return 1;  // Base case for F(1)

                int a = 0, b = 1;

                // Use a loop to calculate Fibonacci numbers up to F(n)
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }

                return b;  // Return the nth Fibonacci number
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
