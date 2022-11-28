using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var a = Int32.Parse(Console.ReadLine());
        for(int i =0 ; i<a ; i++)
        {
            var isPrime = true;
            var c = Int32.Parse(Console.ReadLine());
            if(c < 2)
            {
                isPrime = false;
            }
            
            for(int j = 2; j*j<=c; j++)
            {
                if(c % j == 0)
                {
                    isPrime = false;
                    break;
                }
                
            }
            if(isPrime)
            {
                Console.WriteLine("Prime");
            }
            else Console.WriteLine("Not prime");
        }
    }
}
