using NUnit.Framework;
using System;
using InterviewTestQA.InterviewTestAutomation;

namespace InterviewTestQA.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        // Addition Tests
        [Test]
        public void Add_PositiveNumbers_ReturnsCorrectSum()
        {
            Assert.AreEqual(10, calculator.Add(7, 3));
        }

        [Test]
        public void Add_NegativeNumbers_ReturnsCorrectSum()
        {
            Assert.AreEqual(-10, calculator.Add(-7, -3));
        }

        [Test]
        public void Add_PositiveAndNegativeNumbers_ReturnsCorrectSum()
        {
            Assert.AreEqual(4, calculator.Add(7, -3));
        }

        // Subtraction Tests
        [Test]
        public void Subtract_PositiveNumbers_ReturnsCorrectDifference()
        {
            Assert.AreEqual(4, calculator.Subtract(7, 3));
        }

        [Test]
        public void Subtract_NegativeNumbers_ReturnsCorrectDifference()
        {
            Assert.AreEqual(-4, calculator.Subtract(-7, -3));
        }

        [Test]
        public void Subtract_PositiveAndNegativeNumbers_ReturnsCorrectDifference()
        {
            Assert.AreEqual(10, calculator.Subtract(7, -3));
        }

        // Multiplication Tests
        [Test]
        public void Multiply_PositiveNumbers_ReturnsCorrectProduct()
        {
            Assert.AreEqual(21, calculator.Multiply(7, 3));
        }

        [Test]
        public void Multiply_NegativeNumbers_ReturnsCorrectProduct()
        {
            Assert.AreEqual(21, calculator.Multiply(-7, -3));
        }

        [Test]
        public void Multiply_PositiveAndNegativeNumbers_ReturnsCorrectProduct()
        {
            Assert.AreEqual(-21, calculator.Multiply(7, -3));
        }

        [Test]
        public void Multiply_ByZero_ReturnsZero()
        {
            Assert.AreEqual(0, calculator.Multiply(7, 0));
        }

        // Division Tests
        [Test]
        public void Divide_PositiveNumbers_ReturnsCorrectQuotient()
        {
            Assert.AreEqual(2, calculator.Divide(6, 3));
        }

        [Test]
        public void Divide_NegativeNumbers_ReturnsCorrectQuotient()
        {
            Assert.AreEqual(2, calculator.Divide(-6, -3));
        }

        [Test]
        public void Divide_PositiveAndNegativeNumbers_ReturnsCorrectQuotient()
        {
            Assert.AreEqual(-2, calculator.Divide(6, -3));
        }

        [Test]
        public void Divide_ByZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => calculator.Divide(6, 0));
        }

        // Square Tests
        [Test]
        public void Square_PositiveNumber_ReturnsCorrectSquare()
        {
            Assert.AreEqual(49, calculator.Square(7));
        }

        [Test]
        public void Square_NegativeNumber_ReturnsCorrectSquare()
        {
            Assert.AreEqual(49, calculator.Square(-7));
        }

        [Test]
        public void Square_Zero_ReturnsZero()
        {
            Assert.AreEqual(0, calculator.Square(0));
        }

        // Square Root Tests
        [Test]
        public void SquareRoot_PositiveNumber_ReturnsCorrectSquareRoot()
        {
            Assert.AreEqual(3, calculator.SquareRoot(9));
        }

        [Test]
        public void SquareRoot_NonPerfectSquare_ReturnsTruncatedSquareRoot()
        {
            Assert.AreEqual(4, calculator.SquareRoot(20));  // returns the integer part only
        }

        [Test]
        public void SquareRoot_Zero_ReturnsZero()
        {
            Assert.AreEqual(0, calculator.SquareRoot(0));
        }

        [Test]
        public void SquareRoot_NegativeNumber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => calculator.SquareRoot(-9));
        }
    }
}
