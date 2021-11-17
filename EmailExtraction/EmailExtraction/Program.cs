using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Callum.Feehan\OneDrive\Documents\Apprenticeship\C Sharp Bootcamp\EmailExtraction\EmailExtraction\EmailExtraction\text.txt";
            string text = File.ReadAllText(path);

            Regex rx = new Regex(@"[\.\'\%\+\-a-zA-Z0-9_]+@[\.\'\%\+\-a-zA-Z0-9_]+\.[a-zA-Z\.]+\b");

            // int count = rx.Matches(text).Count();
            MatchCollection matches = rx.Matches(text);

            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Match match in matches)
            {
                string emailEnd = match.Value;
                emailEnd = emailEnd.Substring(emailEnd.IndexOf("@"));

                if (dict.ContainsKey(emailEnd)){
                    dict[emailEnd] += 1;
                } else
                {
                    dict.Add(emailEnd, 1);
                }
            }
            foreach (KeyValuePair<string, int> pair in dict)
            {
                Console.WriteLine($"Key {pair.Key} Value {pair.Value}");
            }

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(dict.OrderByDescending(key => key.Value).ElementAt(i));
            }
        }
    }
}
