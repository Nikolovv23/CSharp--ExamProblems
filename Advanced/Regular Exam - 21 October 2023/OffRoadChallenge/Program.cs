//There will be two sequences of integers. The first sequence will represent the initial fuel and the second -
//additional consumption index due to thin air at high altitudes, hence higher fuel consumption. There will also be a third sequence of integers,
//representing values equal to the necessary amount of fuel needed to reach the corresponding altitude in the challenge.
//
//Your task is to take the last fuel quantity from the fuel sequence and the first index from the additional consumption index sequence.
//Subtract the values and check the result. 
//•	The corresponding altitude is reached if the calculated result is bigger or equal to the first element from the needed amount of fuel sequence.
//You need to remove both the fuel and the consumption index from their sequences as well as the needed amount of fuel index from their sequence.
//•	If the calculated result is smaller or not equal to the first element from the needed amount of fuel sequence,
//the corresponding altitude is not reached, movement cannot continue, and the program should end.
//Input
//•	The first line will represent the initial fuel – integers, separated by a single space.
//•	The second line will represent the consumption indexes that decrease initial fuel – integers, separated by a single space.
//•	The third line will represent the quantities needed to reach the corresponding altitude – integers, separated by a single space.
//Output
//•	On the first or the next n lines, output the corresponding message on the console from the following options:
//	If John reaches the altitude, print the message:
//o   "John has reached: Altitude 1"
//o	…
//o	"John has reached: Altitude {n}"
//	If John fails to reach the altitude, print the message:
//o   "John did not reach: Altitude {n}"
//•	On the next lines, based on whether he reached the top or not, print the following on the console in the specified format:
//	If John doesn't have enough fuel to reach the top but has reached some altitude, display the following messages:
//o	"John failed to reach the top.
//Reached altitudes: Altitude 1, … Altitude {n}"
//	If John does not have enough fuel to reach the top and has not reached any altitude, print:
//o   "John failed to reach the top.
//John didn't reach any altitude."
//	If John manages to reach all the altitudes, he will reach the top. End the program and print on the console the following message:
//o   "John has reached all the altitudes and managed to reach the top!"
//
//Constraints
//•	All the given numbers will be valid integers in the range [1, 200].
//•	All sequences always consist of four elements.
//•	There will be no negative input.

//    Input:
//200 90 40 100
//20 40 30 50
//50 60 80 90
//    Output:
//John has reached: Altitude 1
//John did not reach: Altitude 2
//John failed to reach the top.
//Reached altitudes: Altitude 1


namespace OffRoadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuel = new Stack<int>();
            Queue<int> consumption = new Queue<int>();
            int[] fuelAmounght = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] fuelConsumption = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int[] fuelNeeded = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            for (int i = 0; i < fuelAmounght.Length; i++)
            {
                fuel.Push(fuelAmounght[i]);
            }
            for (int i = 0; i < fuelConsumption.Length; i++)
            {
                consumption.Enqueue(fuelConsumption[i]);
            }

            bool IsHeWin = true;
            for (int i = 0; i < fuelNeeded.Length; i++)
            {
                if (fuel.Peek() - consumption.Peek() >= fuelNeeded[i])
                {
                    Console.WriteLine($"John has reached: Altitude {i + 1}");
                    fuel.Pop();
                    consumption.Dequeue();
                    continue;
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {i + 1}");
                    IsHeWin = false;
                    break;
                }
            }
            if (IsHeWin)
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
            else
            {
                if (fuel.Count == fuelNeeded.Length)
                {
                    Console.WriteLine("John failed to reach the top.");
                    Console.WriteLine("John didn't reach any altitude.");
                }
                else
                {
                    Console.WriteLine("John failed to reach the top.");
                    Console.Write("Reached altitudes: ");
                    for (int i = 1; i <= fuelNeeded.Length - fuel.Count; i++)
                    {
                        if (i == fuelNeeded.Length - fuel.Count)
                        {
                            Console.Write($"Altitude {i}");
                            return;
                        }
                        Console.Write($"Altitude {i}, ");
                    }
                }
            }
        }
    }
}
