using System;

namespace MovieLibrary.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            char choice = GetInput();
            if (choice == 'Q')
                done = HandleQuit();
            else if (choice == 'A')
                AddMovie();
            else
                Console.WriteLine("Unknown Option");
            //TODO: handle additional stuff
        }
        private static void AddMovie ()
        {
            string title = ReadString("Enter the movie title: ", true);
            string description = ReadString("Enter the optional description: ", false);

            int runLength = ReadInt32("Enter runtime(in minutes): ", 0);
            int releaseYear = ReadInt32("Enter the release year(min 1900): ", 1900);

            double reviewRating;
            string rating = ReadString("Enter the MPAA rating: ", false);
            bool isClassic;
        }
        private static int ReadInt32 ( string message, int minimumValue)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            //TODO: Input validation
            //int result = Int32.Parse(input); //Crashes program, not good for input
            int result;
            if (Int32.TryParse(input, out result))
                return result;

            return -1;
        }
        private static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            //TODO: Input validation - Required
            string input = Console.ReadLine();
       
            return input;
        }
        private static bool HandleQuit ()
        {
            //Display a confirmation
            if (ReadBoolean("Are you sure you want to quit(Y/N)? "))
                return true;
            //Return results            
            return false;
        }
        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);
            
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Y)
                return true;
            
            //TODO: Input valdiation
            return false;
        }
        static char GetInput()
        {
            Console.WriteLine("Move Library");
            Console.WriteLine("------------");

            Console.WriteLine("A) Add");
            Console.WriteLine("Q) Quit");

            //TODO: Input validation
            string input = Console.ReadLine();
            if (input == "Q")
                return 'Q';
            else if (input == "A")
                return 'A';
            return default(char);
        }
    }
}
