﻿/*
Problem Statement
You are given two s: N and K. Lun the dog is interested in strings that satisfy the following conditions:

The string has exactly N characters, each of which is either 'A' or 'B'.
The string s has exactly K pairs (i, j) (0 <= i < j <= N-1) such that s[i] = 'A' and s[j] = 'B'.
If there exists a string that satisfies the conditions, find and return any such string. Otherwise, return an empty string.

Definition
Class: AB
Method: createString
Parameters: int, int
Returns: string
Method signature: string createString(int N, int K)
(be sure your method is public)
Limits
Time limit (s): 2.000
Memory limit (MB): 256
Constraints
- N will be between 2 and 50, inclusive.
- K will be between 0 and N(N-1)/2, inclusive.
Examples
0)
3
2
Returns: "ABB"
This string has exactly two pairs (i, j) mentioned in the statement: (0, 1) and (0, 2).
1)
2
0
Returns: "BA"
Please note that there are valid test cases with K = 0.
2)
5
8
Returns: ""
Five characters is too short for this value of K.
3)
10
12
Returns: "BAABBABAAB"
*/
using System;
using System.Text;

namespace Algo.TopCoder.Easy
{
    public class AB
    {
        public string CreateString(int n, int k)
        {
            int numA = n / 2;
            int numB = n - numA;

            if (k > numA * numB)
            {
                return string.Empty;
            }

            int[] weights = new int[numA];

            for (int i = 0; i < numA; i++)
            {
                weights[i] = i + (numB - Math.Min(k, numB));
                k -= numB;
            }

            StringBuilder b = new StringBuilder();

            for (int i = 0; i < numB; i++)
            {
                b.Append('B');
            }

            for (int i = 0; i < numA; i++)
            {
                b.Insert(Math.Min(weights[i], b.Length), 'A');
            }

            return b.ToString();
        }
    }
}
