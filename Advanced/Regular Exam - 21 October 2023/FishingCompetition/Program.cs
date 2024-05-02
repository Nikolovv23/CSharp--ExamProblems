// You will be given an integer n for the size of the fishing area with a square shape. On the next n lines, you will receive the rows of the fishing area.
// You will be placed in a random position, marked with the letter 'S'. There will be fishing passages on random positions, marked with a single digit.
// Whirlpools may also be marked with 'W'. All of the empty positions will be marked with '-'.
// Each turn until the "collect the nets" command is received you will be given commands for your movement. Move commands will be:
// "up", "down", "left", and "right".
// •	If you move to a fish passage, you collect the amount equal to the digit there, the passage disappears and should be replaced by '-'.
// •	If you fall into a whirlpool – the ship sinks and loses its catch, the program ends. 
// •	If you leave the fishing area (go out of the boundaries of the matrix)
// depending on the move command you will be moved to the opposite side of the one you were on. 
// /Example: In a 3x3 matrix you are at position [1,2] and receive the command "right" you will be moved to position [1, 0]./
//  You need at least 20 tons of fish to be considered a successful season. Keep in mind that even if the quotа is reached the ship continues to move.
// Input
// •	On the first line, you are given the integer n – the size of the square matrix.
// •	The next n lines hold the values for every row.
// •	On each of the next lines, you will get a move command.
// Output
// •	On the first line:
// 	If the ship falls into a whirlpool, print only this message and stop the program: 
// o   "You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [n,n]"
// 	If the ship reaches the quota: 
// o   "Success! You managed to reach the quota!"
// 	If the ship did not reach the quota: 
// o   "You didn't catch enough fish and didn't reach the quota!
// You need {lack of fish} tons of fish more."
// •	On the next line.
// 	If the catch quantity is bigger than zero, print:
// o   "Amount of fish caught: {quantity} tons."
// 	else: do not print anything.
// 	If you didn't get into a whirlpool, print the matrix.
// Constraints
// •	The size of the square matrix will be between [2…10].
// •	Only the letters 'S' and 'W' will be present in the matrix.
// •	The fish passages are represented by single positive digits /tons/ between [1…9].
// •	It is expected that there will only be either zero or one whirpool present, marked with the letter - 'W'.
// •	Your position will be marked with 'S'.

//     Input:
// 4
// ---S
// ----
// 9-5-
// 34--
// down
// down
// right
// down
// collect the nets
//     Output:
// You didn't catch enough fish and didn't reach the quota! You need 8 tons of fish more.
// Amount of fish caught: 12 tons.
// ----
// ----
// --5 -
// S4--

namespace FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rolsAndCols = int.Parse(Console.ReadLine());
            char[,] fishingArea = new char[rolsAndCols, rolsAndCols];
            int myRow = 0;
            int myCol = 0;
            for (int row = 0; row < rolsAndCols; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < rolsAndCols; col++)
                {
                    fishingArea[row, col] = currentRow[col];
                    if (fishingArea[row, col] == 'S')
                    {
                        myRow = row;
                        myCol = col;
                    }
                }
            }
            fishingArea[myRow, myCol] = '-';
            string command = default;
            int catchedFish = 0;
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                if (command == "down")
                {
                    myRow++;
                    if (myRow > rolsAndCols - 1)
                    {
                        myRow = 0;
                    }
                }
                else if (command == "up")
                {
                    myRow--;
                    if (myRow < 0)
                    {
                        myRow = rolsAndCols - 1;
                    }
                }
                else if (command == "right")
                {
                    myCol++;
                    if (myCol > rolsAndCols - 1)
                    {
                        myCol = 0;
                    }
                }
                else // command == "left"
                {
                    myCol--;
                    if (myCol < 0)
                    {
                        myCol = rolsAndCols - 1;
                    }
                }

                char currentPosition = fishingArea[myRow, myCol];
                fishingArea[myRow, myCol] = '-';
                if (currentPosition == 'W')
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{myRow},{myCol}]");
                    return;
                }
                if (Char.IsNumber(currentPosition))
                {
                    catchedFish += int.Parse(currentPosition.ToString());
                }
            }
            fishingArea[myRow, myCol] = 'S';
            if (catchedFish >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - catchedFish} tons of fish more.");
            }
            if (catchedFish > 0)
            {
                Console.WriteLine($"Amount of fish caught: {catchedFish} tons.");
            }
            else { }
            for (int row = 0; row < rolsAndCols; row++)
            {
                for (int col = 0; col < rolsAndCols; col++)
                {
                    Console.Write(fishingArea[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
