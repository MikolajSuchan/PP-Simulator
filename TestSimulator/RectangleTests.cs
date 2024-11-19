using Simulator;

namespace TestSimulator
{
    public class RectangleTests
    {
        [Fact]
        public void Constructor_ValidCoordinates_ShouldSetBounds()
        {
            // Arrange & Act
            var rectangle = new Rectangle(2, 3, 5, 7);

            // Assert
            Assert.Equal(2, rectangle.X1);
            Assert.Equal(3, rectangle.Y1);
            Assert.Equal(5, rectangle.X2);
            Assert.Equal(7, rectangle.Y2);
        }

        [Fact]
        public void Constructor_InvalidCoordinates_ShouldThrowException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(3, 3, 3, 7));
        }

        [Theory]
        [InlineData(3, 4, true)]
        [InlineData(6, 8, false)]
        public void Contains_ShouldReturnCorrectValue(int x, int y, bool expected)
        {
            // Arrange
            var rectangle = new Rectangle(2, 3, 5, 7);

            // Act
            var result = rectangle.Contains(new Point(x, y));

            // Assert
            Assert.Equal(expected, result);
        }
    }

}
