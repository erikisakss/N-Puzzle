Namn: Erik Isaksson
ID: ein22002


The [N-Puzzle](https://en.wikipedia.org/wiki/15_puzzle) is a sliding puzzle that consists of a frame of numbered square tiles in random order with one tile missing. The object of the puzzle is to place the tiles in order by making sliding moves that use the empty space.

### Your task

In this assignment, you are asked to design a set of C# classes to represent an N-Puzzle game, where N is a perfect square (4,9,16, 25, 36, ...). Use the designed set of classes to develop a playable game with a simple console user interface. The player initially starts with a shuffled board and uses the keyboard to move the empty space up, down, left or right if applicable. Each tile should have a number and a color. 

There are many different ways this assignment can be solved with different merits. It is important that you are able to discuss your solution with respect to the different design concepts of the course. In particular, there is a strong focus on encapsulation, data hiding and the information expert principle.

### Steps

To complete this assignment follow the steps below.

- Design a class diagram detailing the different classes and their connections. 
- Implement the game based on the design. Revise the design if needed - iteration may be necessary.
- Include the class diagram in this GIT repo.
- Update this README.md file to include your name and student ID.

### Design requirements

This lab is intended to be a gentle introduction to C# and object-oriented programming. Our focus is on the encapsulation in combination with data-hiding and the three principles discussed in the course so far: 1) cohesion 2) coupling and 3) information expert. To make this a good exercise in object-oriented programming try to over-design the solution rather than the opposite. There are three hard requirements on your solution:

- Use of at least two classes (not counting the Main class).
- All fields must be private - do not expose fields to writing using a setter!
- No static methods or fields 

While the second demand might seem questionable, it forces us to think in terms of objects and operation on the objects rather that to treat the objects as structures. 
Further, you are encouraged to attempt the following design challenges:

- Try to separate the game logic from the representation of the game state to make the game state reusable for a similar game but with different game rules. 
- Try to separate the rendering of the game from the game state to make the game state reusable for different graphical representations.
- Try to separate the user input handling from the game logic.

All of the above challenges present an interesting tension between cohesion (the above suggested separation increases cohesion) and information expert (e.g. the game logic needs access to information pertaining the game state). Discuss what path forward is reasonable in the setting of this assignment and in the setting of a more advanced game state/game logic/rendering.

### Functional requirements

The finished product should work as follows:

- when the program is started the user is allowed to select the size of the board, e.g., 2 should give a 2x2 board, 3 a 3x3 board and so on
- the board should be randomized to produce a solvable game state
- the user should use the arrow keys to move the empty position (or equivalently, to move tiles into the empty position) until the game is won
- when the game is won the game is ended and the number of moves displayed

Extension to this core gameplay are naturally allowed, but not necessarily encouraged - focus on the object-oriented design!

### Git and handing in

Ensure that you follow the steps below to avoid issues.

1. push frequent small, well documented updates
2. create a *feedback* branch to work in 
3. always push into the *feeback* branch
4. never push into the *main* branch as this prevents you from handing in properly
5. always include your names and student ids in the README.md file - otherwise we might not be able to attribute your assignment to you
6. when done create a pull request from the *feedback* branch into the *main* branch
7. tag both graders as reviewers

### Resources

You might find the following resources helpful.

- If you want to use a program to draw class diagrams [draw.io](https://app.diagrams.net/) is an excellent free tool.
- To shuffle the board use [Random](https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-6.0) class. How can you make sure that the shuffled board is solvable?
- To print the user interface of the game use the [Console](https://learn.microsoft.com/en-us/dotnet/api/system.console?view=net-6.0) class. To change the color, use `Console.ForegroundColor` and `Console.BackgroundColor` to set the color of the text printed by `Console.Write` and `Console.WriteLine`.
- To wait for a keypress use the `Console.ReadKey(boolean)` method. 
- The boolean controls whether the pressed key is echoed to the console or not. The returned `ConsoleKeyInfo` has a `Key` property which allows you to check if `UpArrow`, `DownArrow`, `LeftArrow` or `RightArrow` was pressed.
