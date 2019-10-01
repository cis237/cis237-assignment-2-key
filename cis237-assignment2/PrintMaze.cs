using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment2
{
    class PrintMaze
    {
        /// <summary>
        /// This method will print the solved maze solution.
        /// It simply puts some extra information before and after printing the solution
        /// </summary>
        public void printSolvedMaze(char [,] maze)
        {
            //Print some beginning start information
            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine("Maze Solution");
            Console.WriteLine("-------------");
            Console.WriteLine();

            //Print the maze
            this.printMaze(maze);

            //Print some ending information
            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine();
        }

        /// <summary>
        /// This method prints out the maze.
        /// </summary>
        public void printMaze(char[,] maze)
        {
            // For each row in the 2d array.
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                // For each column in the 2d array
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    // Set Console Color based on current char.
                    this.setConsoleColor(maze[i, j]);
                    // Print out the current char.
                    Console.Write(maze[i, j]);
                }
                // Print a blank line.
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// This method takes in a char and sets the Console Color based on that char.
        /// </summary>
        private void setConsoleColor(char c)
        {
            if (c == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (c == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (c == '.')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
