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

    // Complete the timeInWords function below.
    static string timeInWords(int h, int m) {
        var map = new []{"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "twenty one", "twenty two", "twenty three", "twenty four", "twenty five", "twenty six", "twenty seven", "twenty eight", "twenty nine"};
        string output=null;
        if(m==0)
        {
            output = $"{map[h]} o' clock";
        }
        else if(m==15)
        {
           output = $"quarter past {map[h]}" ;
        }
        else if(m==30)
        {
            output = $"half past {map[h]}" ;
        }
        else if(m==45)
        {
            output = $"quarter to {map[h+1]}";
        }
        
        else if(m==1)
        {
            output=$"{map[m]} minute past {map[h]}";
        }
        else if(m>30)
        {            
            output = $"{map[60-m]} minutes to {map[h+1]}";
        }
        else
        {
            output=$"{map[m]} minutes past {map[h]}";
        }
        return output;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        string result = timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
