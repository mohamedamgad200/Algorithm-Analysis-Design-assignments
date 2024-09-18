using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class SchoolQuizII
    {
        #region YOUR CODE IS HERE

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// find the minimum number of integers whose sum equals to ‘N’
        /// </summary>
        /// <param name="N">number given by the teacher</param>
        /// <param name="numbers">list of possible numbers given by the teacher (starting by 1)</param>
        /// <returns>minimum number of integers whose sum equals to ‘N’</returns>
        static public int SolveValue(int N, int[] numbers)
        {
            int[] dp = new int[N + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                for (int i = 1; i <= N; i++)
                {
                    if (i >= numbers[j])
                    {
                        dp[i] = Math.Min(dp[i], dp[i - numbers[j]] + 1);
                    }
                }
            }
            return dp[N];
        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>the numbers themselves whose sum equals to ‘N’</returns>
        static public int[] ConstructSolution(int N, int[] numbers)
        {
            int[] dp = new int[N + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                for (int i = 1; i <= N; i++)
                {
                    if (i >= numbers[j])
                    {
                        dp[i] = Math.Min(dp[i], dp[i - numbers[j]] + 1);
                    }
                }
            }
            List<int> result = new List<int>();
            int k = N;
            while (k > 0)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (k >= numbers[j] && dp[k - numbers[j]] == dp[k] - 1)
                    {
                        result.Add(numbers[j]);
                        k -= numbers[j];
                        break;
                    }
                }
            }
            return result.ToArray();
        }
        #endregion

        #endregion
    }
}
