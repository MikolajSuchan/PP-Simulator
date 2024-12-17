using Simulator.Maps;
using Simulator;

internal class LogVisualizer
{
    private readonly SimulationHistory _log;

    public LogVisualizer(SimulationHistory log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
        {
            Console.WriteLine($"Tura o numerze: {turnIndex} jest poza zasięgiem");
            return;
        }

        var turnLog = _log.TurnLogs[turnIndex];

        Console.Clear(); 

        Console.WriteLine($"Tura {turnIndex}: {turnLog.Mappable} porusza się {turnLog.Move.ToUpper()}");

        // Top border
        Console.Write(Box.TopLeft);
        for (int x = 0; x < _log.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.TopRight);

        // Body of the map
        for (int y = 0; y < _log.SizeY; y++)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < _log.SizeX; x++)
            {
                var point = new Point(x, y);
                if (turnLog.Symbols.TryGetValue(point, out char symbol))
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine(Box.Vertical);

            if (y < _log.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _log.SizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        // Bottom border
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _log.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
