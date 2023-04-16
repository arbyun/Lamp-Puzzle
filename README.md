# Lamp Puzzle

A small and short console puzzle game about turning light bulbs on.

## Overview

This project involves three lamps and three buttons that can toggle the state of these lamps. The player will have six attempts to link them by clicking on one of three different buttons, each with a different outcome. The main game loop runs until the game is won or the player runs out of tries, at which point the game is over. 

The game loop first displays the current state of the lamps and the buttons, and then waits for the player to input a button number (1, 2, or 3) to press. If the input is valid, the corresponding button is pressed, the number of tries is incremented, and the loop continues. If all three lamps are on after a button is pressed, the player wins the game and is given the option to restart or quit. If the game is over due to running out of tries, the player is given the option to restart.

This project also handles switching between two display modes, text or graphical, for the user's convenience.

Here's a quick rundown of the output of each of the buttons available.

| Button | Description |
| --- | --- |
| `1` | switches the state of the first lamp between ON/OFF |
| `2` | if buttons one or two have different states, switches the states between them |
| `3` | if buttons two or three have different states, switches the states between them |

### Flowchart

Here's a flowchart that connects the methods and files used, for a better structured/architectural understanding of the project.


![Fluxogram_LampGame](https://user-images.githubusercontent.com/115217686/232330018-66b61d32-2611-4bdc-935a-55871120adaf.png)

## Metadata

* @arbyun a.k.a. Daniela Dantas, a22202104
-- Lamp class, diverse Draw and Write functions, GameLoop, overall code cleanup

* @Francisco-Anjos a.k.a. Francisco Anjos, a22204855
-- User instructions, tutorial, lamp switching, flowchart, overview

## License

Released under the MIT License.
