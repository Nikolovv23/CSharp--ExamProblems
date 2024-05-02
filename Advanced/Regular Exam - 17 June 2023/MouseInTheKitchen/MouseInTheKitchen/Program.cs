// In the beginning, you will be given N and M – integers, separated by a comma - ",", indicating the cupboard’s area dimensions.
// On the next N lines, you will receive strings, representing the rows of the area, with M columns.
// After that, on each line, until the command "danger" appears as an input string, you will receive the possible directions for the mouse to move
// - "up", "down", "right", and "left". 
// If the mouse steps outside the cupboard area, the cat will attack, and the cheese hunt is over. In that case, the program ends,
// keep the last known position of the mouse, before it steps outside the cupboard, and the following message is printed on the Console:
// "No more cheese for tonight!"
// Possible characters in the matrix are:
// •	M - represents the mouse's position.
// •	C – represents a piece of cheese. 
// •	* – represents an empty position, nothing happens if the mouse steps on it.
// •	@ – represents a wall in the cupboard, cannot step on or go through it.
// •	T – represents a trap.
// The mouse starts from the M - position.
// •	If the mouse steps on C – position, it eats the cheese from the field, and the position is marked with "*". 
// o	If this is the last cheese in the cupboard area, the mouse goes to sleep. Remember that this will be the last known position of the mouse.
// The program ends and the following message is printed on the Console: "Happy mouse! All the cheese is eaten, good night!"
// •	If the mouse steps into a trap (T -position), it will be trapped. Remember that this will be the last known position of the mouse. In that case,
// the program ends, and the following message is printed on the Console: "Mouse is trapped!"
// •	If the given direction leads the mouse towards @ - position, this is a wall in the cupboard area. Do not make the move and skip the command.
// •	If the "danger" command is received before the mouse manages to eat all the cheese, the mouse disappears.
// Remember that this will be the last known position of the mouse and you will need it for the final state of the matrix.
// In that case, the program ends, and the following message is printed on the Console: "Mouse will come back later!"
// In the end, print the final state of the matrix (cupboard area) with the last known position of the mouse in it. Each row on a new line.
// Input
// •	On the first line you will get the number of rows and columns of the matrix, separated by a comma.
// •	On the next N lines, you will receive strings, representing each row of the matrix.
// •	On each of the following lines, until the command "danger" appears as an input string, you will receive the possible directions for the mouse to move
// - "up", "down", "right", and "left".
// •	"danger" command – The mouse spots danger and disappears… for now!
// Output
// •	On the first line:
// o If the mouse steps outside the cupboard 
// "No more cheese for tonight!"
// 
// o	If the mouse manages to eat all the cheese
// "Happy mouse! All the cheese is eaten, good night!"
// 
// o	If the mouse steps into a trap (T -position)
// "Mouse is trapped!"
// 
// o	If the "danger" command is received before the mouse manages to eat all the cheese – 
// "Mouse will come back later!"
// 
// •	On the next lines, print the final state of the matrix with the last known position of the mouse in it. Each row - on a new line.
// Constraints
// •	There will always be at least one trap in the cupboard.
// •	There will always be some cheese in the cupboard.
// •	There will always be a "danger" command in the end, but it is not necessary to reach it. The program may end earlier.
// •	Each row of the matrix will have the same length.
 
//      Input:
// 5,5
// **M**
// T@@**
// CC@**
// **@@*
// **CC*
// left
// down
// left
// down
// down
// down
// right
// danger 
//      Output:
// Mouse is trapped!
// *****
// M@@**
// CC@**
// **@@*
// **CC*


namespace MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] matrix = new char[rows, cols];
            int currentRow = 0;
            int currentCol = 0;
            int cCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                string chars = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                    if (matrix[row, col] == 'M')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (matrix[row, col] == 'C')
                    {
                        cCounter++;
                    }
                }
            }
            matrix[currentRow, currentCol] = '*';

            string command = default;
            while ((command = Console.ReadLine()) != "danger")
            {

                if (command == "up")
                {
                    currentRow--;
                    if (currentRow < 0)
                    {
                        currentRow++;
                        Console.WriteLine("No more cheese for tonight!");
                        matrix[currentRow, currentCol] = 'M';
                        PrintMAtrix(rows, cols, matrix);
                        return;
                    }
                    if (matrix[currentRow, currentCol] == '@')
                    {
                        currentRow++;
                        continue;
                    }
                }
                else if (command == "down")
                {
                    currentRow++;
                    if (currentRow >= rows)
                    {
                        currentRow--;
                        Console.WriteLine("No more cheese for tonight!");
                        matrix[currentRow, currentCol] = 'M';
                        PrintMAtrix(rows, cols, matrix);
                        return;
                    }
                    if (matrix[currentRow, currentCol] == '@')
                    {
                        currentRow--;
                        continue;
                    }
                }
                else if (command == "left")
                {
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol++;
                        Console.WriteLine("No more cheese for tonight!");
                        matrix[currentRow, currentCol] = 'M';
                        PrintMAtrix(rows, cols, matrix);
                        return;
                    }
                    if (matrix[currentRow, currentCol] == '@')
                    {
                        currentCol++;
                        continue;
                    }
                }
                else // command == "right"
                {
                    currentCol++;
                    if (currentCol >= cols)
                    {
                        currentCol--;
                        Console.WriteLine("No more cheese for tonight!");
                        matrix[currentRow, currentCol] = 'M';
                        PrintMAtrix(rows, cols, matrix);
                        return;
                    }
                    if (matrix[currentRow, currentCol] == '@')
                    {
                        currentCol--;
                        continue;
                    }
                }

                char currentPosition = matrix[currentRow, currentCol];

                if (currentPosition == 'C')
                {
                    matrix[currentRow, currentCol] = '*';
                    cCounter--;
                    if (cCounter == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        matrix[currentRow, currentCol] = 'M';
                        PrintMAtrix(rows, cols, matrix);
                        return;
                    }

                }
                else if (currentPosition == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    matrix[currentRow, currentCol] = 'M';
                    PrintMAtrix(rows, cols, matrix);
                    return;
                }
            }
            if (cCounter > 0)
            {
                Console.WriteLine("Mouse will come back later!");
            }
            matrix[currentRow, currentCol] = 'M';
            PrintMAtrix(rows, cols, matrix);
        }

        private static void PrintMAtrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
