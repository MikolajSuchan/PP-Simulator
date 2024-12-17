namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {

        public int SizeX { get; }
        public int SizeY { get; }

        private readonly Dictionary<Point, List<IMappable>> _fields;

        private readonly Rectangle _map;

        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Minimalna wielkość mapy powinna wynosić 5 w długości i szerokości");
            }
            SizeX = sizeX;
            SizeY = sizeY;
            _map = new Rectangle(0, 0, sizeX - 1, sizeY - 1);
            _fields = new Dictionary<Point, List<IMappable>>();

        }


        //Add(IMappable,Point)

        public void Add(IMappable mappable, Point point)
        {
            if (!_fields.ContainsKey(point))
            {
                _fields[point] = new List<IMappable>();
            }
            _fields[point].Add(mappable);
        }

        //Remove(IMappable,Point)

        public void Remove(IMappable mappable, Point point)
        {
            if (_fields.ContainsKey(point))
            {
                _fields[point].Remove(mappable);
                if (_fields[point].Count == 0)
                {
                    _fields.Remove(point);
                }
            }
        }

        //Move()

        public void Move(IMappable mappable, Point from, Point to)
        {
            Remove(mappable, from);
            Add(mappable, to);
        }

        //At(Point albo x lub y)

        public List<IMappable> At(Point point)
        {
            if (!Exist(point))
                throw new ArgumentOutOfRangeException("Punkt znajduje się poza granicami mapy");
            return OnAt(point);
        }

        public List<IMappable> At(int x, int y)
        {
            return At(new Point(x, y)); //To samo co wyżej tylko współrzędne
        }


        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public virtual bool Exist(Point p)=>_map.Contains(p);

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);

    }
}
