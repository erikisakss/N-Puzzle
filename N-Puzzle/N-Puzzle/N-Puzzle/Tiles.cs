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
        int Value;

        
        public Tile(int value) {

            Value = value;
        
        }
        

        public void PrintValue()
        {
            
            //Color red = new Color();

            Console.Write(Value + " ");
        }
        


    }
}
