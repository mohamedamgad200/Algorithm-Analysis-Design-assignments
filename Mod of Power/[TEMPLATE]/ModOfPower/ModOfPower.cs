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
    public static class ModOfPow
    {
        public static long ModOfPower(long B, long P, long M)
         {
            /* Divide & Conquer
             * divide p into sub problem
             * Conquer recursively solve one sub problem pf Bpower p/2 mod M
             * combine if p is even muliply Bpower p/2 mod m in Bpower p/2 mod m and  mod this multiply with m
                        if p is odd  muliply Bpower p/2 mod m in Bpower p/2 mod m and in B and  mod this multiply with m
                     this solution same naive solution T(n)=2T(N/2)+O(1)====>o(N)
              we can make a trick make that [Bpower P mod m]==result multiply result*result instead of muliply Bpower p/2 mod m in Bpower p/2 mod m
                  T(n)=T(N/2)+O(1)====>o(log(N))
             */
            //Base case
            if (P == 0)
            {
                return 1;
            }   
            //divide and conquer
            long result = ModOfPower(B, P/ 2, M) % M;
            long result2=(long)Math.Pow(result, 2);
            result = (result*result) % M;
            //combine
            if (P % 2 != 0)
            {
                result = (result* B) % M;
            }

            return result;


        }
    }
    
}
