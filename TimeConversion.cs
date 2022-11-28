using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    /*
     * Complete the timeConversion function below.
     */
    static string timeConversion(string s) {
        /*
         * Write your code here.
         */
         var stringArray = s.Split(':');
         if(s.Contains("PM")&& stringArray[0] != "12")
         {
             var hour = int.Parse(stringArray[0]);
             var rest = s.Substring(2,6);
             return $"{(hour+12)}{rest}";
         }
         if(s.Contains("AM") && stringArray[0] == "12")
         {
             var rest = s.Substring(2,6);
             return $"00{rest}";
         }
          
         return s.Substring(0,8);

    }

    static void Main(string[] args) {
        TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = timeConversion(s);

        tw.WriteLine(result);

        tw.Flush();
        tw.Close();
    }
}
