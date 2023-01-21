using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    
    public class Tiles
    {
        private int[] TilesArray;
        private int[] Position;
        private int Size;
        private int EmptyTile;
        private int EmptyTilePosition;

        public Tiles(int size)
        {
            Size = size;
            TilesArray = new int[size * size];
            Position = new int[size * size];
            EmptyTile = size * size;
            EmptyTilePosition = size * size - 1;
            for (int i = 0; i < size * size; i++)
            {
                TilesArray[i] = i + 1;
                Position[i] = i;
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Size * Size; i++)
            {
                int randomIndex = random.Next(0, Size * Size);
                int temp = TilesArray[i];
                TilesArray[i] = TilesArray[randomIndex];
                TilesArray[randomIndex] = temp;
            }
        }


    }
}
