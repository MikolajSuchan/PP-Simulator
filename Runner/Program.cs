using Simulator.Maps;

namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator\n");
            Lab5a();
            Lab5b();

            //Point p = new(10, 25);
            //Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
            //Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
                                                                 


            static void Lab5a()
            {
                try
                {
                    Rectangle kwa1 = new Rectangle(10, 10, 14, 14);

                    Console.WriteLine(kwa1);  

                    Rectangle kwa2 = new Rectangle(new Point(4, 4), new Point(7, 7));

                    Console.WriteLine(kwa2);

                    Point randpoint = new Point(4, 4);

                    Console.WriteLine(kwa1.Contains(randpoint));  //false

                    Console.WriteLine(kwa2.Contains(randpoint));  //true

                    
                    Rectangle kwa3 = new Rectangle(2, 2, 2, 5); //chudy prostokąt
                                                                //
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

            static void Lab5b()
            {
                try
                {
                    SmallSquareMap samplemap1 = new SmallSquareMap(15);

                    Point samplepoint1 = new Point(15, 15);

                    Console.WriteLine(samplemap1.NextDiagonal(samplepoint1, Direction.Right)); 

                    Console.WriteLine(samplemap1.Exist(new Point(14, 14)));  
                    
                    Console.WriteLine(samplemap1.Exist(new Point(15, 15)));

                    SmallSquareMap samplemap2 = new SmallSquareMap(25);


                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }


        }

    }
}
