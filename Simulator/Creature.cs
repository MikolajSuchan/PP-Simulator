namespace Simulator.Maps;

public abstract class Creature : IMappable
{
    private string _name = "Unknown";

    private int _level = 1;

    public Map? Map { get;private set; }

    public Point? Position { get; private set; }

    public abstract char Symbol { get; }

    public string Name
    {
        get=>_name;
        init
        {
            _name = Validator.Shortener(value, 3, 25, '#');
        }
    }
    public int Level
    {
        get=>_level ;
        init
        {
            _level = Validator.Limiter(value, 1, 10);
        }
    }
    public Creature()
    {
    }
    public Creature(string name, int level=1)
    {
        Name = name;
        Level = level;
    }

    public abstract string Info { get; }
    public abstract int Power { get; }
    public abstract string Greeting();
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }


    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (!map.Exist(position))
            throw new ArgumentOutOfRangeException("Punkt znajduje się poza granicami mapy");

        Map = map;
        Position = position;
        Map.Add(this, position); 
    }

    public void Go(Direction direction)
    {
        if (Map == null || Position == null)
            throw new InvalidOperationException("Stór nir jest na mapie");


        var newPosition = Map.Next(Position.Value, direction);

        if (Map.Exist(newPosition))
        {
            Map.Move(this, Position.Value, newPosition); 
            Position = newPosition; 
            
        }

    }



}
