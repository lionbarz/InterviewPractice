using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Other
{
    public class EnglishDictionary
    {
        private static readonly HashSet<string> dict = new HashSet<string>()
        {
            "CAT",
            "CATS",
            "CRIME",
            "CRIMES",
            "CREST",
            "EAT",
            "EATS",
            "MEAT",
            "MEATS",
            "MUST",
            "REST",
            "SEA",
            "SEAT",
            "SUM",
        };

        public static bool IsWord(string s)
        {
            return dict.Contains(s);
        }
    }
}
