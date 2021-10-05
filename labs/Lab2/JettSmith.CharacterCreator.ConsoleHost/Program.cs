/*
 *  Jett Smith
 *  ITSE 1430 - Fall 2021
 */
using System;

namespace JettSmith.CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Jett Smith");
            Console.WriteLine("ITSE 1430 - Fall 2021");
            Console.WriteLine("Character Creator");
            Console.WriteLine("----------------------");
            Console.ResetColor();
            Console.WriteLine();

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("N) New Character");
                Console.WriteLine("V) View Character");
                Console.WriteLine("E) Edit Character");
                Console.WriteLine("D) Delete Character");
                Console.WriteLine("Q) Quit");
                Console.ResetColor();

                string choice = Console.ReadLine().Trim().Substring(0, 1);
                switch (choice.ToUpper())
                {
                    case "N": AddCharacter(); break;
                    case "V": ViewCharacter(); break;
                    case "E": EditCharacter(); break;
                    case "D": DeleteCharacter(); break;
                    case "Q":
                    {
                        if (ReadBoolean("Are you sure you wish to quit(Y/N)?")) return;
                        break;
                    }
                    default: DisplayError("Please enter a valid option"); break;
                }
            } while (true);
        }

        static Character character;

        static void AddCharacter ()
        {
            Character newCharacter = new Character();

            do
            {
                newCharacter.Name = ReadString("Enter your Character's name: ", true);
                newCharacter.Class = ChooseClass();
                newCharacter.Race = ChooseRace();
                newCharacter.Biography = ReadString("Enter your Character's Biography (optional): ", false);
                newCharacter.Strength = ReadInt32("Enter your Character's Strength: ", 1, 100);
                newCharacter.Intelligence = ReadInt32("Enter your Character's Intelligence: ", 1, 100);
                newCharacter.Agility = ReadInt32("Enter your Character's Agility: ", 1, 100);
                newCharacter.Constitution = ReadInt32("Enter your Character's Constitution: ", 1, 100);
                newCharacter.Charisma = ReadInt32("Enter your Character's Charisma: ", 1, 100);

                string error = newCharacter.Validate();
                if (String.IsNullOrEmpty(error))
                {
                    character = newCharacter;
                    return;
                }
                Console.WriteLine(error);
            } while (true);
        }

        static string ChooseClass()
        {
            do
            {
                string characterClass = ReadString("What Class is your Character\n(Cleric, Bard, Fighter, Rogue, or Wizard): ", true);
                if (characterClass.ToUpper().Equals("CLERIC") || characterClass.ToUpper().Equals("BARD") || characterClass.ToUpper().Equals("FIGHTER") || characterClass.ToUpper().Equals("ROGUE") || characterClass.ToUpper().Equals("WIZARD"))
                    return characterClass.ToUpper();
                DisplayError("Please choose one of the Class Options");
            } while (true);
        }

        static string ChooseRace()
        {
            do
            {
                string characterRace = ReadString("What Race is your Character\n(Dragonborn, Dwarf, Elf, Human, or Kobold): ", true);
                if (characterRace.ToUpper().Equals("DRAGONBORN") || characterRace.ToUpper().Equals("DWARF") || characterRace.ToUpper().Equals("ELF") || characterRace.ToUpper().Equals("HUMAN") || characterRace.ToUpper().Equals("KOBOLD"))
                    return characterRace.ToUpper();
                DisplayError("Please choose one of the Race Options");
            } while (true);
        }

        static void ViewCharacter ()
        {
            if (character == null)
            {
                DisplayError("You don't have a Character");
                return;
            }

            Console.Clear();
            Console.WriteLine(character.Name);
            Console.WriteLine("".PadLeft(14 + ((character.Class.Length > character.Race.Length) ? character.Class.Length : character.Race.Length), '-'));
            Console.WriteLine("Class: ".PadRight(14) + character.Class);
            Console.WriteLine("Race: ".PadRight(14) + character.Race);
            Console.WriteLine("Strength: ".PadRight(14) + character.Strength);
            Console.WriteLine("Intelligence: ".PadRight(14) + character.Intelligence);
            Console.WriteLine("Agility: ".PadRight(14) + character.Agility);
            Console.WriteLine("Constitution: ".PadRight(14) + character.Constitution);
            Console.WriteLine("Charisma: ".PadRight(14) + character.Charisma);
            Console.WriteLine("");
            Console.WriteLine("Biography: " + character.Biography);
        }

        static void EditCharacter ()
        {
            ViewCharacter();
            Console.WriteLine("");

            if (character == null)
            {
                DisplayError("You don't have a Character");
                return;
            }

            do
            {
                Console.WriteLine("What would you like to change?");
                Console.WriteLine("(Name, Class, Race, Biography, Strength, Intelligence, Agility, Constitution, or Charisma)");
                string choice = Console.ReadLine().Trim();
                switch (choice.ToUpper())
                {
                    case "NAME": character.Name = ReadString("Enter your Character's name: ", true); return;
                    case "CLASS": character.Class = ChooseClass(); return;
                    case "RACE": character.Race = ChooseRace(); return;
                    case "BIOGRAPHY": character.Biography = ReadString("Enter your Character's Biography (optional):", false); return;
                    case "STRENGTH": character.Strength = ReadInt32("Enter your Character's Strength: ", 1, 100); return;
                    case "INTELLIGENCE": character.Intelligence = ReadInt32("Enter your Character's Intelligence: ", 1, 100); return;
                    case "AGILITY": character.Agility = ReadInt32("Enter your Character's Agility: ", 1, 100); return;
                    case "CONSTITUTION":character.Constitution = ReadInt32("Enter your Character's Constitution: ", 1, 100); return;
                    case "CHARISMA": character.Charisma = ReadInt32("Enter your Character's Charisma: ", 1, 100); return;
                    default: DisplayError("Please enter a valid option"); break;
                }
            } while (true);
        }

        static void DeleteCharacter ()
        {
            if (character == null)
                return;

            if (!ReadBoolean("Are you sure you(Y/N)?"))
                return;

            character = null;
        }

        static bool ReadBoolean (string message)
        {
            Console.WriteLine(message);
            do
            {
                string choice = Console.ReadLine().Trim().Substring(0, 1);

                switch (choice.ToUpper())
                {
                    case "Y": return true;
                    case "N": return false;
                    default: DisplayError("Please enter either Y or N"); break;
                }
            } while (true);
        }

        static void DisplayError (string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static int ReadInt32 ( string message, int minimumValue, int maximumValue )
        {
            Console.Write(message);

            do
            {
                string input = Console.ReadLine();

                int result;
                if (Int32.TryParse(input, out result) && result >= minimumValue && result <= maximumValue)
                    return result;

                DisplayError("The value must be an integral value >= " + minimumValue + " and <= " + maximumValue);
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
    }
}
