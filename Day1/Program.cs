using System;
using System.Net;
using System.IO;

namespace Day1
{
    class Program
    {   
        static void Main()
        {
            string[] s_inputLines = System.IO.File.ReadAllLines(@"F:\GitHub\AdventOfCode2020\Day1\Input.txt");
            int i_result1 = 0;
            int i_result2 = 0;

            foreach (string s_line1 in s_inputLines)
            {
                foreach (string s_line2 in s_inputLines)
                {
                    int value1 = Int32.Parse(s_line1);
                    int value2 = Int32.Parse(s_line2);
                    if(value1+value2 == 2020)
                    {
                        i_result1 = value1*value2;
                    }
                    foreach (string s_line3 in s_inputLines)
                    {
                        int value3 = Int32.Parse(s_line3);
                        if(value1+value2+value3 == 2020)
                        {
                            i_result2 = value1*value2*value3;
                        }
                    }
                }
            }

            Console.WriteLine("The answer for question 1 is = {0}", i_result1);
            Console.WriteLine("The answer for question 2 is = {0}", i_result2);
        }
    }
}
