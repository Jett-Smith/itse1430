/*
 *  Jett Smith
 *  ITSE 1430 - Fall 2021
 */
using System;

namespace JettSmith.AdventureGame.ConsoleHost
{
    class Program
    {
        static int currentX;
        static int currentY;
        const int MaximumX = 3;
        static void Main ( string[] args )
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Jett Smith");
            Console.WriteLine("ITSE 1430 - Fall 2021");
            Console.WriteLine("Adventure Game");
            Console.WriteLine("----------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Coming out of the portal, you've entered the Demon King's realm.");

            currentX = 2;
            currentY = 2;
            bool done = false;
            do
            {
                FindRoomToDisplay();
                char selection = HandleMenu();
                switch (selection)
                {
                    case 'M': MoveRooms(); break;
                    case 'Q': done = true; break;
                }
            } while (!done);
        }
        private static char HandleMenu ()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("What do you wish to do? ");
                Console.ResetColor();

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "INSPECT": FindRoomToDisplay(); break;
                    case "MOVE": return 'M';
                    case "HELP": DisplayHelpOptions(false); break;
                    case "QUIT":
                    {
                        if (HandleQuit()) return 'Q';
                        break;
                    }
                    default: DisplayError("Young Adventurer, going off the advised path is dangerous"); break;
                }
            } while (true);

        }
        private static void DisplayHelpOptions (bool isInMove)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (isInMove)
            {
                Console.WriteLine("north | south | east | west | help");
                Console.WriteLine("north: move north if avilable");
                Console.WriteLine("south: move south if avilable");
                Console.WriteLine("east: move east if avilable");
                Console.WriteLine("west: move west if avilable");
                Console.WriteLine("Help: See the currently available options");
            } 
            else
            {
                Console.WriteLine("inspect | help | move | quit");
                Console.WriteLine("inspect: See the description of the room you are currently in");
                Console.WriteLine("Help: See the currently available options");
                Console.WriteLine("Move: Move to another room");
                Console.WriteLine("Quit: Quit the program");
            }
            Console.ResetColor();
        }
        private static void MoveRooms ()
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Which direction do you wish to go? ");
                Console.ResetColor();

                string direction = Console.ReadLine();
                switch (direction.ToUpper())
                {
                    case "NORTH":
                    {
                        if (currentY != 1)
                        {
                            currentY -= 1;
                            return;
                        }
                        else
                        {
                            DisplayError("The Sea to the North makes travel impossible");
                            break;
                        }
                    }
                    case "SOUTH":
                    {
                        if (currentY != 3)
                        {
                            currentY += 1;
                            return;
                        } 
                        else
                        {
                            DisplayError("The Desert to the South makes travel inadvisable");
                            break;
                        }
                    }
                    case "WEST":
                    {
                        if (currentX != 1)
                        {
                            currentX -= 1;
                            return;
                        } else
                        {
                            DisplayError("The Cliffs to the West makes travel impossible");
                            break;
                        }
                    }
                    case "EAST":
                    {
                        if (currentX != 3)
                        {
                            currentX += 1;
                            return;
                        } 
                        else
                        {
                            DisplayError("The Mountains to the East makes travel inadvisable");
                            break;
                        }
                    }
                    case "HELP": DisplayHelpOptions(true); break;
                    default: DisplayError("Young adventurer, you need to choice an actual direction"); break;
                }
            };
        }
        static void FindRoomToDisplay ()
        {
            int roomNumber = currentX + (MaximumX * (currentY - 1));

            switch (roomNumber)
            {
                case 1: SirenRockDescription(); break;
                case 2: GriffonRoostDescription(); break;
                case 3: LostGodShrineDescription(); break;
                case 4: DryadForrestDescription(); break;
                case 5: DemonKingDoorDescription(); break;
                case 6: TrollBridgeDescription(); break;
                case 7: KingsHallDescription(); break;
                case 8: UndeadGraveyardDescription(); break;
                case 9: DragonHoardDescription(); break;
            }
        }
        static void SirenRockDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("Past the rocky shore, you see a small cove, with");
            Console.WriteLine("a lovely song coming from it. Seated inside is a");
            Console.WriteLine("mermaid, with a golden key around her neck,");
            Console.WriteLine("emblazoned with a blue music note.");
        }
        static void GriffonRoostDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("High above the sea, on the edge of a cliff, you spot");
            Console.WriteLine("a large nest, sitting in it is a large griffon, tied");
            Console.WriteLine("to its beak is a golden key, emblazoned with a brown feather.");
        }
        static void LostGodShrineDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("Built into the mountains is a small shrine, though");
            Console.WriteLine("there seems to no sigh as to who the shrine is for");
            Console.WriteLine("Within a small cage in the shrine is a golden");
            Console.WriteLine("key, emblazoned with a yellow cresent moon.");
        }
        static void DryadForrestDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("You come up to a large grove, within the forest.");
            Console.WriteLine("Sitting there is a beautiful woman that seems to made");
            Console.WriteLine("of plants. The dryad satnds before a massive tree, hanging");
            Console.WriteLine("off a branch is a golden key emblazoned with a green tree.");
        }
        static void DemonKingDoorDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("Standing before you is a large stone, with eight");
            Console.WriteLine("keyholes in a square around a clawed handprint.");
            Console.WriteLine("In order to find those keys, a long journey awaits.");
        }
        static void TrollBridgeDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("Coming across a large bridge, you hear a roar from");
            Console.WriteLine("below, a hideous troll stands below the bridge, tied to");
            Console.WriteLine("its nose is a golden key emblazoned with a black sun.");
        }
        static void KingsHallDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("A large castle sits on the edge of a cliff. Going");
            Console.WriteLine("inside, you see a king witting on his throne. Beside");
            Console.WriteLine("him is a pedestal housing a golden key emlazoned with");
            Console.WriteLine("a yellow crown");
        }
        static void UndeadGraveyardDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("You come across a massive graveyard, with several undead");
            Console.WriteLine("moving about within. Around the neck of the largest");
            Console.WriteLine("zombie is a golden key emblazoned with a white tombstone.");
        }
        static void DragonHoardDescription()
        {
            DisplayCurrentLocation();
            Console.WriteLine("Within a large cave you see a massive red dragon,");
            Console.WriteLine("sleeping on a pile of gold and jewels. On a pedestal");
            Console.WriteLine("sets a golden key, emblazoned with a red flame");
        }
        static bool HandleQuit()
        {
            Console.WriteLine("Are you sure you wish to quit(Y/N)?");
            do
            {
                string choice = Console.ReadLine().Trim();

                switch (choice.ToUpper())
                {
                    case "Y": return true;
                    case "N": return false;
                    default: DisplayError("Please enter either Y or N"); break;
                }
            } while (true);
        }
        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void DisplayCurrentLocation()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You are currently as position (" + currentY + "N, " + currentX + "E)");
            Console.ResetColor();
        }
    }
}
