namespace Calc.Tests {
    public class CalcTests {

        public CalcTests() {
            // If you need to do some setup before each test, do it here. Because xUnit doesn't have [SetUp] and [TearDown] attributes.
        }

        [Fact]
        public void Add() {
            var c = new Calculator();
            var actual = c.Add(2, 2);
            var expected = 4;
            Assert.Equal(expected, actual);
        }
    }
}