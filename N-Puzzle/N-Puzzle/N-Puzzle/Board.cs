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
        int  ValueAdder, i, j, MoveCount;
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
            PrintBoard(tiles);

        }

        public Tile[,] GetSolvedState()
        {
            return SolvedState;
        }
        public Tile[,] GetTiles()
        {
            return tiles;
        }
        //Method that prints the board

        private void PrintBoard(Tile[,] tiles)
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
                int direction = random.Next(1, 5);
                int newRow = emptyRow;
                int newCol = emptyCol;
                switch (direction)
                {
                    case 1:
                        newRow = emptyRow - 1;
                        break;
                    case 2:
                        newRow = emptyRow + 1;
                        break;
                    case 3:
                        newCol = emptyCol - 1;
                        break;
                    case 4:
                        newCol = emptyCol + 1;
                        break;
                }

                if (newRow >= 0 && newRow < size && newCol >= 0 && newCol < size && (newRow != emptyRow || newCol != emptyCol))
                {
                    SwapElement(newRow * size + newCol + 1);
                    emptyRow = newRow;
                    emptyCol = newCol;
                    count++;
                }
            }

            Shuffled = true;


        }



        //Method that swaps the tiles in the 2d array

        public void SwapElement(int arrowKey)
        {
            int ArrowKey = arrowKey;
            int i = 0, j = 0;
            bool Moved = false;



            switch (ArrowKey)
            {
                case 1:
                    for (i = 0; i < tiles.GetLength(0); i++)
                    {
                        for (j = 0; j < tiles.GetLength(1); j++)
                        {
                            if (tiles[i, j].GetEmpty() == true)
                            {
                               // Console.WriteLine("i: " + i + " j: " + j);
                                if (i == 0)
                                {
                                    
                                    break;
                                }
                                else
                                {
                                    
                                    Tile temp = tiles[i, j];
                                    tiles[i, j] = tiles[i - 1, j];
                                    tiles[i - 1, j] = temp;
                                    break;
                                }
                            }
                        }
                    }
                    


                    break;

                case 2:
                    
                    for (i = 0; i < tiles.GetLength(0); i++)
                    {
                        for (j = 0; j < tiles.GetLength(1); j++)
                        {
                            if (tiles[i, j].GetEmpty() == true)
                            {
                                
                                if (i != tiles.GetLength(0)-1)
                                {
                                    //Print the value of i and j
                                   // Console.WriteLine("i: " + i + " j: " + j);
                                    Tile temp = tiles[i, j];
                                    tiles[i, j] = tiles[i +1, j];
                                    tiles[i +1, j] = temp;
                                    Moved = true;
                                    break;
                                    
                                }
                                else
                                {
                                    
                                    break ;
                                }
                            }
                        }
                        if (Moved)
                        {
                            break;
                        }
                    }

                    break;

                case 3:

                    for (i = 0; i < tiles.GetLength(0); i++)
                    {
                        for (j = 0; j < tiles.GetLength(1); j++)
                        {
                            if (tiles[i, j].GetEmpty() == true)
                            {
                                if (j == 0)
                                {
                                    
                                    break;
                                }
                                else
                                {
                                    Tile temp = tiles[i, j];
                                    tiles[i, j] = tiles[i, j - 1];
                                    tiles[i, j - 1] = temp;
                                    break;
                                }
                            }
                        }
                    }

                    break;

                case 4:

                    for (i = 0; i < tiles.GetLength(0); i++)
                    {
                        for (j = 0; j < tiles.GetLength(1); j++)
                        {
                            if (tiles[i, j].GetEmpty() == true)
                            {
                                if (j == tiles.GetLength(1) - 1)
                                {
                                    
                                    break;
                                }
                                else
                                {
                                    Tile temp = tiles[i, j];
                                    tiles[i, j] = tiles[i, j + 1];
                                    tiles[i, j + 1] = temp;
                                    break;
                                }
                            }
                        }
                    }

                    break;


                    
                default:
                    break;
            }
            
            if (Shuffled)
            {
                MoveCount++;
                Console.Clear();
                Moved = false;
                PrintBoard(tiles);
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
