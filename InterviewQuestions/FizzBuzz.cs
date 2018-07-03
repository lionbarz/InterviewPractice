using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class FizzBuzz
    {
        public IList<string> DoIt()
        {
            const int capacity = 100;

            List<string> result = new List<string>(capacity);
            
            for (int i=1; i<= capacity; i++)
            {
                bool fizz = IsMultiple(i, 3);
                bool buzz = IsMultiple(i, 5);

                string val = null;

                if (fizz && buzz)
                {
                    val = "FizzBuzz";
                }
                else if (fizz)
                {
                    val = "Fizz";
                }
                else if (buzz)
                {
                    val = "Buzz";
                }
                else
                {
                    val = i.ToString();
                }

                result.Add(val);
            }

            return result;
        }

        private bool IsMultiple(int number, int multiple)
        {
            return (number % multiple) == 0;
        }
    }
}
