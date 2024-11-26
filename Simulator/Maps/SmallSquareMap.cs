namespace Simulator.Maps
{
    public class SmallSquareMap:SmallMap
    {
        public SmallSquareMap(int size) : base(size, size)
        {
        }
        public override Point Next(Point p, Direction d)
        {
            Point sampleP = p.Next(d);
            return Exist(sampleP) ? sampleP : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point sampleP = p.NextDiagonal(d);
            return Exist(sampleP) ? sampleP : p;
        }
    }
}
