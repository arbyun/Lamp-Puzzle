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
            Console.WriteLine("[ 1 | Switch Lamp 1 ]   [ 2 | Switch Lamp 1 with Lamp 2 ]   [ 3 | Switch Lamp 2 with Lamp 3 ]\n\n");
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
            
        }
    }
}