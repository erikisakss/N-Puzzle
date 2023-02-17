using System;


namespace N_Puzzle
{
    public class GameLogic
    {
        Board board;
       
        bool GameOver = false;

        public GameLogic()
        {
            //Input for the size of the board
            Console.WriteLine("Enter the size of the board: ");
            int size = int.Parse(Console.ReadLine());
            Console.Clear();
            board = new Board(size);
           


            MoveTile();
        }

        private void MoveTile()
        {
            while (!GameOver)
            {
                var keyRead = Console.ReadKey(true);

                switch (keyRead.Key)
                {
                    case ConsoleKey.W:
                        board.SwapElement(ArrowDirection.Up);
                        break;
                    case ConsoleKey.S:
                        board.SwapElement(ArrowDirection.Down);
                        break;
                    case ConsoleKey.A:
                        board.SwapElement(ArrowDirection.Left);
                        break;
                    case ConsoleKey.D:
                        board.SwapElement(ArrowDirection.Right);
                        break;
                }

                if (board.CheckIfSolved())
                {
                    Console.WriteLine("You won!");
                    Console.WriteLine("You completed the puzzle in " + board.GetMoveCount() + " moves.");
                    GameOver = true;
                }
            }
        }
    }
}

