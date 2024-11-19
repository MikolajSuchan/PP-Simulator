using Simulator;

namespace TestSimulator
{
    public class PointTests
    {
        [Fact]
        public void Constructor_ShouldSetCoordinates()
        {
            // Arrange & Act
            var point = new Point(3, 4);

            // Assert
            Assert.Equal(3, point.X);
            Assert.Equal(4, point.Y);
        }

        [Theory]
        [InlineData(3, 4, Direction.Up, 3, 5)]
        [InlineData(3, 4, Direction.Down, 3, 3)]
        [InlineData(3, 4, Direction.Left, 2, 4)]
        [InlineData(3, 4, Direction.Right, 4, 4)]
        public void Next_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var nextPoint = point.Next(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), nextPoint);
        }

        [Theory]
        [InlineData(5, 5, Direction.Up, 6, 6)]      
        [InlineData(5, 5, Direction.Down, 4, 4)]    
        [InlineData(5, 5, Direction.Left, 4, 6)]    
        [InlineData(5, 5, Direction.Right, 6, 4)]   
        [InlineData(0, 0, Direction.Up, 1, 1)]      
        [InlineData(0, 0, Direction.Down, -1, -1)]  
        public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }
    }

}
