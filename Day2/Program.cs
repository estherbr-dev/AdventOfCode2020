using System;
using System.Collections;
using System.Collections.Generic;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s_input = System.IO.File.ReadAllLines(@"C:\AdventOfCode\Day2\Input.txt");
            List<RuleAndPasswords> l_ruleAndPasswords = new List<RuleAndPasswords>();
            int i_result1 = 0;
            int i_result2 = 0;

            foreach(string s_line in s_input)//We parse the data to have an easier access to it
            {
                string[] s_subs = s_line.Split(':');

                RuleAndPasswords rap = new RuleAndPasswords();
                rap.s_password = s_subs[1].Trim();

                string[] s_subs2 = s_subs[0].Split(' ');
                rap.c_neededChar = s_subs2[1].ToCharArray()[0];
                
                string[] s_sub3 = (s_subs2[0].Trim()).Split('-');
                rap.i_minChar = Int32.Parse(s_sub3[0]);
                rap.i_maxChar = Int32.Parse(s_sub3[1]);
                
                l_ruleAndPasswords.Add(rap);

                //Console.WriteLine("the password is {0} and the char is {1} and the min {2} max {3} location", rap.s_password, rap.c_neededChar, rap.i_minChar, rap.i_maxChar);
            }

            foreach(RuleAndPasswords p in l_ruleAndPasswords)//We check if the passwords are okay considering question 1
            {
                int countChars = 0;
                
                foreach(Char c in p.s_password)
                {
                    if(c == p.c_neededChar)
                    {
                        countChars++;
                    }
                }

                if(countChars >= p.i_minChar && countChars <= p.i_maxChar)
                {
                    i_result1 ++;
                }
            }
            Console.WriteLine("The result for question 1 is {0}", i_result1);

            foreach(RuleAndPasswords p in l_ruleAndPasswords)
            {
                int countChars = 0;
                if(p.s_password.Length >=  p.i_minChar)
                {
                    if(p.s_password[p.i_minChar-1] == p.c_neededChar)
                    {
                        countChars ++;
                    }
                }
                if(p.s_password.Length >=  p.i_maxChar)
                {
                    if(p.s_password[p.i_maxChar-1] == p.c_neededChar)
                    {
                        countChars ++;
                    }
                }
                if(countChars == 1)
                {
                    i_result2 ++;
                }
            }
            Console.WriteLine("The result for question 2 is {0}", i_result2);
        }
    }

    public class RuleAndPasswords
    {
        public string s_password {get;set;}
        public int i_minChar {get;set;}
        public int i_maxChar{get;set;}
        public char c_neededChar{get;set;}

        public RuleAndPasswords()
        {
            s_password = "";
            i_minChar = 0;
            i_maxChar = 0;
            c_neededChar = ' ';
        }

        public RuleAndPasswords(string password, int minChar, int maxChar, char neededChar)
        {
            s_password = password;
            i_minChar = minChar;
            i_maxChar = maxChar;
            c_neededChar = neededChar;
        }
    }
}
