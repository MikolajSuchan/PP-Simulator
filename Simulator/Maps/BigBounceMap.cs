namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override Point Next(Point p, Direction d)
        {
            Point next = base.Next(p, d);

            if (!Exist(next))
            {
                Direction oppositeDirection = d switch
                {
                    Direction.Up => Direction.Down,
                    Direction.Down => Direction.Up,
                    Direction.Left => Direction.Right,
                    Direction.Right => Direction.Left,
                    _ => throw new ArgumentOutOfRangeException(nameof(d), "Niepoprawny kierunek")
                };

                Point bounceBack = base.Next(p, oppositeDirection);
                return Exist(bounceBack) ? bounceBack : p;
            }

            return next;
        }
    }
}
