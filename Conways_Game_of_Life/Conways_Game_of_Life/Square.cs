using System;
using System.Collections.Generic;
using System.Text;

namespace Conways_Game_of_Life
{
    class Square
    {
        public bool isAlive;

        
        //Constructor is alive or not
        public Square(bool aliveStatus)
        {
            isAlive = aliveStatus;
        }

        //Use for print loop if alive, prints either X or nothing
        public void PrintCurrentGen()
            {
                if (isAlive)
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write(" ");
                }
            }

        //Check to see if cell will be alive next round
        public bool livesOn(bool neighbor1, bool neighbor2, bool neighbor3, bool neighbor4, bool neighbor5, bool neighbor6, bool neighbor7, bool neighbor8)
        {
            int aliveNeighbors = 0;
           
            //every alive neighbor = 1 point, we determine what to do depending on how many there are 
            if (neighbor1) { aliveNeighbors++; }
            if (neighbor2) { aliveNeighbors++; }
            if (neighbor3) { aliveNeighbors++; }
            if (neighbor4) { aliveNeighbors++; }
            if (neighbor5) { aliveNeighbors++; }
            if (neighbor6) { aliveNeighbors++; }
            if (neighbor7) { aliveNeighbors++; }
            if (neighbor8) { aliveNeighbors++; }

            if (isAlive)
            {
                switch (aliveNeighbors)
                {
                    case 0:
                        return false;
                        break;
                    case 1:
                        return false;
                        break;
                    case 2:
                        return true;
                        break;
                    case 3:
                        return true;
                        break;
                    default:
                        return false;
                        break;
                }
            }
            else if (aliveNeighbors == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
