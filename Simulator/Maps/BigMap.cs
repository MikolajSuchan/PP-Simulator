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

        protected override void OnAdd(IMappable mappable, Point point)
        {
            if (!_fields.ContainsKey(point))
            {
                _fields[point] = new List<IMappable>();
            }
            _fields[point].Add(mappable);
        }

        protected override void OnRemove(IMappable mappable, Point point)
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

        protected override List<IMappable> OnAt(Point point)
        {
            return _fields.ContainsKey(point) ? _fields[point] : new List<IMappable>();
        }

        public override Point Next(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point(p.X, p.Y - 1),
                Direction.Down => new Point(p.X, p.Y + 1),
                Direction.Left => new Point(p.X - 1, p.Y),
                Direction.Right => new Point(p.X + 1, p.Y),
                _ => throw new ArgumentOutOfRangeException(nameof(d), "Niepoprawny kierunek")
            };
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point(p.X + 1, p.Y - 1),
                Direction.Down => new Point(p.X - 1, p.Y + 1),
                Direction.Left => new Point(p.X - 1, p.Y - 1),
                Direction.Right => new Point(p.X + 1, p.Y + 1),
                _ => throw new ArgumentOutOfRangeException(nameof(d), "Niepoprawny kierunek")
            };
        }
    }
}
