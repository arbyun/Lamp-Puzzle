using System;
using System.Threading;
using LampGame.scripts;

namespace LampGame
{
    internal class Program
    {
        private Lamp _lamp01;
        private Lamp _lamp02;
        private Lamp _lamp03;
        private int _numberOfTries;
        private string[] _buttonList;
        private bool _gameOver;

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Lamp Puzzle.\nPress any key to start the game.\n");
            string key = Console.ReadLine();
            
            Console.WriteLine("Do you want to activate accessibility mode?");
            Console.WriteLine("'Accessibility' mode changes blinking visual indicators to words. It's the option to go " +
                              "if your console doesn't display ASCII/escape characters for some reason or if you prefer a " +
                              "cleaner look.\n\n");
            Console.WriteLine("Answer with [Y/N]");
            string mode = Console.ReadLine();

            switch(mode)
            {
                case "Y": 
                    Console.WriteLine("Accessibility mode now activated!");
                    break;
                case "y":
                    Console.WriteLine("Accessibility mode now activated!");
                    break;
            }

            Console.WriteLine("\n\nStarting game...");
            Thread.Sleep(900);
            
            Console.WriteLine("\n------------------------------------------\n");
            Console.WriteLine("\nThere are three buttons. Write its number to press the one you want."); /*"\nSince it's " +
                          "your first time here, you get three free tries to test what each one does. After that," +
                          "you will start spending your tries. When they get to 0, you will lose.");*/

            // game loop here
        }

        /// <summary>
        /// Method to get the input from the user
        /// </summary>
        /// <param name="button">Theoretical button pressed</param>
        private void PressButton(string button)
        {
            
        }
    }
}