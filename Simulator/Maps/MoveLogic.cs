namespace Simulator.Maps;

public static class MoveLogic
{
    public static Point WallNext(Map m, Point p, Direction d)
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

    public static Point WallNextDiagonal(Map m,Point p, Direction d)
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
    public static Point TorusNext(Map m,Point p, Direction d)
    {
        switch (d)
        {
            case Direction.Up:
                return new Point(p.X, (p.Y - 1 + m.SizeY) % m.SizeY);
            case Direction.Down:
                return new Point(p.X, (p.Y + 1) % m.SizeY);
            case Direction.Left:
                return new Point((p.X - 1 + m.SizeX) % m.SizeX, p.Y);
            case Direction.Right:
                return new Point((p.X + 1) % m.SizeX, p.Y);
            default:
                return default;
        }
    }
    public static Point TorusNextDiagonal(Map m, Point p, Direction d)
    {
        switch (d)
        {
            case Direction.Left:
                return new Point((p.X - 1 + m.SizeX) % m.SizeX, (p.Y + 1) % m.SizeY);
            case Direction.Up:
                return new Point((p.X - 1 + m.SizeX) % m.SizeX, (p.Y - 1 + m.SizeY) % m.SizeY);
            case Direction.Down:
                return new Point((p.X + 1) % m.SizeX, (p.Y + 1) % m.SizeY);
            case Direction.Right:
                return new Point((p.X + 1) % m.SizeX, (p.Y - 1 + m.SizeY) % m.SizeY);
            default:
                return default;
        }
    }


    public static Point BounceNext(Map m, Point p, Direction d)
    {
        int newX = p.X;
        int newY = p.Y;

        switch (d)
        {
            case Direction.Up:
                newY = p.Y - 1;
                if (newY < 0) newY = 1; 
                break;
            case Direction.Down:
                newY = p.Y + 1;
                if (newY >= m.SizeY) newY = m.SizeY - 2; 
                break;
            case Direction.Left:
                newX = p.X - 1;
                if (newX < 0) newX = 1; 
                break;
            case Direction.Right:
                newX = p.X + 1;
                if (newX >= m.SizeX) newX = m.SizeX - 2; 
                break;
        }

        return new Point(newX, newY);
    }

    public static Point BounceNextDiagonal(Map m, Point p, Direction d)
    {
        int newX = p.X;
        int newY = p.Y;

        switch (d)
        {
            case Direction.Up:
                newX += 1;
                newY -= 1;
                if (newY < 0) newY = 1;
                if (newX >= m.SizeX) newX = m.SizeX - 2;
                break;
            case Direction.Down:
                newX += 1;
                newY += 1;
                if (newY >= m.SizeY) newY = m.SizeY - 2;
                if (newX >= m.SizeX) newX = m.SizeX - 2;
                break;
            case Direction.Left:
                newX -= 1;
                newY -= 1;
                if (newY < 0) newY = 1;
                if (newX < 0) newX = 1;
                break;
            case Direction.Right:
                newX -= 1;
                newY += 1;
                if (newY >= m.SizeY) newY = m.SizeY - 2;
                if (newX < 0) newX = 1;
                break;
        }

        return new Point(newX, newY);
    }

}
