using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    public class Board
    {
        int Size, ValueAdder;

        public Board(int size)
        {
            Random random = new Random();
            Size = size * size;
            Tile[,] tiles = new Tile[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {


                    tiles[i, j] = new Tile(ValueAdder);
                    ValueAdder++;

                }
            }

            Shuffler(tiles);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j].PrintValue();
                }
                Console.WriteLine();
            }




        }

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









    }
}
