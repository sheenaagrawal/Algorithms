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

    // Complete the breakingRecords function below.
    static int[] breakingRecords(int[] scores) {

        var minIndex = scores[0];
        var maxIndex = scores[0];
        var minTimes = 0;
        var maxTimes = 0;
        var i=0;
        while(i<scores.Length)
        {
            if(scores[i]>maxIndex)
            {
                maxIndex = scores[i];
                maxTimes++;
            }
            else if(scores[i]< minIndex)
            {
                minIndex = scores[i];
                minTimes++;
            }
            i++;
        }
        return new[]{maxTimes, minTimes};
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
        ;
        int[] result = breakingRecords(scores);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
