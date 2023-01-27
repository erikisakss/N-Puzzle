using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    
    public class Tile
    {
        private int Value;
        private bool IsEmpty = false;
        private ConsoleColor TileColor;


        public Tile(int value, ConsoleColor color) { 

            Value = value;
            if (Value == 0)
            {
                TileColor = ConsoleColor.Black;
                IsEmpty = true;
            }
            else
            {
                TileColor = color;
            }
            
        }


        public int GetValue()
        {
            return Value;
        }


        public void PrintValue()
        {
            //Print rectangle shapes with the color of TileColor and the value of Value


            //Print squares using *'s with the color of TileColor and the value of Value inside
            Console.ForegroundColor = TileColor;









         

             Console.Write(String.Format("{0}\t", Value));
            
        }
        


    }
}
