using System;
using System.Xml.Serialization;

namespace Conways_Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            //for reading clarity, alive = true, dead = false;
            bool alive = true;
            bool dead = false;

            int sizeX = 10; //change array sizes below as well in futureGrid and grid
            int sizeY = 10;

            //present state
            Square[,] grid = new Square[10, 10];

            //future state
            bool[,] futureGrid = new bool[10, 10] 
            { 
                { dead, dead, dead, dead, dead, dead, dead, dead, dead, dead },
                { dead, alive, alive, dead, dead, dead, dead, dead, dead, dead },
                { dead, alive, dead, dead, dead, dead, dead, dead, dead, dead },
                { dead, dead, dead, dead, alive, dead, dead, dead, dead, dead },
                { dead, dead, dead, alive, alive, dead, dead, dead, dead, dead },
                { dead, dead, dead, dead, dead, dead, dead, dead, alive, dead },
                { dead, dead, dead, dead, dead, dead, dead, dead, alive, dead },
                { dead, dead, dead, dead, dead, dead, dead, dead, alive, dead },
                { dead, dead, dead, dead, dead, dead, dead, dead, dead, dead },
                { dead, dead, dead, dead, dead, dead, dead, dead, dead, dead },
            };

            //Loop through 1a) display rows 1b) display colums 2) update the grid, check neighbors live status, 3) make old grid new grid and do it again, with pause
            for (int k = 0; k < 500; k++)
            {
                //set grid values, from previous (or first) gen
                for (int i = 0; i < sizeY; i++)
                {
                    for (int j = 0; j < sizeX; j++)
                    {
                        grid[i, j] = new Square(futureGrid[i, j]);
                    }
                }

                //clear the screen for next iteration
                Console.Clear();

                //Loop through and print status
                for (int i = 0; i < sizeY; i++)
                {
                    for (int j = 0; j < sizeX; j++)
                    {
                        grid[i, j].PrintCurrentGen();
                    }

                    //next row
                    Console.Write("\n");
                }

                //Draw line to see iterations
                PrintLine("--------------------------------------------------", false);

                bool neighborN; bool neighborS; bool neighborE; bool neighborW;
                bool neighborNE; bool neighborNW; bool neighborSE; bool neighborSW;

                //Update for next round
                for (int i = 0; i < sizeY; i++)
                {
                    for (int j = 0; j < sizeX; j++)
                    {
                        //Tracking for debugging
                        PrintLine("--------------------------------------------------", false);
                        Print("Checking square at (" + i + "," + j + ") and it is " + grid[i, j].AliveStatus() + ":" + neighborStatus(grid, i, j, "0") + "\n", false);

                        //get values for neighbors
                        neighborN = neighborStatus(grid, i - 1, j, "N");
                        neighborS = neighborStatus(grid, i + 1, j, "S");
                        neighborE = neighborStatus(grid, i, j + 1, "E");
                        neighborW = neighborStatus(grid, i, j - 1, "W");
                        neighborNE = neighborStatus(grid, i - 1, j + 1, "NE");
                        neighborNW = neighborStatus(grid, i - 1, j - 1, "NW");
                        neighborSE = neighborStatus(grid, i + 1, j + 1, "SE");
                        neighborSW = neighborStatus(grid, i + 1, j - 1, "SW");
                        Print("cell at (" + i + "," + j + ") N:" + neighborN + " S:" + neighborS + " E:" + neighborE + " W:" + neighborW + " NE:" + neighborNE + " NW:" + neighborNW + " SE:" + neighborSE + " SW:" + neighborSW + "\n", false);

                        //Store alive status for next iteration
                        futureGrid[i, j] = grid[i, j].livesOn(neighborN, neighborS, neighborE, neighborW, neighborNE, neighborNW, neighborSE, neighborSW, false);
                        PrintLine("--------------------------------------------------", false);
                    }
                }

                //Draw line to see iterations
                PrintLine("--------------------------------------------------", false);

                //Wait a couple seconds
                //System.Threading.Thread.Sleep(1000);
            }

            //Wait for user input to end program
            Console.ReadLine();
        }

        //need this method so when we check with squares not on the map we treat those as dead squares
        static bool neighborStatus(Square[,] check, int x, int y, string pos)
        {
            bool debugPrint = false;
            try
            {
                Print("---" + pos + ":Neighbor at (" + x + "," + y + ") is ", debugPrint);
                Print(check[x, y].isAlive + " - (" + x + "," + y + ")\n", debugPrint);
                return check[x,y].isAlive;
                
            }
            catch (IndexOutOfRangeException e)
            {
                Print("a border - (" + x + ", " + y + ")\n", debugPrint);
                return false;
            }

        }
        
        //debugging printing
        static void Print(string phrase, bool output)
        {
            if (output)
            {
                Console.Write(phrase);
            }
        }

        static void PrintLine(string phrase, bool output)
        {
            if (output)
            {
                Console.WriteLine(phrase);
            }
        }
    }
}
