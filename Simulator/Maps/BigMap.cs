namespace Simulator.Maps
{
    public abstract class BigMap : Map
    {
        private readonly Dictionary<Point, List<IMappable>> _fields;

        protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000 || sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException("Wymiry mapy nie powinny być większe niż 1000x1000.");
            }

            _fields = new Dictionary<Point, List<IMappable>>();
        }
    }
}
