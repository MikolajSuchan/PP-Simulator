namespace Simulator;

internal class Creature
{
    public string Name
    {
        get;
        set;
    }
    public int Level
    {
        get;
        set;
    } = 3;
    public Creature()
    {
    }
    public Creature(string name, int level=1)
    {
        Name = name;
        Level = level;
    }
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
    public void Info()
    {
        Console.WriteLine($"Creature name:{Name} Creature level:[{Level}]");
    }

}
