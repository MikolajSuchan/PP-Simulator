using Simulator.Maps;
using Simulator;

public class Program
{
    public static void Main(string[] args)
    {
        SmallSquareMap map = new SmallSquareMap(5);
        List<Creature> creatures = new List<Creature>
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };
        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1)
        };
        string moves = "ldlrludl"; 

        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);

        // Wizualizujemy mapę przed ruchem
        mapVisualizer.Draw();
        Console.WriteLine("Press any key to start simulation...");
        Console.ReadKey();

        // Rozpoczynamy symulację
        while (!simulation.Finished)
        {
            simulation.Turn();
            mapVisualizer.Draw();
            Console.WriteLine($"Current Move: {simulation.CurrentMoveName.ToUpper()}");
            Console.WriteLine("Press any key for next turn...");
            Console.ReadKey();
        }

        Console.WriteLine("Simulation Finished!");
    }
}
   