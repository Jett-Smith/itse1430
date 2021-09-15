/*
 * 
 * 
 * 
 */
using System;

namespace JettSmith.AdventureGame.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Jett Smith");
            Console.WriteLine("ITSE 1430 - Fall 2021");
            Console.WriteLine("Adventure Game");
            Console.WriteLine("----------------------");
            Console.ResetColor();
            Console.WriteLine();

            DemonKingDoor();
        }
        static void DemonKingDoor()
        {
            Console.WriteLine("Coming out of the portal, you've entered the Demon King's realm.");
            Console.WriteLine("Standing before you is a large stone, with eight symbols forming");
            Console.WriteLine("a square around a clawed handprint.");


        }
        static char HandleQuit()
        {
            Console.WriteLine("Are you sure you wish to quit(Y/N)?");
            do
            {

            } while (true);
        }
        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
