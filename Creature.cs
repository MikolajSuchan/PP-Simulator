namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";

    private int _level = 1;

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

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";


    public string[] Go(Direction[] directions)
    {
        string[] rand= new string[directions.Length];
        for (int x = 0; x < directions.Length; x++)
        {
            rand[x] = Go(directions[x]);
        }

        return rand;
    }

    public string[] Go(string directions)
    {
        var directionArray = DirectionParser.Parse(directions);
        return Go(directionArray);
    }

}
