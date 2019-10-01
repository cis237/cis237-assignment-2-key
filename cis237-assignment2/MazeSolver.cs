// Author: David Barnes
// Class: CIS 237
// Assignment: 2
using System;

namespace cis237_assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        // Class level var for the maze to solve.
        private char[,] maze;

        // Class level var for the length of the maze in one dimension. (To save typing later).
        private int _mazeLength;

        // Class level var for whether the maze has been solved yet or not.
        private bool _foundExit;

        private PrintMaze printMaze;

        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Assign the passed in maze to the class level var.
            this.maze = maze;

            // Assign the length to save typing later on.
            this._mazeLength = maze.GetLength(0);

            // Initialize found exit to false.
            this._foundExit = false;

            // Make instance of print class
            printMaze = new PrintMaze();

            // Print out the start state of the maze.
            printMaze.printMaze(maze);

            // Make the recursive call to solve the maze.
            mazeTraversal(xStart, yStart);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: mazeTraversal(int currentX, int currentY)
        /// 
        /// This is the recursive method that will call itself and solve the maze.
        /// It is very small and all of the difficult work is performed by the magic of recursion
        /// I have chosen to do work in a clockwise fashion. The first location I check is right, and then work clockwise.
        /// </summary>
        /// <param name="x">X Position in array</param>
        /// <param name="y">Y Position in array</param>
        private void mazeTraversal(int x, int y)
        {
            // Mark the position that we are at when
            // the method is called with an X.
            this.maze[y, x] = 'X';

            // Print out the maze.
            printMaze.printMaze(maze);

            // Call the class level method to check and
            // see if we are standing on the exit.
            // If so, the foundExit flag needs to be flipped.
            this.checkForExit(x, y);

            // **** Move Right ****
            // If we haven't found the exit, and
            // the postion to the right is a valid move,
            // (A period '.') we should move there with the recursive call.
            if (!this._foundExit && maze[y, x + 1] == '.')
            {
                // Make the recursive call to this same function
                // setting the passed in coordinates to the same
                // as the current plus one more in the right direction.
                mazeTraversal(x + 1, y);

                // Print out the maze.
                if (!this._foundExit)
                {
                    printMaze.printMaze(maze);
                }
            }

            // *** Move Down ****
            // Refer to the above comments for moving right.
            // Everything is the same except for the fact
            // that we are moving down instead of right.
            if (!this._foundExit && maze[y + 1, x] == '.')
            {
                mazeTraversal(x, y + 1);
                if (!this._foundExit)
                {
                    printMaze.printMaze(maze);
                }
            }

            // *** Move Left ****
            // Refer to the above comments for moving right.
            // Everything is the same except for the fact
            // that we are moving left instead of right.
            if (!this._foundExit && maze[y, x - 1] == '.')
            {
                mazeTraversal(x - 1, y);
                if (!this._foundExit)
                {
                    printMaze.printMaze(maze);
                }
            }

            // *** Move Up ****
            // Refer to the above comments for moving right.
            // Everything is the same except for the fact
            // that we are moving up instead of right.
            if (!this._foundExit && maze[y - 1, x] == '.')
            {
                mazeTraversal(x, y - 1);
                if (!this._foundExit)
                {
                    printMaze.printMaze(maze);
                }
            }
            //If we reached here, it is because either there was a dead end further down from the recursive call,
            //or, we found the exit and we are backing out of all of the recursive calls. This will print O's along
            //the valid path, but since we have already printed the solved maze in the check for exit method,
            //we don't officially need this check. We could leave the putting down of 'O's without the decision.
            //By having the check though, we could print the maze in the check for exit, or after it backs all the way out.
            if (!_foundExit)
            {
                maze[y, x] = 'O';
            }
        }

        /// <summary>
        /// This method checks for the exit.
        /// It just checks to see if the current passed in position is on the edge of the 2d array.
        /// If the solution if found, it prints the maze in the solved solution.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void checkForExit(int x, int y)
        {
            //See if the current positon in on the outside border of the 2d array
            if (x == 0 || x == (this._mazeLength - 1) || y == 0 || y == (this._mazeLength - 1))
            {
                //Set the class level found exit bool to true
                this._foundExit = true;

                //Print the final solved maze solution
                printMaze.printSolvedMaze(maze);
            }
        }
    }
}
