using Simulator;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 0, 10, 5)]
        [InlineData(-5, 0, 10, 0)]
        [InlineData(15, 0, 10, 10)]
        public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
        {
            // Act
            var result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("test", 5, 10, 'x', "Testx")]
        [InlineData("short", 5, 10, 'x', "Short")]
        [InlineData("verylongstring", 5, 10, 'x', "Verylongst")]
        public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
        {
            // Act
            var result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }
    }

}
