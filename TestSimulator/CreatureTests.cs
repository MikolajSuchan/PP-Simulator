using Simulator.Maps;
using Simulator;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace TestSimulator
{
    public class CreatureTests
    {
        [Fact]
        public void InitMapAndPosition_ShouldInitializeCreatureOnMap()
        {
            // Arrange
            var map = new SmallSquareMap(5); // Tworzymy mapę 5x5
            var creature = new Orc("Orc", 1); // Tworzymy stwora
            var point = new Point(2, 2); // Punkt, w którym umieszczamy stwora

            // Act
            creature.InitMapAndPosition(map, point);

            // Assert
            Assert.Equal(map, creature.Map); // Sprawdzamy, czy mapa została przypisana
            Assert.Equal(point, creature.Position); // Sprawdzamy, czy pozycja została przypisana
            var creaturesAtPoint = map.At(point);
            Assert.Contains(creature, creaturesAtPoint); // Sprawdzamy, czy stwór znajduje się na mapie w danym punkcie
        }

        [Fact]
        public void Go_ShouldMoveCreatureOnMap()
        {
            // Arrange
            var map = new SmallSquareMap(5); // Tworzymy mapę 5x5
            var creature = new Orc("Orc", 1); // Tworzymy stwora
            var start = new Point(2, 2);
            var end = new Point(3, 2);

            creature.InitMapAndPosition(map, start);
            var direction = Direction.Right; // Poruszamy stwora w prawo

            // Act
            //var result = creature.Go(direction);

            // Assert
           // Assert.Equal($"Ruch na {direction.ToString().ToLower()}", result); // Sprawdzamy komunikat
            Assert.Contains(creature, map.At(end)); // Sprawdzamy, czy stwór jest w nowym punkcie
            Assert.DoesNotContain(creature, map.At(start)); // Sprawdzamy, czy stwór został usunięty z punktu początkowego
        }

        [Fact]
        public void Upgrade_ShouldIncreaseLevel()
        {
            // Arrange
            var creature = new Orc("Orc", 1);

            // Act
            creature.Upgrade(); // Poziom powinien zostać zwiększony

            // Assert
            Assert.Equal(2, creature.Level); // Sprawdzamy, czy poziom stwora został zwiększony
        }

        [Fact]
        public void Info_ShouldReturnCorrectInfo()
        {
            // Arrange
            var creature = new Orc("Orc", 3);

            // Act
            var result = creature.Info;

            // Assert
            Assert.Equal("Orc [3][1]", result); // Sprawdzamy, czy Info zwraca prawidłowe dane
        }

        [Fact]
        public void Go_ShouldThrowErrorIfNoMapAssigned()
        {
            // Arrange
            var creature = new Orc("Orc", 1);
            var direction = Direction.Right; // Ruch w prawo

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => creature.Go(direction)); // Sprawdzamy, czy rzuca wyjątek
        }
    }
}

