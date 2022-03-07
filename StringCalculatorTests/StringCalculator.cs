using System;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int res = StringCalculator.StringCalculator.CalculateString("");
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData("25", 25)]
        [InlineData("0", 0)]
        [InlineData("5", 5)]
        public void SingleNumberReturnsTheValue(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,11", 36)]
        [InlineData("10,10", 20)]
        public void TwoNumbersCommaDelimitedReturnstheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25\n11", 36)]
        [InlineData("10\n10", 20)]
        public void TwoNumbersNewlineDelimitedReturnstheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,11,10", 46)]
        [InlineData("10,10,2", 22)]
        public void ThreeNumbersCommaDelimitedReturnstheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25\n11\n10", 46)]
        [InlineData("4\n10\n2", 16)]
        public void ThreeNumbersNewlineDelimitedReturnstheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,11\n10", 46)]
        [InlineData("4\n10,2", 16)]
        public void ThreeNumbersDelimitedReturnstheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,11\n-10")]
        [InlineData("-4\n10,2")]
        public void NegativeNumbersThrowAnException(string s)
        {
            _ = Assert.Throws<ArgumentException>(
                () => StringCalculator.StringCalculator.CalculateString(s)
            );
        }

        [Theory]
        [InlineData("25,1100\n10", 35)]
        [InlineData("1001\n10,2", 12)]
        public void NumbersGreaterThanThousandAreIgnored(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("//#\n25,55\n10#5", 95)]
        [InlineData("//$\n100$10,2", 112)]
        public void NewSingleSeparatorCanBeDefined(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("//[#@]\n25,55\n10#@5", 95)]
        [InlineData("//[:$]\n100:$10,2", 112)]
        public void NewMultiSeparatorCanBeDefined(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
    }
}
