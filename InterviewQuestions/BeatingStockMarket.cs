using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    // Say you have an array for which the ith element is the price of a given stock on day i.
    // If you were only permitted to buy one share of the stock and sell one share of the stock,
    // design an algorithm to find the best times to buy and sell.
    public class BeatingStockMarket
    {
        public static Tuple<int, int> Find(int[] price)
        {
            int min = int.MaxValue;
            int maxDiff = int.MinValue;
            int minIndex = -1;
            int maxIndex = -1;

            for (int i = 0; i < price.Length; i++)
            {
                if (price[i] < min)
                {
                    min = price[i];
                    minIndex = i;
                }

                int diff = price[i] - min;

                if (diff > maxDiff)
                {
                    maxIndex = i;
                    maxDiff = diff;
                }
            }

            return new Tuple<int, int>(minIndex, maxIndex);
        }
    }
}
