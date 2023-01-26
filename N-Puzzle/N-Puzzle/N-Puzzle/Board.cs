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
        int Size, ValueAdder, i, j;
        private ConsoleColor AddColor;
        private int[] ColorVariations = { 14, 15, 12, 13, 10, 11 };
        Tile[,] tiles;
        //Constructor for the board class that takes in the size of the board and creates a 2d array of tiles, then adds a value and a color to it
        public Board(int size)
        {
            Random random = new Random();
            Size = size * size;
            Tile[,] tiles = new Tile[size, size];
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
            //Calling the Shuffler function to change the order of the tiles
            Shuffler(tiles);
            //Calling the PrintBoard function to print the board
            PrintBoard(tiles);

        }


        public void PrintBoard(Tile[,] tiles)
        {
            //Prints the board
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j].PrintValue();
                }
                Console.WriteLine("\n");
                for (int k = 0; k < tiles.GetLength(0) * tiles.GetLength(1); k++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("* ");
                }
                Console.WriteLine("\n");

            }

            Console.ForegroundColor = ConsoleColor.White;
        }



        //Shuffles the tiles in the 2d array
        private void Shuffler(Tile[,] tiles)
        {

            var rng = new Random();
            //Randomize the tile 2d array
            
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    int randomRow = rng.Next(0, tiles.GetLength(0));
                    int randomColumn = rng.Next(0, tiles.GetLength(1));
                    Tile temp = tiles[i, j];
                    tiles[i, j] = tiles[randomRow, randomColumn];
                    tiles[randomRow, randomColumn] = temp;
                }
            }
        
       


        }

        public void SwapElement(string arrowKey)
        {
            string ArrowKey = arrowKey;


            Tile temp = tiles[i, j];


            switch (ArrowKey)
            {
                case "up":

                    break;

                case "down":

                    break;

                case "left":

                    break;

                case "right":

                    break;



                default:
                    break;
            }





        }







    }
}
