using Simulator.Maps;
using Simulator;

public class Program
{
    public static void Main(string[] args)
    {
        SmallSquareMap map = new SmallSquareMap(5);

        List<IMappable> creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };
        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1)
        };
        string moves = "dlrludl"; 

        Simulation simulation = new Simulation(map, creatures, points, moves);

        MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);



        mapVisualizer.Draw();
        Console.WriteLine("Press any key to start simulation...");
        Console.ReadKey();



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
   