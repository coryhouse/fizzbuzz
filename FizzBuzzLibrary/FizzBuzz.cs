using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzLibrary
{
    public class FizzBuzz
    {
        public string Calculate(Range<int> range, List<FizzBuzzNumber> fizzBuzzNumbers)
        {
            var counter = range.Minimum;

            var sb = new StringBuilder();

            while (counter <= range.Maximum)
            {
                sb.Append(counter);

                //Display specified word if the current counter value is 
                //divisible by the fizzBuzz numbers' divisor.
                foreach (var fizzBuzzNumber in fizzBuzzNumbers)
                {
                    sb.Append(GetWordToDisplay(counter, fizzBuzzNumber));
                }

                sb.Append("\r\n");
                counter++;
            }

            return sb.ToString();
        }

        public string GetWordToDisplay(int numberToDivide, FizzBuzzNumber fizzBuzzNumber)
        {
            if (IsDivisibleByNumber(numberToDivide, fizzBuzzNumber.Divisor))
            {
                return fizzBuzzNumber.Message;
            }
            return string.Empty;
        }

        public bool IsDivisibleByNumber(int numberToDivide, int divisor)
        {
            return numberToDivide % divisor == 0;
        }
    }
}
