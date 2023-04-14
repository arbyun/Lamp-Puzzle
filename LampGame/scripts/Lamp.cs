using System;

namespace LampGame.scripts;

public class Lamp
{
    public States State = States.Off;

    /// <summary>
    /// Method to switch the lamp's state
    /// </summary>
    internal void SwitchState()
    {
        State = State switch
        {
            // if state is x => turn it into state y
            States.Off => States.On,
            States.On => States.Off,
            _ => State
        };
    }

    /// <summary>
    /// A visual indicator to show the Lamp's state to the user
    /// </summary>
    internal void DrawSelf()
    {
        switch (State)
        {
            case States.On:
                Console.Write("   ___    ");
                Console.WriteLine();
                Console.Write("  /   \\   ");
                Console.WriteLine();
                Console.Write(" |     |  ");
                Console.WriteLine();
                Console.Write(" |\x1b[5m  o\x1b[0m  |  ");
                Console.WriteLine();
                Console.Write(" |     |  ");
                Console.WriteLine();
                Console.Write("  \\___/   ");
                Console.WriteLine();
                break;
            case States.Off:
                Console.Write("   ___    ");
                Console.WriteLine();
                Console.Write("  /   \\   ");
                Console.WriteLine();
                Console.Write(" |     |  ");
                Console.WriteLine();
                Console.Write(" |  ");
                Console.Write("o");
                Console.Write("  |  ");
                Console.WriteLine();
                Console.Write(" |     |  ");
                Console.WriteLine();
                Console.Write("  \\___/   ");
                Console.WriteLine();
                break;
        }
    }
    
    /// <summary>
    /// Another type of indicator for users that choose Accessibility mode
    /// </summary>
    internal void WriteSelf()
    {
        switch (State)
        {
            case States.On:
                Console.Write("ON");
                break;
            case States.Off:
                Console.Write("OFF");
                break;
        }
    }
}