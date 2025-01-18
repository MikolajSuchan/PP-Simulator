using Simulator.Maps;
using System.Text.Json;
using System.Text.Json.Serialization;

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





            //Serializacja oraz deserlizacja

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

            Orc o1 = new("Gorbag", 3, 5);
            string json = JsonSerializer.Serialize(o1, jsonOptions);
            Console.WriteLine(json);

            Orc? o2 = JsonSerializer.Deserialize<Orc>(json);
            Console.WriteLine(o2);

            Point p1 = new(2, 4);
            string json1 = JsonSerializer.Serialize(p1);
            Console.WriteLine(json1); // {}

            Point p2 = JsonSerializer.Deserialize<Point>(json1);
            Console.WriteLine(p2);




            //Referencje


            Orc o11 = new("Gorbag", 3, 5);
            Orc o21 = new("Morgash", 2, 7);

            List<Orc> orcs = [o11, o21, o11];
            Console.WriteLine(orcs[0] == orcs[2]);

            string json2 = JsonSerializer.Serialize(orcs);

            List<Orc> deserialized = JsonSerializer.Deserialize<List<Orc>>(json2)!;
            Console.WriteLine(deserialized[0] == deserialized[2]);

            Console.WriteLine("\nJSON:");
            Console.WriteLine(json2);



            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            Orc o12 = new("Gorbag", 3, 5);
            Orc o22 = new("Morgash", 2, 7);

            List<Orc> orcs2 = new() { o12, o22, o12 };
            Console.WriteLine(orcs2[0] == orcs2[2]); // True

            string json3 = JsonSerializer.Serialize(orcs2, options);
            Console.WriteLine("\nJSON:");
            Console.WriteLine(json3);

            List<Orc> deserialized1 =
                JsonSerializer.Deserialize<List<Orc>>(json3, options)!;

            Console.Write("\nReference preserved:");
            Console.WriteLine(deserialized1[0] == deserialized1[2]);



            //Dziedziczenie 


            var options2 = new JsonSerializerOptions { WriteIndented = true };

            List<Creature> creatures2 = [
                new Orc("Gorbag", 3, 5),
                new Elf("Legolas", 2, 7)
            ];
            string json4 = JsonSerializer.Serialize(creatures2, options2);
            Console.WriteLine("\nJSON:");
            Console.WriteLine(json4);

            List<Creature> deserialized2 =
                JsonSerializer.Deserialize<List<Creature>>(json4, options2)!;

            Console.WriteLine("\nPolimorfic OK:");
            Console.WriteLine(deserialized2[0] is Orc);
            Console.WriteLine(deserialized2[1] is Elf);




            //Interfejsy

            var options3 = new JsonSerializerOptions { WriteIndented = true };

            List<IMappable> mapables = [
                new Orc("Gorbag", 3, 5),
                new Elf("Elandor", 2, 7),
                new Animals { Description = "Rasbbits", Size = 10 },
                new Birds { Description = "Eagles", Size = 15 },
                new Birds { Description = "Emu", Size = 8, CanFly = false }
            ];

            string json5 = JsonSerializer.Serialize(mapables, options3);
            Console.WriteLine("\nJSON:");
            Console.WriteLine(json5);

            List<IMappable> deserialized3 =
                JsonSerializer.Deserialize<List<IMappable>>(json5, options3)!;




            //Zapisanie symulacji jako json i potem wyświetlanie dowolnej symulacji innym guzikiem,
            




        }

    }
}
