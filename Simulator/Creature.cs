namespace Simulator.Maps;

public abstract class Creature
{
    private string _name = "Unknown";

    private int _level = 1;

    public Map? map { get;private set; }

    public Point position { get; private set; }

    public void InitMapAndPosition(Map map,Point position) { }

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

    public string Go(Direction direction)
        //Map.Next();
        //Map.Next()==position->Next brak ruchu;

        //Map.Move();



        => $"{direction.ToString().ToLower()}";


    //out
    public string[] Go(Direction[] directions)
    {
        string[] rand= new string[directions.Length];
        for (int x = 0; x < directions.Length; x++)
        {
            rand[x] = Go(directions[x]);
        }

        return rand;
    }
    //out
    public string[] Go(string directions)
    {
        var directionArray = DirectionParser.Parse(directions);
        return Go(directionArray);
    }

}
