using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the miniMaxSum function below.
    static void miniMaxSum(long[] arr) {
        long sum=0;
        long min=arr.First();
        long max=arr.First();
        foreach(long member in arr)
        {
            if(member<min)
            {
                min = member;
            }
            if(member>max)
            {
                max= member;
            }
            sum +=member;
        }
        Console.WriteLine($"{sum-max} {sum-min}");

    }

    static void Main(string[] args) {
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp))
        ;
        miniMaxSum(arr);
    }
}
