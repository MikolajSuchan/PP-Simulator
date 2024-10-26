namespace Simulator;

internal class Creature
{
    private string _name = "Unknown";

    private int _level = 1;

    public string Name
    {
        get=>_name;
        init
        {
            string trname = value.Trim();

            if (trname.Length < 3)
            {
                trname = trname.PadRight(3,'#');
            }
            if (trname.Length > 25)
            {
                trname = trname.Substring(0, 25).TrimEnd();

                if (trname.Length < 3)
                {
                    trname = trname.PadRight(3, '#');
                }
            }
            if (char.IsLower(trname[0]))
            {
                trname = char.ToUpper(trname[0]) + trname.Substring(1);
            }

            _name = trname;
        }
    }
    public int Level
    {
        get=>_level ;
        init
        {
            _level = Math.Max(1, Math.Min(10, value));
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
    public string Info => $"{Name}[{Level}]";
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public void Go(Direction direction)
    {
        string lowerdirection = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {lowerdirection}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        var directionArray = DirectionParser.Parse(directions);
        Go(directionArray);
    }

}
