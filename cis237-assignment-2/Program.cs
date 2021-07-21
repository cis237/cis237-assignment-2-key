﻿// Author: David Barnes
// Class: CIS 237
// Assignment: 2
using System;

namespace cis237_assignment_2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Increase the console buffer height
            Console.BufferHeight = Int16.MaxValue - 1;

            // Starting Coordinates.
            const int X_START = 1;
            const int Y_START = 1;

            // The first maze that needs to be solved.
            // Note: You may want to make a smaller version to test and debug with.
            // You don't have to, but it might make your life easier.
            char[,] maze1 =
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            // Create a new instance of a mazeSolver.
            MazeSolver mazeSolver = new MazeSolver();

            // Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            // Solve the original maze.
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            // Break between solves
            Console.WriteLine("Press enter to solve the 2nd maze");
            Console.ReadLine();

            // Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// 
        /// It is important that you return a "new" char array as the transposed maze.
        /// If you do not, you could end up only solving the transposed maze.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            // Declare a new maze that will be used
            char[,] transposedMaze = new char[
                mazeToTranspose.GetLength(0),
                mazeToTranspose.GetLength(1)
            ];

            // For each row in the array
            for (int i = 0; i < mazeToTranspose.GetLength(0); i++)
            {
                // For each column in the array
                for (int j = 0; j < mazeToTranspose.GetLength(1); j++)
                {
                    // Flip the x an y coordinates and reassign to the new maze array
                    transposedMaze[j, i] = mazeToTranspose[i, j];
                }
            }

            // Finally return the new maze2
            return transposedMaze;
        }
    }
}
