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

        // Tworzymy obiekt historii symulacji i zapisujemy wszystkie tury
        SimulationHistory simulationHistory = new SimulationHistory(simulation);

        Console.WriteLine("Simulation Finished!");

        // Wyświetlenie stanów dla wybranych tur
        foreach (int turn in new[] { 5, 10, 15, 20 })
        {
            Console.WriteLine($"Turn {turn}:");
            DisplayTurn(simulationHistory, turn);
            Console.WriteLine("Press any key for next turn...");
            Console.ReadKey();
        }
    }

    private static void DisplayTurn(SimulationHistory history, int turn)
    {
        var log = history.GetTurnLog(turn);

        Console.WriteLine($"Turn {turn}: {log.Mappable} moved {log.Move.ToUpper()}");

        for (int y = 0; y < history.SizeY; y++)
        {
            for (int x = 0; x < history.SizeX; x++)
            {
                var point = new Point(x, y);
                if (log.Symbols.TryGetValue(point, out char symbol))
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
