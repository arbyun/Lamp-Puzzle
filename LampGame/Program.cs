using System;
using System.Threading;
using LampGame.scripts;

namespace LampGame
{
    internal static class Program
    {
        private static readonly Lamp Lamp01 = new Lamp();
        private static readonly Lamp Lamp02 = new Lamp();
        private static readonly Lamp Lamp03 = new Lamp();
        private static int _numberOfTries;
        private static bool _gameOver;
        private static bool _accessibility;
        //not sure we'll need this
        //private static string[] _buttonList;

        private static void Main(string[] args)
        {
            Lamp01.State = States.Off;
            Lamp02.State = States.Off;
            Lamp03.State = States.Off;
            
            // set bools to false initially
            _gameOver = false;
            _accessibility = false;
            
            Console.WriteLine("Welcome to the Lamp Puzzle.\n\n");
            
            Console.WriteLine("Do you want to activate accessibility mode?");
            Console.WriteLine("'Accessibility' mode changes blinking visual indicators to words. It's the option to go " +
                              "if your console doesn't display ASCII/escape characters for some reason or if you prefer a " +
                              "cleaner look.\n\n");
            Console.WriteLine("Answer with [Y/N]");
            string mode = Console.ReadLine();

            /*switch(mode)
            {
                case "Y": 
                    Console.WriteLine("Accessibility mode now activated!");
                    break;
                case "y":
                    Console.WriteLine("Accessibility mode now activated!");
                    break;
            }*/
            
            //a simple if would suffice...

            if (mode == "Y" | mode == "y")
            {
                Console.WriteLine("Accessibility mode now activated!");
                _accessibility = true;
            }
            
            Console.WriteLine("\nPress any key to start the game.\n");
            //we can just use readkey
            //string key = Console.ReadLine();
            Console.ReadKey();

            Console.WriteLine("\n\nStarting game...");
            Thread.Sleep(900);
            
            Console.WriteLine("\n------------------------------------------\n");
            Console.WriteLine("\nThere are three buttons. Write its number to press the one you want."); /*"\nSince it's " +
                          "your first time here, you get three free tries to test what each one does. After that," +
                          "you will start spending your tries. When they get to 0, you will lose.");*/

            GameLoop();
        }
        
        private static void DrawAllLamps()
        {
            Lamp01.DrawSelf();
            Lamp02.DrawSelf();
            Lamp03.DrawSelf();
        }

        private static void DrawAllButtons()
        {
            Console.WriteLine("[ 1 ]   [ 2 ]   [ 3 ]\n\n");
            Console.WriteLine(_numberOfTries + " out of 6 tries.");
        }

        private static void WriteAllLamps()
        {
            Console.Write("Lamp 01: ");
            Lamp01.WriteSelf();
            Console.WriteLine();
            Console.Write("Lamp 02: ");
            Lamp02.WriteSelf();
            Console.WriteLine();
            Console.Write("Lamp 03: ");
            Lamp03.WriteSelf();
            Console.WriteLine();
        }

        private static void GameLoop()
        {
            
        }

        /// <summary>
        /// Method to get the input from the user
        /// </summary>
        /// <param name="button">Theoretical button pressed</param>
        private static void PressButton(string button)
        {
            
        }
    }
}