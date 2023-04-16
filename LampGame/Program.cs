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

        /// <summary>
        /// Main entry point of the puzzle game. Initializes the game state, prompts the user to activate
        /// accessibility mode, displays a tutorial, and starts the game loop.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the program. None are currently available.</param>
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

            if (mode == "Y" | mode == "y")
            {
                Console.WriteLine("Accessibility mode now activated!");
                _accessibility = true;
            }
            
            Console.WriteLine("Starting tutorial...\n\n");
            Thread.Sleep(500);
            Console.Clear();

            if (_accessibility != true)
            {
                Console.WriteLine("A lamp that is turned on looks like this:\n");
                Lamp01.State = States.On;
                Lamp01.DrawSelf();
                Thread.Sleep(200);
                Lamp01.State = States.Off;
                
                Console.WriteLine("\nWhile a lamp that is turned off looks like this:\n");
                Lamp01.DrawSelf();
            }
            else
            {
                Console.WriteLine("A lamp that is turned on looks like this:\n");
                Lamp01.State = States.On;
                Console.Write("Lamp: ");
                Lamp01.WriteSelf();
                Console.WriteLine();
                Thread.Sleep(200);
                Lamp01.State = States.Off;
                
                Console.WriteLine("\nWhile a lamp that is turned off looks like this:\n");
                Console.Write("Lamp: ");
                Lamp01.WriteSelf();
                Console.WriteLine();
            }
            
            
            Console.WriteLine("\nPress any key to start the game.\n");
            Console.ReadKey();

            Console.WriteLine("\n\nStarting game...");
            Thread.Sleep(900);
            Console.Clear();
            Console.WriteLine("\n------------------------------------------\n");
            Console.WriteLine("\nThere are three buttons. Write its number to press the one you want.");

            GameLoop();
        }
        
        /// <summary>
        /// Draws all the lamps in the game.
        /// </summary>
        private static void DrawAllLamps()
        {
            Lamp01.DrawSelf();
            Lamp02.DrawSelf();
            Lamp03.DrawSelf();
        }

        /// <summary>
        /// Draws all the buttons available in the game and displays the number of remaining tries.
        /// </summary>
        private static void DrawAllButtons()
        {
            Console.WriteLine("[ 1 | Switch Lamp 1 ]   [ 2 | Switch Lamp 1 with Lamp 2 ]   [ 3 | Switch Lamp 2 with Lamp 3 ]\n\n");
            Console.WriteLine(_numberOfTries + " out of 6 tries.");
        }

        /// <summary>
        /// Alternative to DrawAllLamps(), instead writes the state of all lamps to the console.
        /// </summary>
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

        /// <summary>
        /// Main game loop that handles the game logic and user input.
        /// Displays the lamps and buttons, reads user input, updates the game state, and checks for a win condition.
        /// If the player wins, displays a message and prompts for a restart or exit.
        /// If the player loses, displays a Game Over message and prompts for a restart.
        /// </summary>
        private static void GameLoop()
        {
            bool win = false;
        
            // instead of a while loop, we do a loop until _gameOver is toggled
            do
            {
                while (_numberOfTries < 6)
                {
                    if (_accessibility)
                    {
                        WriteAllLamps();
                    }
                    else
                    {
                        DrawAllLamps();
                    }
                    Console.WriteLine();
                    DrawAllButtons();

                    // we only want the press of a key here, so the player understands they should only input the number
                    var input = Console.ReadKey(true).KeyChar;
                    
                    // if input is valid, we parse it into an actual int number, call the function that simulates
                    // the pressing of a button and then add to the number of tries
                    if (input is '1' or '2' or '3')
                    {
                        var buttonIndex = int.Parse(input.ToString());
                        PressButton(buttonIndex);
                        _numberOfTries++;
                    }
                    else
                    {
                        Console.WriteLine("That's not a button. Try it again, this time writing either 1, 2 or 3.");
                    }
                    Console.Clear();

                    if (Lamp01.State is States.On && Lamp02.State is States.On && Lamp03.State is States.On)
                    {
                        Console.Clear();
                        Console.WriteLine("YOU WIN!\n\nPress any key to restart or ESC to quit.");
                        if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                        {
                            Console.Clear();
                            _numberOfTries = 0;
                            Main(new []{""});
                        }

                        win = true;
                        QuitGame();
                        break;
                    }
                }

                _gameOver = true;

            } while (_gameOver is false);

            // if we lose, aka if _gameOver is true, we reset all variables and display a Game Over message
            if (!win)
            {
               _numberOfTries = 0; 
               Console.Clear();
               Console.WriteLine("GAME OVER\n\n\nPress any key to restart.");
               Console.ReadKey();
               Console.Clear();
               _accessibility = false;
               Main(new[] { "" }); 
            }
        }
        
        /// <summary>
        /// Exits the game by clearing the console and resetting mode.
        /// </summary>
        private static void QuitGame()
        {
            Console.Clear();
            _numberOfTries = 7; // we set it into 7 instead of resetting it because if we don't it will go into the loop again
            _accessibility = false; // reset accessibility
            Console.WriteLine("\nThanks for playing!\n");
            _numberOfTries = 0; // this shouldn't be needed, but just in case
        }

        /// <summary>
        /// Method to get the input from the user
        /// </summary>
        /// <param name="button">Theoretical button pressed</param>
        private static void PressButton(int button)
        {
            switch (button)
            {
                case 1:
                    Lamp01.SwitchState();
                    break;
                case 2:
                    // if states are not equal, change them
                    if (Lamp01.State != Lamp02.State)
                    {
                        Lamp01.SwitchState();
                        Lamp02.SwitchState();
                    }
                    break;
                case 3:
                    if (Lamp02.State != Lamp03.State)
                    {
                        Lamp02.SwitchState();
                        Lamp03.SwitchState();
                    }
                    break;
            }
        }
    }
}