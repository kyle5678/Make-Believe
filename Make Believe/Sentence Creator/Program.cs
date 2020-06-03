using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_Believe
{
    class Program
    {
        public static Random r = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to the MakeBelieve Sentence Creator!");
            for (; ; )
            {
                try
                {
                    Code();
                }

                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Whoops, something went wrong!");
                    Console.WriteLine(e);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public static void Code()
        {

            for (; ; )
            {
                Subject(true);
                Predicate();
                Console.Write(".");
                Console.ReadLine();
            }
        }

        private static void Subject(bool start)
        {
            if (r.Next(1, 3) == 1)
                Console.Write($"{RandomIn(Names)}");
            else
            {
                string Object = RandomIn(Objects);
                if (r.Next(1, 3) == 1)
                {
                    if (start)
                        Console.Write($"The {Object}");
                    else
                        Console.Write($"the {Object}");
                }
                else
                {
                    if (start)
                        Console.Write("A");
                    else
                        Console.Write("a");

                    if (Array.Exists(AnUsage, e => e == Object[0].ToString()))
                        Console.Write("n ");
                    else
                        Console.Write(" ");
                    Console.Write($"{Object}");
                }
            }
        }

        public static void Predicate()
        {
            switch (r.Next(1, 3))
            {
                case 1:
                    Console.Write(" is ");
                    Subject(false);
                    break;
                case 2:
                    Console.Write($" {RandomIn(PlaceVerbs)}{RandomIn(PlaceNouns)}");
                    break;
            }
        }

        public static string RandomIn(string[] search)
        {
            return search[r.Next(0, search.Length)];
        }

        public static string[] Names = new string[] { "Ana", "Andrew", "John", "Amanda" };
        public static string[] Objects = new string[] { "chicken", "cow", "sheep", "pig", "error", "person", "animal", "party", "star" };

        public static string[] PlaceVerbs = new string[] { "walks ", "jumps " };
        public static string[] PlaceNouns = new string[] { "to the park", "on the sidewalk" };

        public static string[] AnUsage = new string[] { "a", "e", "h", "i", "o", "u" };
    }
}
