using System;

namespace MovieLibrary.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            do
            {
                char choice = GetInput();

                //if (choice == 'Q')
                //    done = HandleQuit();
                //else if (choice == 'A')
                //    AddMovie();
                //else if (choice == 'V')
                //    ViewMovie();
                //else if (choice == 'D')
                //    DeleteMovie();
                //else
                //    DisplayError("Unknown Option");

                switch(choice)
                {
                    case 'Q': done = HandleQuit(); break;
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'D': DeleteMovie(); break;
                    default: DisplayError("Unknown Option"); break;
                };
            } while (!done);
        }
        
        static Movie movie = new Movie();
        static void AddMovie ()
        {
            movie.title = ReadString("Enter the movie title: ", true);
            movie.description = ReadString("Enter the optional description: ", false);
            movie.runLength = ReadInt32("Enter runtime(in minutes): ", 0);
            movie.releaseYear = ReadInt32("Enter the release year(min 1900): ", 1900);
            movie.rating = ReadString("Enter the MPAA rating: ", false);
            movie.isClassic = ReadBoolean("Is this a classic (Y/N)? ");
        }
        static void ViewMovie()
        {
            if(String.IsNullOrEmpty(movie.title))
            {
                Console.WriteLine("No movie available");
                return;
            };

            Console.WriteLine($"{movie.title} ({movie.releaseYear})");
            Console.WriteLine($"Runtime: {movie.runLength} mins");
            Console.WriteLine($"MPAA Rating: {movie.rating}");
            Console.WriteLine($"Classic? {movie.isClassic}");
            Console.WriteLine(movie.description);
        }
        static void DeleteMovie()
        {
            if (!ReadBoolean("Are you sure(Y/N)? "))
                return;

            movie.title = null;
        }
        private static int ReadInt32 ( string message, int minimumValue)
        {
            Console.Write(message);

            do
            {
                string input = Console.ReadLine();

                //TODO: Input validation
                //int result = Int32.Parse(input); //Crashes program, not good for input
                int result;
                if (Int32.TryParse(input, out result) && result >= minimumValue)
                    return result;

                DisplayError("The value must be an integral value >= " + minimumValue);
            } while (true);
        }
        private static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            do
            {
                string input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                DisplayError("Value is required");
            } while (true);
        }
        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);
            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.WriteLine("");
                if (input.Key == ConsoleKey.Y)
                    return true;
                else if (input.Key == ConsoleKey.N)
                    return false;
            } while (true);
        }
        private static bool HandleQuit ()
        {
            //Display a confirmation
            if (ReadBoolean("Are you sure you want to quit(Y/N)? "))
                return true;
            //Return results            
            return false;
        }
        static char GetInput()
        {
            Console.WriteLine("   Move Library");
            //Console.WriteLine("------------------");
            Console.WriteLine("".PadLeft(15, '-'));

            Console.WriteLine("A) Add");
            Console.WriteLine("D) Delete");
            Console.WriteLine("V) View");
            Console.WriteLine("Q) Quit");

            //TODO: Input validation
            while (true)
            {
                string input = Console.ReadLine().Trim();

                //if (input == "Q")
                //    return 'Q';
                //else if (input == "A")
                //    return 'A';
                //else if (input == "V")
                //    return 'V';
                //else if (input == "D")
                //    return 'D';

                switch (input.ToUpper())
                {
                    //case "q":
                    case "Q": return 'Q';
                    //case "a": 
                    case "A": return 'A';
                    //case "v":
                    case "V": return 'V';
                    //case "d":
                    case "D": return 'D';
                    //default:;
                };

                DisplayError("Invalid input");
            };
        }
    }
}
