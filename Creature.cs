namespace Simulator;

internal class Creature
{
    public string? Name;
    public int Level;

    public Creature()
    {
    }

    public Creature(string? name, int level)
    {
        Name = name;
        Level = level;
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
}
