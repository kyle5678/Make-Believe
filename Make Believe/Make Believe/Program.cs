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
            Console.WriteLine("Hello! Welcome to the MakeBelieve Word Creator!");
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
                for (int i = 0; i < Console.WindowWidth; i++) { Console.Write("-"); }

                Console.Write("How many syllables would you like to have in your made up word? ");

                try { Syllables = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine("That's not a number!!!"); return; }

                Console.WriteLine("Hold on while we generate a word...");
                InventWord(Syllables);
            }
        }

        public static void InventWord(int syllables)
        {
            for (int i = 0; i < syllables; i++)
            {
                string invented = InventSyllable();
                Console.Write(invented);
                CurrentInventedWord += invented;
            }
            Console.WriteLine();
        }

        public static string InventSyllable()
        {
            return RandomInArray(Vowels) + RandomInArray(Consonants);
        }

        public static string RandomInArray(string[] search)
        {

            return search[r.Next(0, search.Length)];
        }

        public static string[] Vowels = new string[] { "a", "e", "i", "o", "u" };
        public static string[] Consonants = new string[] { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "qu", "r", "s", "t", "v", "w", "x", "y", "z" };
        public static string CurrentInventedWord = "";
        public static int Syllables = 0;
    }
}
