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

        static Movie movie;
        static void AddMovie ()
        {
            var newMovie = new Movie();

            do
            {
                newMovie.Title = ReadString("Enter the movie title: ", true);
                newMovie.Description = ReadString("Enter the optional description: ", false);
                newMovie.RunLength = ReadInt32("Enter runtime(in minutes): ", 0);
                newMovie.ReleaseYear = ReadInt32($"Enter the release year(min {Movie.MinimumReleaseYear}): ", Movie.MinimumReleaseYear);
                newMovie.Rating = ReadString("Enter the MPAA rating: ", false);
                newMovie.IsClassic = ReadBoolean("Is this a classic (Y/N)? ");

                var error = movie.Validate();
                if (String.IsNullOrEmpty(error))
                {
                    movie = newMovie;
                    return;
                }
            } while (true);
        }
        static void ViewMovie()
        {
            if(movie == null)
            {
                Console.WriteLine("No movie available");
                return;
            };

            Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
            Console.WriteLine($"Runtime: {movie.RunLength} mins");
            Console.WriteLine($"MPAA Rating: {movie.Rating}");
            Console.WriteLine($"Classic? {movie.IsClassic}");
            Console.WriteLine(movie.Description);

            if (movie.AgeInYears >= 25)
                Console.WriteLine($"{movie.AgeInYears}th Anniversary");
        }
        static void DeleteMovie()
        {
            if (movie == null)
                return;

            if (!ReadBoolean("Are you sure(Y/N)? "))
                return;

            movie = null;
        }
        /// <summary>Reads an Int32 from the console</summary>
        /// <param name="message">The message to display</param>
        /// <param name="minimumValue">The minimum value allowed</param>
        /// <returns>The integral value that was entered</returns>
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
        private static string ReadString (string message, bool required)
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
        private static bool ReadBoolean (string message)
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
            Console.WriteLine("".PadLeft(15, '-'));

            Console.WriteLine("A) Add");
            Console.WriteLine("D) Delete");
            Console.WriteLine("V) View");
            Console.WriteLine("Q) Quit");

            while (true)
            {
                string input = Console.ReadLine().Trim();

                switch (input.ToUpper())
                {
                    case "Q": return 'Q';
                    case "A": return 'A';
                    case "V": return 'V';
                    case "D": return 'D';
                };

                DisplayError("Invalid input");
            };
        }

        static void DemoObjects ()
        {
            object someValue = 10;
            someValue = "Hello";

            Print(10);
            Print("Hello");
            Print(45.6);
            //someValue.Equals(10);
        }

        static void Print (object value)
        {
            //Console.WriteLine(value);

            //Type checking
            //is-operator ::= E is T (returns bool)
            //as-operator ::= E as T (returns T or null), does not work with primitives
            //pattern-matching ::= E is T id (returns E as T if valid or false otherwise)

            //Type casting
            //c-style ::= (T) E blows up at runtime if wrong, only use with primitives

            if (value is int)
            {
                Console.WriteLine((int)value);
                return;
            }

            string str = value as string;
            if (str != null)
            {
                Console.WriteLine(str);
                return;
            }

            //Best choice
            if (value is double doubleValue)
            {
                Console.WriteLine(doubleValue);
                return;
            }

            //Value types follow value assignment (copy)
            int x = 10;
            int y = x;
            x = 20;
            Console.WriteLine(y); //10

            //Value types follow value semantics
            var equal = x == y; //false

            //Reference types follow reference assignment
            Movie m1 = new Movie();
            Movie m2 = m1;
            m1.Title = "Jaws";
            Console.WriteLine(m2.Title); //Jaws

            //Ref types follow refernce semantics
            equal = m1 == m2; //Object.Equals
        }
    }
}
