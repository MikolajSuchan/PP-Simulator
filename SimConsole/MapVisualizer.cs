using Simulator.Maps;
using Simulator;
using System.Text;

public class MapVisualizer
{
    private Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;

        // Top border
        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.TopRight);

        // Body of the map
        for (int y = 0; y < _map.SizeY; y++)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < _map.SizeX; x++)
            {
                var creaturesAtPosition = _map.At(x, y);

                if (creaturesAtPosition.Count > 1)
                {
                    Console.Write("X");
                }
                else if (creaturesAtPosition.Count == 1)
                {
                    var creature = creaturesAtPosition[0];


                    if (creature is Orc)
                    {
                        Console.Write("O"); // Orc
                    }
                    else if (creature is Elf)
                    {
                        Console.Write("E"); // Elf
                    }
                    else if (creature is Birds bird)
                    {

                        Console.Write(bird.Symbol);
                    }
                    else if (creature is Animals)
                    {
                        Console.Write("A"); // Animal
                    }
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine(Box.Vertical);

            if (y < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _map.SizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        // Bottom border
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
 