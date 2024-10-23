namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator\n");

            Creature c = new Creature("x",1);
            c.SayHi();

        }
    }
}
