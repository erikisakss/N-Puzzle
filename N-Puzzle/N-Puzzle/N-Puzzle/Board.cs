using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;


namespace N_Puzzle
{
    public class Board
    {
        //Fields containing the size of the board and the value of the tiles, and the color of the tiles, and the color variations
        int ValueAdder, i, j, MoveCount;
        private ConsoleColor AddColor;
        private int[] ColorVariations = { 14, 15, 12, 13, 10, 11 };
        private bool Shuffled = false, Solved = false, Moved = false;
        Tile[,] tiles, SolvedState;
        //Constructor for the board class that takes in the size of the board and creates a 2d array of tiles, then adds a value and a color to it
        public Board(int size)
        {
            Random random = new Random();

            tiles = new Tile[size, size];
            SolvedState = new Tile[size, size];
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {

                    //Add a random color to each tile without repeating colors

                    AddColor = (ConsoleColor)ColorVariations[random.Next(0, ColorVariations.Length)];

                    tiles[i, j] = new Tile(ValueAdder, AddColor);
                    ValueAdder++;

                }
            }
            SolvedState = (Tile[,])tiles.Clone();
            //Calling the Shuffler function to change the order of the tiles
            Shuffler(tiles);
            //Calling the PrintBoard function to print the board
            PrintBoard();

        }


        //Method that prints the board

        private void PrintBoard()
        {
            //Prints the board
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j].PrintValue();
                }
                Console.WriteLine("\n");

                Console.WriteLine("\n");

            }

            Console.ForegroundColor = ConsoleColor.White;



        }



        //Shuffles the tiles in the 2d array
        private void Shuffler(Tile[,] tiles)
        {

            int size = tiles.GetLength(0);
            int emptyRow = 0;
            int emptyCol = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (tiles[i, j].GetEmpty())
                    {
                        emptyRow = i;
                        emptyCol = j;
                        break;
                    }
                }
            }

            Random random = new Random();
            int count = 0;
            while (count < 1000)
            {
                ArrowDirection direction = (ArrowDirection)random.Next(1, 4);
                int newRow = emptyRow;
                int newCol = emptyCol;
                switch (direction)
                {
                    case ArrowDirection.Up:
                        newRow = emptyRow - 1;
                        break;
                    case ArrowDirection.Down:
                        newRow = emptyRow + 1;
                        break;
                    case ArrowDirection.Left:
                        newCol = emptyCol - 1;
                        break;
                    case ArrowDirection.Right:
                        newCol = emptyCol + 1;
                        break;
                }

                if (newRow >= 0 && newRow < size && newCol >= 0 && newCol < size && (newRow != emptyRow || newCol != emptyCol))
                {
                    SwapElement((ArrowDirection)direction);
                    emptyRow = newRow;
                    emptyCol = newCol;
                    count++;
                }
            }

            Shuffled = true;


        }



        //Method that swaps the tiles in the 2d array

        public void SwapElement(ArrowDirection arrowDirection)
        {
         
            int i = 0, j = 0;
            bool EmptyFound = false;


            for (i = 0; i < tiles.GetLength(0); i++)
            {
                for (j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j].GetEmpty() == true)
                    {
                        EmptyFound = true;
                        

                        break;
                    }
                }
                if (EmptyFound)
                {
                    break;
                }
                
            }

            switch (arrowDirection)
            {
                case ArrowDirection.Up:

                    if (i == 0)
                    {
                        break;
                    }
                    else
                    {
                        Tile temp = tiles[i, j];
                        tiles[i, j] = tiles[i - 1, j];
                        tiles[i - 1, j] = temp;


                    }

                    break;

                case ArrowDirection.Down:

                    if (i == tiles.GetLength(0) - 1)
                    {

                        break;
                    }

                    else
                    {
                        Tile temp = tiles[i, j];
                        tiles[i, j] = tiles[i + 1, j];
                        tiles[i + 1, j] = temp;
                        Moved = true;
                        break;


                    }

                case ArrowDirection.Left:
                    if (j == 0)
                    {
                        break;
                    }
                    else
                    {
                        Tile temp = tiles[i, j];
                        tiles[i, j] = tiles[i, j - 1];
                        tiles[i, j - 1] = temp;
                        Moved = true;
                        break;
                    }

                case ArrowDirection.Right:

                    if (j == tiles.GetLength(1) - 1)
                    {
                        break;
                    }
                    else
                    {
                        Tile temp = tiles[i, j];
                        tiles[i, j] = tiles[i, j + 1];
                        tiles[i, j + 1] = temp;
                        Moved = true;
                        break;
                    }

                default:
                    break;

            }

            if (Shuffled)
            {
                MoveCount++;
                Console.Clear();
                Moved = false;
                PrintBoard();
                Console.WriteLine("Moves: " + MoveCount);
            }





        }


        public int GetMoveCount()
        {
            return MoveCount;
        }


        public bool CheckIfSolved()
        {
            Solved = tiles.Cast<Tile>().SequenceEqual(SolvedState.Cast<Tile>());
            return Solved;

        }





    }
}
