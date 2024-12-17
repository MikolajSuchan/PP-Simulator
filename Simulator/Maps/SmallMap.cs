namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {

        private readonly List<IMappable>[,] _fields;

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map to wide");
            if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map to high");

            _fields = new List<IMappable>[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    _fields[i, j] = new List<IMappable>();
                }
            }
        }
      
    }
}
