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

    // Complete the dayOfProgrammer function below.
    static string dayOfProgrammer(int year) {
        var sumForLeapTillAug = 244;
        var sumTillAug = 243; 
        var programmerDay=256;
        var missingDays = 13;
        if(year>=1700 && year<1918 && year%4==0)
        {
            return $"{programmerDay-sumForLeapTillAug}.09.{year}";
        }
        if(year>1918 && year<=2700 && IsYearLeap(year))
        {
            return $"{programmerDay-sumForLeapTillAug}.09.{year}";
        }
        if(year == 1918)
        {
            return $"{programmerDay-sumForLeapTillAug+missingDays+1}.09.{year}";
        }
        return $"{programmerDay-sumTillAug}.09.{year}";
    }
    
    private static bool IsYearLeap(int year)
    {
        return (year%400 == 0 || (year%4==0 && year%100 !=0));
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
