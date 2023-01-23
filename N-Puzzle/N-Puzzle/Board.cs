using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    public class Board
    {
        int Size;
        Random random = new Random();
        public Board(int size)
        {

            Size = size * size;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Tiles[,] tile = new Tiles[i, j];

                    if (i==0)
                    {
                        tile[i, j].SetValue(i);
                    }
                    else
                    {
                        tile[i,j].SetValue(random.Next(0, Size));
                    }
                    
                }
            }

            

            //Shuffle Tile positions in array based on Size

            

            









        }









    }
}
