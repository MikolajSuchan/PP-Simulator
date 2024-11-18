namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {

        public int Size { get; }

        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi być z przedziału liczba od 5 do 20.");

            Size = size;
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
        }

        public override Point Next(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point(p.X, (p.Y + 1) % Size);
                case Direction.Down:
                    return new Point(p.X, (p.Y - 1 + Size) % Size);
                case Direction.Left:
                    return new Point((p.X - 1 + Size) % Size, p.Y);
                case Direction.Right:
                    return new Point((p.X + 1) % Size, p.Y);
                default:
                    return default;
            }
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Left:
                    return new Point((p.X - 1 + Size) % Size, (p.Y + 1) % Size);
                case Direction.Up:
                    return new Point((p.X + 1) % Size, (p.Y + 1) % Size);
                case Direction.Down:
                    return new Point((p.X - 1 + Size) % Size, (p.Y - 1 + Size) % Size);
                case Direction.Right:
                    return new Point((p.X + 1) % Size, (p.Y - 1 + Size) % Size);
                default:
                    return default;
            }
        }
    }
}
