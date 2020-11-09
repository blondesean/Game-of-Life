using System;

namespace Conways_Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            //for reading clarity, alive = true, dead = false;
            bool alive = true;
            bool dead = false;

            int sizeX = 6;
            int sizeY = 6;

            //present state
            Square[,] grid = new Square[6, 6]
            { 
                {new Square(dead),new Square(dead),new Square(dead),new Square(dead),new Square(dead),new Square(dead) },
                {new Square(dead),new Square(dead),new Square(alive),new Square(dead),new Square(dead),new Square(dead) },
                {new Square(dead),new Square(dead),new Square(alive),new Square(dead),new Square(dead),new Square(dead) },
                {new Square(dead),new Square(dead),new Square(alive),new Square(dead),new Square(dead),new Square(dead) },
                {new Square(dead),new Square(dead),new Square(dead),new Square(dead),new Square(dead),new Square(dead) },
                {new Square(dead),new Square(dead),new Square(dead),new Square(dead),new Square(dead),new Square(dead) }
            };

            //future state
            Square[,] futureGrid = new Square[5, 5];

            futureGrid = grid;

            //testing output
            //grid[0, 0].PrintCurrentGen();
            //Console.WriteLine("\n" + grid[0,0].livesOn(alive, alive, alive, alive));
            //Console.WriteLine(grid[0, 0].livesOn(alive, alive, alive, dead));
            //Console.WriteLine(grid[0, 0].livesOn(alive, alive, dead, dead));
            //Console.WriteLine(grid[0, 0].livesOn(alive, dead, dead, dead));

            //Loop through 1a) display rows 1b) display colums 2) update the grid, check neighbors live status, 3) make old grid new grid and do it again, with pause
            for (int k = 0; k < 5; k++)
            {
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

                bool neighborN; bool neighborS; bool neighborE; bool neighborW;
                bool neighborNE; bool neighborNW; bool neighborSE; bool neighborSW;

                //Update for next round
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        //get values for neighbors
                        neighborN = neighborStatus(grid, i - 1, j);
                        neighborS = neighborStatus(grid, i + 1, j);
                        neighborE = neighborStatus(grid, i, j + 1);
                        neighborW = neighborStatus(grid, i, j - 1);
                        neighborNE = neighborStatus(grid, i - 1, j + 1);
                        neighborNW = neighborStatus(grid, i - 1, j - 1);
                        neighborSE = neighborStatus(grid, i + 1, j + 1);
                        neighborSW = neighborStatus(grid, i + 1, j - 1);

                        Console.Write("cell at (" + i + "," + j + ") N:" + neighborN + " S:" + neighborS + " E:" + neighborE + " W:" + neighborW + " NE:" + neighborNE + " NW:" + neighborNW + " SE:" + neighborSE + " SW:" + neighborSW + "\n");
                        //set new alive status
                        futureGrid[i, j].isAlive = grid[i, j].livesOn(neighborN, neighborS, neighborE, neighborW, neighborNE, neighborNW, neighborSE, neighborSW);
                        //Console.WriteLine("Square at " + i + "," + j + " is " + grid[i, j].isAlive);
                    }
                }

                //replace the current grid with the future grid
                grid = futureGrid;

                //Draw line to see iterations
                Console.WriteLine("----------------------------------------");

                //Wait a couple seconds
                System.Threading.Thread.Sleep(2000);
            }

                //Wait for user input to end
                Console.ReadLine();
        }

        //need this method so when we check with squares not on the map we treat those as dead squares
        static bool neighborStatus(Square[,] check, int x, int y)
        {
            try
            {
                return check[x,y].isAlive;
            }
            catch (IndexOutOfRangeException e)
            {
                return false;
            }

        }
    }
}
