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
                switch (r.Next(1, 3))
                {
                    case 1:
                        IndependentClause(true);
                        Console.Write(".");
                        break;
                    case 2:
                        IndependentClause(true);
                        Console.Write(", and ");
                        IndependentClause(false);
                        Console.Write(".");
                        break;
                }
                Console.ReadLine();
            }
        }

        private static void IndependentClause(bool start)
        {
            Subject(start);
            Predicate();
        }

        private static void Subject(bool start)
        {
            switch (r.Next(1, 4))
            {
                case 1:
                    Console.Write($"{RandomIn(Names)}");
                    break;
                case 2:
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
                    break;
                case 3:
                    string pronoun = RandomIn(Pronouns);
                    if (start)
                        pronoun = pronoun[0].ToString().ToUpper() + pronoun.Substring(1);
                    Console.Write(pronoun);
                    break;
                default:
                    Subject(start);
                    break;
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

                default: // Backup
                    Predicate();
                    break;
            }
        }

        public static string RandomIn(string[] search)
        {
            return search[r.Next(0, search.Length)];
        }

        public static string[] Names = new string[] { "Ana", "Andrew", "John", "Amanda" };
        public static string[] Objects = new string[] { "chicken", "cow", "sheep", "pig", "error", "person", "animal", "party", "star" };
        public static string[] Pronouns = new string[] { "she", "he", "it" };

        public static string[] PlaceVerbs = new string[] { "walks ", "jumps ", "hops ", "skips ", "ambles " };
        public static string[] PlaceNouns = new string[] { "to the park", "on the sidewalk" };

        public static string[] AnUsage = new string[] { "a", "e", "h", "i", "o", "u" };
    }
}
