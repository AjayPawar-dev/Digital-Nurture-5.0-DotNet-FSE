using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator.AllClear();
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(2, 3, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, -1, -2)]
        [TestCase(-2, 2, 0)]
        [TestCase(5, -3, 2)]
        [TestCase(10, 0, 10)]
        [TestCase(0, 10, 10)]
        [TestCase(7, 8, 15)]
        [TestCase(4, -4, 0)]
        public void Addition_WhenCalled_ReturnsExpectedResult(
            double a,
            double b,
            double expectedResult)
        {
            double result = calculator.Addition(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [Ignore("Subtraction test is intentionally ignored for demonstration.")]
        public void Subtraction_Ignored_Test()
        {
            double result = calculator.Subtraction(10, 5);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}