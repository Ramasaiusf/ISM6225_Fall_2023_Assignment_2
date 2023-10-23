/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Handle null input by returning an empty list 
                if (nums == null)
                    return new List<IList<int>>();
                // Initialize a list to store integer ranges.
                IList<IList<int>> missingRanges = new List<IList<int>>();
                int index = 0; // Initialize an index variable to traverse the 'nums' array.
                // Check if the 'lower' bound is less than or equal to the first element in the 'nums' array minus 1.
                if (lower < nums[0])
                    missingRanges.Add(new List<int> { lower, nums[0] - 1 }); // Add a range from 'lower' to 'nums[0] - 1'.
                // Iterate through the 'nums' array to find and add missing ranges.
                for (index = 0; index < nums.Length - 1; index++)
                {
                    int current = nums[index];
                    int next = nums[index + 1];
                    // Check if there is a gap between 'current + 1' and 'next - 1'.
                    if (current + 1 < next)
                        missingRanges.Add(new List<int> { current + 1, next - 1 }); // Add the gap as a range.
                }
                // Check if there is a gap between the last element in 'nums' and the 'upper' bound.
                if (nums.Length > 0 && nums[index] < upper)
                    missingRanges.Add(new List<int> { nums[index] + 1, upper }); // Add a range from 'nums[index] + 1' to 'upper'.
                return missingRanges; // Return the list of missing integer ranges.
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*

        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.

        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Define a dictionary to store matching brackets
                Dictionary<char, char> brackets = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };
                // Initialize the opener index as -1
                int opener = -1;
                // Iterate through the characters in the input string
                for (int i = 0; i < s.Length; i++)
                {
                    // If the current character is an opening bracket, update the opener index
                    if (brackets.ContainsKey(s[i]))
                        opener = i;
                    // If the current character is a closing bracket and there is a corresponding opening bracket
                    else if (opener >= 0 && s[i] == brackets[s[opener]])
                    {
                        int remaining = 0;
                        opener -= 1;
                        // Continue searching for matching opening brackets
                        while (opener >= 0 && remaining < 1)
                        {
                            // If an opening bracket is found, increment the remaining count
                            if (brackets.ContainsKey(s[opener]))
                            {
                                remaining += 1;
                                // If there are extra opening brackets, keep moving back in the string
                                if (remaining < 1)
                                    opener -= 1;
                            }
                            else
                            {
                                // If a closing bracket is found, decrement the remaining count
                                remaining -= 1;
                                opener -= 1;
                            }
                        }
                        // Check if there are unmatched brackets
                        if (opener == -1 && remaining != 0)
                            return false;
                        // Check if there are unmatched brackets within the current range
                        if (opener >= 0 && remaining != 1)
                            return false;
                    }
                    else
                        return false;
                }
                // Check if all brackets are matched
                return opener == -1;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initialize variables to track the minimum price and maximum profit
                int minPrice = int.MaxValue;
                int maxProfit = 0;
                if (prices.Length == 0)
                    return 0; // Handle the case of an empty array gracefully by returning 0 profit.                
                // Iterate through the prices array
                for (int i = 0; i < prices.Length; i++)
                {
                    // If the current price is lower than the previously recorded minimum price, update the minimum price
                    if (prices[i] < minPrice)
                        minPrice = prices[i];
                    else
                    {
                        // Calculate the current profit and update the maximum profit if needed
                        int current = prices[i] - minPrice;
                        maxProfit = Math.Max(maxProfit, current);
                    }
                }
                // Return the maximum profit
                return maxProfit;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                if (s == null)
                    // Handle null strings by returning false 
                    return false;                
                // Initialize two pointers, 'left' and 'right,' to check characters from the beginning and end of the string.
                int left = 0;
                int right = s.Length - 1;
                // Define pairs of strobogrammatic characters. A strobogrammatic pair reads the same when rotated 180 degrees.
                string pairs = "00 11 88 69 96";
                // Iterate while the 'left' pointer is less than or equal to the 'right' pointer.
                while (left <= right)
                {
                    char leftChar = s[left];
                    char rightChar = s[right];
                    // Check if the pair of characters formed by 'leftChar' and 'rightChar' is a valid strobogrammatic pair.
                    if (!pairs.Contains($"{leftChar}{rightChar}"))
                        return false;
                    // Move the pointers towards each other.
                    left++;
                    right--;
                }
                // If the loop completes without returning false, the input string is strobogrammatic.
                return true;               
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Check if the input array is null or empty.
                if (nums == null || nums.Length == 0)
                {
                    // Handle the case where the input is null or empty by returning 0 pairs.
                    return 0;
                }
                // Initialize a dictionary to store the count of each number.
                Dictionary<int, int> count = new Dictionary<int, int>();
                // Initialize a variable to track the count of identical pairs.
                int pairs = 0;
                // Iterate through the input array 'nums.'
                foreach (int num in nums)
                {
                    // If the number already exists in the 'count' dictionary, increment the 'pairs' count by the
                    // value stored for that number and then increment the count for that number.
                    if (count.ContainsKey(num))
                    {
                        pairs += count[num];
                        count[num]++;
                    }
                    else
                    {
                        // If the number is not in the dictionary, add it with a count of 1.
                        count[num] = 1;
                    }
                }
                // Return the total count of identical pairs.
                return pairs;                               
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Check if the input array is null
                if (nums == null)                
                    // Handle the case of a null input by returning a default value (e.g., -1).
                    return -1;                
                // Sort the 'nums' array in descending order
                Array.Sort(nums);
                Array.Reverse(nums);
                int distinctCount = 0;
                int? thirdMax = null;
                // Iterate through the sorted array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Check if the current number is distinct (not equal to the previous number)
                    if (i == 0 || nums[i] != nums[i - 1])
                        distinctCount++;
                    // If we find the third distinct number, store it and exit the loop
                    if (distinctCount == 3)
                    {
                        thirdMax = nums[i];
                        break;
                    }
                }
                // If the thirdMax variable is still null, return the maximum number (the first element in the sorted array)
                return thirdMax ?? nums[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                if (currentState == null)
                    // Handle null input by returning an empty list (assumption: null input should result in an empty list).
                    return new List<string>();
                List<string> OutputList = new List<string>();
                int n = currentState.Length;
                // Iterate through the string to find possible moves
                for (int i = 0; i < n - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a new string with the "++" replaced by "--"
                        char[] newState = currentState.ToCharArray();
                        newState[i] = '-';
                        newState[i + 1] = '-';
                        OutputList.Add(new string(newState));
                    }
                }
                // Return the list of possible next moves
                return OutputList;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            if (s == null)
                // Handle null input by returning an empty string (assumption: null input should result in an empty string).
                return string.Empty;
            // Initialize a StringBuilder to build the output string
            StringBuilder output = new StringBuilder(s.Length);
            // Iterate through the characters in the input string
            foreach (char c in s)
            {
                // Check if the current character is not a vowel (both uppercase and lowercase)
                if ("AEIOUaeiou".IndexOf(c) == -1)
                    output.Append(c);  // Append the character to the output if it's not a vowel
            }
            // Convert the StringBuilder to a string and return the result
            return output.ToString();            
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
