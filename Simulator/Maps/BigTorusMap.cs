namespace Simulator.Maps
{
    public class BigTorusMap : SmallMap
    {
        public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            FNext = MoveLogic.TorusNext;
            FNextDiagonal = MoveLogic.TorusNextDiagonal;
        }

    }
}
