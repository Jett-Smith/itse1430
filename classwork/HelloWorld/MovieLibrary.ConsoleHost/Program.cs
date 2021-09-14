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

        static string title;
        static string description;

        static int runLength;
        static int releaseYear;

        static double reviewRating;
        static string rating;
        static bool isClassic;
        static void AddMovie ()
        {
            title = ReadString("Enter the movie title: ", true);
            description = ReadString("Enter the optional description: ", false);

            runLength = ReadInt32("Enter runtime(in minutes): ", 0);
            releaseYear = ReadInt32("Enter the release year(min 1900): ", 1900);

            rating = ReadString("Enter the MPAA rating: ", false);
            isClassic = ReadBoolean("Is this a classic (Y/N)? ");
        }
        static void ViewMovie()
        {
            Console.WriteLine(title);
            Console.WriteLine(releaseYear);
            Console.WriteLine(runLength);
            Console.WriteLine(rating);
            Console.WriteLine(isClassic);
            Console.WriteLine(description);
        }
        static void DeleteMovie()
        {
            if (!ReadBoolean("Are you sure(Y/N)? "))
                return;
            //TODO: delete movie
            Console.WriteLine("Not implemented");
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
                string input = Console.ReadLine();
                
                return input;
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
            Console.WriteLine("------------------");

            Console.WriteLine("A) Add");
            Console.WriteLine("D) Delete");
            Console.WriteLine("V) View");
            Console.WriteLine("Q) Quit");

            //TODO: Input validation
            while (true)
            {
                string input = Console.ReadLine();

                //if (input == "Q")
                //    return 'Q';
                //else if (input == "A")
                //    return 'A';
                //else if (input == "V")
                //    return 'V';
                //else if (input == "D")
                //    return 'D';

                switch (input)
                {
                    case "q":
                    case "Q": return 'Q';
                    case "a":
                    case "A": return 'A';
                    case "v":
                    case "V": return 'V';
                    case "d":
                    case "D": return 'D';
                };

                DisplayError("Invalid input");
            };
        }
    }
}
