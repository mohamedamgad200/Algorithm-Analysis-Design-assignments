using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.WebRequestMethods;
namespace Problem
{
    // ***********************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // ***********************************
    public static class IntegerMultiplication
    {
        #region YOUR CODE IS HERE

        //Your Code is Here:
        //==================
        /// <summary>
        /// Multiply 2 large integers of N digits in an efficient way [Karatsuba's Method]
        /// </summary>
        /// <param name="X">First large integer of N digits [0: least significant digit, N-1: most signif. dig.]</param>
        /// <param name="Y">Second large integer of N digits [0: least significant digit, N-1: most signif. dig.]</param>
        /// <param name="N">Number of digits (power of 2)</param>
        /// <returns>Resulting large integer of 2xN digits (left padded with 0's if necessarily) [0: least signif., 2xN-1: most signif.]</returns>
        static public byte[] IntegerMultiply(byte[] X, byte[] Y, int N)
        {
            byte[] res = new byte[N];
            Parallel.Invoke(() => res = IntegerMultiplykaraskuba(X, Y, N));
            Array.Resize(ref res, 2 * N);
            return res;


        }

        static public byte[] IntegerMultiplykaraskuba(byte[] X, byte[] Y, int N)
        {
            // basecase using naive solution to reduce the time
            if (N <= 32)
            {
                return IntegerMultiplystandaredmultiply(X, Y, N);
            }

            else
            {
                //if n is odd resize it
                //198===0198
                if (N % 2 != 0)
                {
                    Array.Resize(ref X, X.Length + 1);
                    Array.Resize(ref Y, Y.Length + 1);
                    N++;
                }
                //divide
                // half the x and y to A,B,c and d;
                //split X & Y into two halves: A & B, C & D.
                int half = N / 2;
                byte[] A = new byte[half];
                byte[] B = new byte[half];
                byte[] C = new byte[half];
                byte[] D = new byte[half];
                int o = 0;
                //copy array
                while (o < half)
                {
                    A[o] = X[o];
                    B[o] = X[half + o];
                    C[o] = Y[o];
                    D[o] = Y[o + half];
                    o++;
                }
                byte[] mo23 = new byte[2 * N];
                byte[] me2 = new byte[2 * N];
                byte[] mo1 = new byte[2 * N];
                //Calculate A+B & C+D
                byte[] AplusB = Add(A, B);
                byte[] CplusD = Add(C, D);
                byte[] M1 = new byte[half];
                byte[] M2 = new byte[half];
                byte[] Z_Z_Z;
                int flag = 0;
                int flag3may = 0;
                //conquer
                Parallel.Invoke(() => M1 = IntegerMultiplykaraskuba(A, C, half),
                               () => M2 = IntegerMultiplykaraskuba(B, D, half));
                byte[] addtion = Add(M1, M2);
                if (true)
                {
                    if (CplusD.Length > half || AplusB.Length > half) { flag = 1; }
                    if (flag == 1) { int moha = (AplusB.Length > CplusD.Length) ? AplusB.Length : CplusD.Length; Array.Resize(ref AplusB, moha); Array.Resize(ref CplusD, moha); Z_Z_Z = IntegerMultiplykaraskuba(AplusB, CplusD, moha); }
                    else { Z_Z_Z = IntegerMultiplykaraskuba(AplusB, CplusD, half); }
                }
                int mo = 0;
                int so = 0;
                int el3ab = 0;
                //Subtract M1 & M2 from Z
                //combine
                Z_Z_Z = Subtract(Z_Z_Z, addtion);
                while (mo < M1.Length) { mo23[mo] = M1[mo]; mo++; }
                while (so < Z_Z_Z.Length) { mo1[so + N / 2] = Z_Z_Z[so]; so++; }
                //Add 2 & 3    
                mo23 = Add(mo23, mo1);
                while (el3ab < M2.Length) { me2[el3ab + N] = M2[el3ab]; el3ab++; }
                //Add 2 & 3
                mo23 = Add(mo23, me2);
                //delete aditional zeros 
                int flagfarag = 0;
                if (mo23[mo23.Length - 1] == 0) { flagfarag = 1; }
                if (flagfarag == 1)
                {
                    int combolarge = 0;
                    int n = mo23.Length - 1;
                    int temp = mo23.Length - 1;
                    while (temp > 0)
                    {
                        if (combolarge > 0) break;
                        if (mo23[temp] == 0) Array.Resize(ref mo23, mo23.Length - 1);
                        else combolarge++;
                        temp--;
                    }
                }
                return mo23;
            }
        }
        //add functon
        static byte[] Add(byte[] X, byte[] Y)
        {
            int kingofalgorihm = 0;
            int carryup = 0;
            //size of largest one
            int N = (X.Length > Y.Length) ? X.Length : Y.Length;
            byte[] resultofsum = new byte[N];
            //add two array
            while (kingofalgorihm < N)
            {
                int summ3am = carryup;
                summ3am = carryup + (kingofalgorihm < X.Length ? X[kingofalgorihm] : 0) + (kingofalgorihm < Y.Length ? Y[kingofalgorihm] : 0);
                resultofsum[kingofalgorihm] = (byte)(summ3am % 10);
                carryup = summ3am / 10;
                kingofalgorihm++;
            }
            // add carry to 
            if (carryup > 0) { Array.Resize(ref resultofsum, resultofsum.Length + 1); resultofsum[resultofsum.Length - 1] = (byte)carryup; }
            return resultofsum;
        }
        //sub function
        public static byte[] Subtract(byte[] X, byte[] Y)
        {
            byte m1;
            byte m2;
            byte reminder = 0;
            int apolo = 0;
            int tarh = 0;
            int N = (X.Length > Y.Length) ? X.Length : Y.Length;
            byte[] result = new byte[N];
            while (apolo < N)
            {
                m1 = (apolo < X.Length) ? (X[apolo]) : (byte)0;
                m2 = (apolo < Y.Length) ? (Y[apolo]) : (byte)0;
                tarh = m1 - m2 - reminder;
                result[apolo] = (byte)(m1 < m2 + reminder ? 10 + tarh : tarh);
                reminder = m1 < m2 + reminder ? (byte)1 : (byte)0;
                apolo++;
            }

            return result;

        }
        static public byte[] IntegerMultiplystandaredmultiply(byte[] X, byte[] Y, int N)
        {
            int m1 = X.Length;
            int m2 = Y.Length;
            byte[] resulte = new byte[2 * N];
            int h1 = 0;
            int p;
            int carry = 0;
            // Multiply each digit of X with each digit of Y
            for (int i = 0; i < m1; i++)
            {
                carry = 0;
                for (int j = 0; j < m2; j++)
                {
                    p = X[i] * Y[j] + carry + resulte[i + j];
                    carry = p / 10;
                    resulte[i + j] = (byte)(p % 10);
                }
                if (carry > 0)
                {
                    resulte[i + m2] += (byte)carry;
                }
            }
            return resulte;
        }

    }
    #endregion
}


