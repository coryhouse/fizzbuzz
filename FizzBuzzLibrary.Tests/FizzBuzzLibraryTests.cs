using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzzLibrary.Tests
{
    [TestFixture]
    public class FizzBuzzLibraryTests
    {
        [Test]
        [TestCase(50, 5)]
        [TestCase(12, 4)]
        [TestCase(10, 2)]
        [TestCase(8, 1)]
        public void IsDivisibleByNumber_GivenDivisibleNumbers_ReturnsTrue(int numberToDivide, int divisor)
        {
            //arrange
            var fizzBuzz = new FizzBuzz();

            //act
            var divisible = fizzBuzz.IsDivisibleByNumber(numberToDivide, divisor);

            //assert
            Assert.IsTrue(divisible);
        }

        [Test]
        [TestCase(12, 7)]
        [TestCase(3, 5)]
        [TestCase(40, 17)]
        public void IsDivisibleByNumber_GivenIndivisibleNumbers_ReturnsFalse(int numberToDivide, int divisor)
        {
            //arrange
            var fizzBuzz = new FizzBuzz();

            //act
            var divisible = fizzBuzz.IsDivisibleByNumber(numberToDivide, divisor);

            //assert
            Assert.IsFalse(divisible);
        }

        [Test]
        public void Calculate_GivenRangeOf5_Outputs5Lines()
        {
            //arrange
            var fizzBuzz = new FizzBuzz();
            var range = new Range<int>() { Minimum = 10, Maximum = 14 };

            //act
            var result = fizzBuzz.Calculate(range, new List<FizzBuzzNumber>());
            var lineCount = LineCount(result);

            //assert
            Assert.AreEqual(lineCount, 5);
        }

        [Test]
        public void GetWordToDisplay_GivenDivisibleNumber_ReturnsAssociatedWord()
        {
            //arrange
            var fizzBuzz = new FizzBuzz();
            const string wordToDisplayForNumbersDivisibleByFive = "Divisible by five";
            var fizzBuzzNumber = new FizzBuzzNumber() { Divisor = 5, Message = wordToDisplayForNumbersDivisibleByFive };

            //act
            var wordToDisplay = fizzBuzz.GetWordToDisplay(15, fizzBuzzNumber);

            //assert
            Assert.AreEqual(wordToDisplayForNumbersDivisibleByFive, wordToDisplay);
        }

        [Test]
        public void GetWordToDisplay_GivenIndivisibleNumber_ReturnsEmptyString()
        {
            //arrange
            var fizzBuzz = new FizzBuzz();
            const string wordToDisplayForNumbersDivisibleByFive = "Divisible by five";
            var numberConfig = new FizzBuzzNumber() { Divisor = 5, Message = wordToDisplayForNumbersDivisibleByFive };

            //act
            var wordToDisplay = fizzBuzz.GetWordToDisplay(13, numberConfig);

            //assert
            Assert.IsEmpty(wordToDisplay);
        }

        [Test]
        public void Calcuate_GivenTwoFizzBuzzNumbers_ReturnsExpectedResult()
        {
            //arrange
            const string messageFor5 = "Nice! Hai Fivez!";
            const string messageFor7 = "Lucky Number Se7en";

            var fizzBuzzNumbers = new List<FizzBuzzNumber>()
            {
                new FizzBuzzNumber() { Divisor = 5, Message = messageFor5 },
                new FizzBuzzNumber() { Divisor = 7, Message = messageFor7 }
            };

            var range = new Range<int>() { Minimum = 5, Maximum = 10 };

            const string expectedResult = "5" + messageFor5 + "\r\n6\r\n7" + messageFor7 + "\r\n8\r\n9\r\n10" + messageFor5 + "\r\n";
            var fizzBuzz = new FizzBuzz();

            //act
            var result = fizzBuzz.Calculate(range, fizzBuzzNumbers);

            //assert
            Assert.AreEqual(result, expectedResult);
        }

        #region Helpers
        private long LineCount(string s)
        {
            long count = 0;
            int position = 0;
            while ((position = s.IndexOf('\n', position)) != -1)
            {
                count++;
                position++;         // Skip this occurrence!
            }
            return count;
        }
        #endregion
    }
}
