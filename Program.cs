using System;
using System.Text.RegularExpressions;

namespace foo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ^[\w,&\- ]+$
            // https://www.w3.org/TR/xsd-unicode-blocknames/
            // \p{IsBasicLatin}
            string[] groups = 
            {
                @"A-Za-z",                  // letters
                @"0-9",                     // digits
                @"&.,\- ",                  // selected punctuation
                @"\p{IsLatin-1Supplement}"  // Sigur Rós and more - https://en.wikipedia.org/wiki/Latin-1_Supplement_(Unicode_block)
            };
            string pattern = "^[" + string.Join("", groups) + "]+$";
            string[] names = { "alpha", "Pink Floyd", "Sigur Rós", "Stone Temple Pilots", "Angus & Foo", "ABBA", "Aaa, Bbb", "123", "aa-bb", "aa<bb" };

            foreach (string name in names)
            {
                Console.WriteLine(name + " - " + Regex.Matches(name, pattern).Count.ToString());
            }
        }
    }
}
