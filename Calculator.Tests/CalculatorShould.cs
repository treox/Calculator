using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorShould
    {
        [Fact]
        public void AddNumbers()
        {
            decimal testNumber1 = 2;
            decimal testNumber2 = 2;
            decimal expectedSum = 4;
            decimal[] testArray = { };

            decimal actualSum = Program.AddNumbers(testNumber1, testNumber2, testArray);

            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void AddMultipleNumbers()
        {
            decimal testNumber1 = 0;
            decimal testNumber2 = 0;
            decimal expectedSum = 10;
            decimal[] testArray = { 1, 2, 3, 4 };

            decimal actualSum = Program.AddNumbers(testNumber1, testNumber2, testArray);

            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void SubtractNumbers()
        {
            decimal testNumber1 = 6;
            decimal testNumber2 = 3;
            decimal expectedDifference = 3;
            decimal[] testArray = { };

            decimal actualDifference = Program.SubtractNumbers(testNumber1, testNumber2, testArray);

            Assert.Equal(expectedDifference, actualDifference);
        }

        [Fact]
        public void SubtractMultipleNumbers()
        {
            decimal testNumber1 = 0;
            decimal testNumber2 = 0;
            decimal expectedDifference = 25;
            decimal[] testArray = { 100, 50, 20, 5 };

            decimal actualDiference = Program.SubtractNumbers(testNumber1, testNumber2, testArray);

            Assert.Equal(expectedDifference, actualDiference);
        }

        [Theory]
        [InlineData("1,2,3,4", true)]
        [InlineData("-1,2,-3,4", true)]
        [InlineData("100,50,20,5", true)]
        [InlineData("-5,50,20,5", true)]
        public void ReturnTrueWhenNumbersAreAddedToArray(string testLine, bool expectedReturnValue)
        {
            bool actualReturnValue = Program.AddNumbersToArray(testLine);

            Assert.Equal(expectedReturnValue, actualReturnValue);
        }

        [Theory]
        [InlineData("ttt", "Fel: Fel format. Ange rätt format på inmatning!")]
        [InlineData("1,2,t,4", "Fel: Fel format. Ange rätt format på inmatning!")]
        [InlineData("t,2,3,4", "Fel: Fel format. Ange rätt format på inmatning!")]
        [InlineData("1,2,3,4,", "Fel: Fel format. Ange rätt format på inmatning!")]
        public void ThrowExceptionWhenNumbersAreNotAddedToArray(string testLine, string expectedException)
        {
            var actualException = Assert.Throws<FormatException>(() => Program.AddNumbersToArray(testLine));

            Assert.Equal(expectedException, actualException.Message);
        }

        [Fact]
        public void MultiplyNumbers()
        {
            decimal testNumber1 = 6;
            decimal testNumber2 = 6;
            decimal expectedProduct = 36;

            decimal actualProduct = Program.MultiplyNumbers(testNumber1, testNumber2);

            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void DivideNumbers()
        {
            decimal testNumber1 = 10;
            decimal testNumber2 = 2;
            decimal expectedQuotient = 5;

            decimal actualQuotient = Program.DivideNumbers(testNumber1, testNumber2);

            Assert.Equal(expectedQuotient, actualQuotient);
        }

        [Fact]
        public void ThrowDivideByZeroExceptionWhenAttemptingToDivideByZero()
        {
            decimal testNumber1 = 5;
            decimal testNumber2 = 0;
            string expectedMessage = "Fel: Det är inte tillåtet att dividera med 0!";

            var actualException = Assert.Throws<DivideByZeroException>(() => Program.DivideNumbers(testNumber1, testNumber2));

            Assert.Equal(expectedMessage, actualException.Message);
        }

        [Fact]
        public void SquareRootANumber()
        {
            decimal testNumber1 = 25;
            double expectedSquareRoot = 5;

            double actualSquareRoot = Program.SquareRootOfNumber(testNumber1);

            Assert.Equal(expectedSquareRoot, actualSquareRoot);
        }

        [Fact]
        public void PowerANumber()
        {
            decimal testNumber1 = 5;
            decimal testNumber2 = 2;
            double expectedPower = 25;

            double actualPower = Program.PoweredToNumbers(testNumber1, testNumber2);

            Assert.Equal(expectedPower, actualPower);
        }

        [Fact]
        public void CalculateHowMuchPercentIsOfNumber()
        {
            decimal testNumber1 = 50;
            decimal testNumber2 = 100;
            decimal expectedValue = 50;

            decimal actualValue = Program.PercentOfNumbers(testNumber1, testNumber2);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}
