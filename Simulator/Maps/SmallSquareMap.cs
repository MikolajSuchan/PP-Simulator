namespace Simulator.Maps
{
    public class SmallSquareMap:SmallMap
    {
        public SmallSquareMap(int size) : base(size, size)
        {
        }
        public override Point Next(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up: return new Point(p.X, p.Y - 1);
                case Direction.Right: return new Point(p.X + 1, p.Y);
                case Direction.Down: return new Point(p.X, p.Y + 1);
                case Direction.Left: return new Point(p.X - 1, p.Y);
                default: return p;
            }
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up: return new Point(p.X + 1, p.Y - 1);
                case Direction.Right: return new Point(p.X + 1, p.Y + 1);
                case Direction.Down: return new Point(p.X - 1, p.Y + 1);
                case Direction.Left: return new Point(p.X - 1, p.Y - 1);
                default: return p;
            }
        }
    }
}
