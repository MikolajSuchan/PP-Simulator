using Simulator;
using Simulator.Maps;

public class Program
{
    public static void Main(string[] args)
    {
        BigBounceMap map = new BigBounceMap(8, 6);

        List<IMappable> creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 5, CanFly = true },
            new Birds { Description = "Ostriches", Size = 4, CanFly = false }
        };

        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1),
            new Point(4, 1),
            new Point(5, 1),
            new Point(6, 1),
        };

        string moves = "uurdrrl";
        Simulation simulation = new Simulation(map, creatures, points, moves);

        // Tworzymy historię symulacji
        SimulationHistory simulationHistory = new SimulationHistory(simulation);

        // Tworzymy obiekt LogVisualizer
        LogVisualizer logVisualizer = new LogVisualizer(simulationHistory);

        Console.WriteLine("Simulation Finished!");

        // Wyświetlanie zapisanych stanów
        foreach (int turn in new[] {0,1,2,3,4,5,6,7,8})
        {
            logVisualizer.Draw(turn);
            Console.WriteLine("Press any key for next turn...");
            Console.ReadKey();
        }

        Console.WriteLine("End of history playback.");
    }
}
