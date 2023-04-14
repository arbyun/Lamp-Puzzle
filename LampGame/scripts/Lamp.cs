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
    /// supposed to be a visual indicator of the lamp
    /// </summary>
    internal void DrawSelf() 
    {
        
    }
}