using Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new List<SimulationTurnLog>();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            var log = new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = _simulation.CurrentMoveName,
                Symbols = GenerateSymbolMap()
            };
            TurnLogs.Add(log);
            _simulation.Turn();
        }
    }

    private Dictionary<Point, char> GenerateSymbolMap()
    {
        var symbols = new Dictionary<Point, char>();
        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                var creatures = _simulation.Map.At(new Point(x, y));
                if (creatures.Count > 0)
                {
                    symbols[new Point(x, y)] = creatures[0].Symbol;
                }
            }
        }
        return symbols;
    }

    /// <summary>
    /// Udostępnia dane dla konkretnej tury.
    /// </summary>
    public SimulationTurnLog GetTurnLog(int turn)
    {
        if (turn < 0 || turn >= TurnLogs.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turn), "Niepoprawny numer tury");
        }
        return TurnLogs[turn];
    }
}