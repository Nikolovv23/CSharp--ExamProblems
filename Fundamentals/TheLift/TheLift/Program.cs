// Write a program that finds a place for the tourist on a lift. 
// Every wagon should have a maximum of 4 people on it. If a wagon is full, you should direct the people to the next one with space available.
// Input
// •	On the first line, you will receive how many people are waiting to get on the lift
// •	On the second line, you will receive the current state of the lift separated by a single space: " ".
// Output
// When there is no more available space left on the lift, or there are no more people in the queue,
// you should print on the console the final state of the lift's wagons separated by " " and one of the following messages:
// •	If there are no more people and the lift has empty spots, you should print:
// "The lift has empty spots!
// { wagons separated by ' '}
// "
// •	If there are still people in the queue and no more available space, you should print:
// "There isn't enough space! {people} people in a queue!
// { wagons separated by ' '}
// "
// •	If the lift is full and there are no more people in the queue, you should print only the wagons separated by " ".

//     Input:
// 15
// 0 0 0 0
//     Output:
// The lift has empty spots!
// 4 4 4 3


namespace TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int touristCount = int.Parse(Console.ReadLine());
            if (touristCount < 0)
            {
                touristCount = 0;
            }

            List<int> freeSeats = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < freeSeats.Count; i++)
            {
                int seatsCount = freeSeats[i];

                while (seatsCount < 4)
                {
                    seatsCount++;
                    touristCount--;
                    if (touristCount <= 0)
                    {
                        if (touristCount < 0)
                        {
                            seatsCount--;
                        }
                        touristCount = 0;

                        break;
                    }
                }

                freeSeats.RemoveAt(i);
                freeSeats.Insert(i, seatsCount);

                if (touristCount == 0)
                {

                    break;
                }
            }

            if (touristCount == 0 && freeSeats[freeSeats.Count - 1] == 4)
            {
                Console.WriteLine(string.Join(" ", freeSeats));
            }
            else if (touristCount == 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", freeSeats));
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {touristCount} people in a queue!");
                Console.WriteLine(string.Join(" ", freeSeats));
            }
        }
    }
}
