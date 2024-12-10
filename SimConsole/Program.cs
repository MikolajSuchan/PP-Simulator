using System;
using System.Collections.Generic;
using Simulator;
using Simulator.Maps;

namespace Simulator
{
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

            SimulationHistory simulationHistory = new SimulationHistory(simulation);

            MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to start simulation...");
            Console.ReadKey();

            int turnCounter = 0;

            while (!simulation.Finished)
            {
                simulation.Turn();
                simulationHistory.SaveState(turnCounter); 
                mapVisualizer.Draw();
                Console.WriteLine($"Current Move: {simulation.CurrentMappable.GetType().Name} moves {simulation.CurrentMoveName.ToUpper()}");

                Console.WriteLine("Press any key for next turn...");
                Console.ReadKey();
                turnCounter++;
            }

            Console.WriteLine("Simulation Finished!");

            Console.WriteLine("Displaying states at specific turns:");

            simulationHistory.Replay(5);
            mapVisualizer.Draw(false);
            Console.WriteLine("Press any key to continue to 10th turn...");
            Console.ReadKey();

            simulationHistory.Replay(10);
            mapVisualizer.Draw(false);
            Console.WriteLine("Press any key to continue to 15th turn...");
            Console.ReadKey();

            simulationHistory.Replay(15);
            mapVisualizer.Draw(false);
            Console.WriteLine("Press any key to continue to 20th turn...");
            Console.ReadKey();

            simulationHistory.Replay(20);
            mapVisualizer.Draw(false);
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }
    }
}
