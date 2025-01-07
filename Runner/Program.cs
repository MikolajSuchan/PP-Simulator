using Simulator.Maps;

namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Creature> creatures = new List<Creature>
            {
                new Elf("Elandor", level: 5, agility: 7),
                new Orc("Gorbag", level: 4, rage: 6),
                new Elf("Finwe", level: 3, agility: 9),
                new Orc("Ugluk", level: 6, rage: 4),
                new Elf("Thranduil", level: 2, agility: 8),
                new Orc("Shagrat", level: 5, rage: 5)
            };

            Console.WriteLine("Do wyboru sortowania:");
            Console.WriteLine("1 - Rosnąco (Najmniejsza do największej)");
            Console.WriteLine("2 - Malejąco (Największa do najmniejszej)");
            Console.WriteLine("Brak wybrania metody spowoduje wybranie domyślnie sortowania rosnącego");
            Console.Write("Proszę o wybór sortowania: ");
            var choice = Console.ReadLine();


            if (choice == "1")
            {
                creatures.Sort((c1, c2) => c1.Power.CompareTo(c2.Power));
            }
            else if (choice == "2")
            {
                creatures.Sort((c1, c2) => c2.Power.CompareTo(c1.Power));
            }
            else
            {
                Console.WriteLine("Wybór domyślny sortowanie rosnące");
                creatures.Sort((c1, c2) => c1.Power.CompareTo(c2.Power));
            }


            Console.WriteLine("\nStwory posortowane względem 'Power':");
            foreach (var creature in creatures)
            {
                Console.WriteLine($"{creature.GetType().Name}: {creature.Info}, Power: {creature.Power}");
            }


            int totalElfPower = 0;
            int totalOrcPower = 0;

            foreach (var creature in creatures)
            {
                if (creature is Elf)
                {
                    totalElfPower += creature.Power;
                }
                else if (creature is Orc)
                {
                    totalOrcPower += creature.Power;
                }
            }


            Console.WriteLine("\nSumaryczna moc względem rasy:");
            Console.WriteLine($"Elfy: {totalElfPower}");
            Console.WriteLine($"Orki: {totalOrcPower}");
        }

    }
}
