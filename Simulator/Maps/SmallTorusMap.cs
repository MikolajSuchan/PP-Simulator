namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
        }

        public override Point Next(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point(p.X, (p.Y - 1 + SizeY) % SizeY);
                case Direction.Down:
                    return new Point(p.X, (p.Y + 1) % SizeY);
                case Direction.Left:
                    return new Point((p.X - 1 + SizeX) % SizeX, p.Y);
                case Direction.Right:
                    return new Point((p.X + 1) % SizeX, p.Y);
                default:
                    return default;
            }
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Left:
                    return new Point((p.X - 1 + SizeX) % SizeX, (p.Y + 1) % SizeY);
                case Direction.Up:
                    return new Point((p.X - 1 + SizeX) % SizeX, (p.Y - 1 + SizeY) % SizeY);
                case Direction.Down:
                    return new Point((p.X + 1) % SizeX, (p.Y + 1) % SizeY);
                case Direction.Right:
                    return new Point((p.X + 1) % SizeX, (p.Y - 1 + SizeY) % SizeY);
                default:
                    return default;
            }
        }
    }
}
