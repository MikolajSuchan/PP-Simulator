namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {

        private readonly List<Creature>[,] _fields;

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map to wide");
            if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map to high");

            _fields = new List<Creature>[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    _fields[i, j] = new List<Creature>(); // Inicjalizacja list dla każdego punktu mapy
                }
            }
        }
        protected override void OnAdd(Creature creature, Point point)
        {
            _fields[point.X, point.Y].Add(creature);
        }
        protected override void OnRemove(Creature creature, Point point)
        {
            _fields[point.X, point.Y].Remove(creature);
        }
        protected override List<Creature> OnAt(Point point)
        {
            return _fields[point.X, point.Y];
        }
    }
}
