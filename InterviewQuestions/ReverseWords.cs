using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    // Write a function to reverse the order of words in a string in place.
    // "A cat ran." => "ran cat A."
    // "Balls to the wall." => "wall the to Balls."
    // "Hi, Mo, how are you?" => "you, are, how Mo Hi?"
    public class ReverseWords
    {
        private const char PlaceholderToken = '#';

        // Handles characters and any other character except '#' which is reserved.
        public static string Reverse(string s)
        {
            LinkedList<string> stack = new LinkedList<string>();
            StringBuilder placeholders = new StringBuilder();
            StringBuilder word = new StringBuilder();

            foreach (char c in s)
            {
                if (IsLetter(c))
                {
                    word.Append(c);
                }
                else
                {
                    if (word.Length > 0)
                    {
                        stack.AddLast(word.ToString());
                        word.Clear();
                        placeholders.Append(ReverseWords.PlaceholderToken);
                    }

                    placeholders.Append(c);
                }
            }

            if (word.Length > 0)
            {
                stack.AddLast(word.ToString());
                word.Clear();
                placeholders.Append(ReverseWords.PlaceholderToken);
            }

            StringBuilder rval = new StringBuilder();

            foreach(char c in placeholders.ToString())
            {
                if (c == ReverseWords.PlaceholderToken)
                {
                    rval.Append(stack.Last());
                    stack.RemoveLast();
                }
                else
                {
                    rval.Append(c);
                }
            }

            return rval.ToString();
        }

        // Just does characters and spaces.
        public static string ReverseInPlace(string s)
        {
            StringBuilder newString = new StringBuilder(s);

            // Reverse the entire string by swapping first char with last, etc.
            // "Mo Man" => "naM oM"
            ReverseWords.ReverseStringInPlace(newString, 0, newString.Length);

            // Reverse words within spaces.
            int lastSpace = -1;

            for (int i=0; i < newString.Length; i++)
            {
                if (newString[i] == ' ')
                {
                    ReverseWords.ReverseStringInPlace(newString, lastSpace + 1, i);
                    lastSpace = i;
                }
            }

            if (newString[newString.Length - 1] != ' ')
            {
                ReverseWords.ReverseStringInPlace(newString, lastSpace + 1, newString.Length);
            }

            return newString.ToString();
        }

        private static bool IsLetter(char c)
        {
            return ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'));
        }

        // i and j must be pointing to the beginning of the word and the space after.
        private static void ReverseStringInPlace(StringBuilder s, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            for (int k = 0; k < (j - i) / 2; k++)
            {
                char temp = s[i + k];
                s[i + k] = s[j - 1 - k];
                s[j - 1 - k] = temp;
            }
        }
    }
}
