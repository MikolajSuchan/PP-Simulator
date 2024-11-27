using Simulator;
using Simulator.Maps;

public class Simulation
{

    private int _currentTurn = 0;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    //dodać poprawkę do moves!!!!!!!!!!!!

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => IMappables[_currentTurn % IMappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[_currentTurn % Moves.Length].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,List<Point> positions, string moves)
    {

        if (mappables.Count != positions.Count)
            throw new ArgumentException("Liczba stworów musi odpowiadać liczbie pozycji.");
        if (mappables.Count == 0)
            throw new ArgumentException("Lista stworów nie może być pusta.");

        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {

        if (Finished)
            throw new ArgumentException("Symulacja zakończona.");

        var direction = DirectionParser.Parse(CurrentMoveName).FirstOrDefault();
        CurrentMappable.Go(direction);

        _currentTurn++;

        if (_currentTurn >= Moves.Length * IMappables.Count)
        {
            Finished = true;
        }
    }
}