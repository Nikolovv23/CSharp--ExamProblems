namespace NauticalCatchChallenge
{
    using NauticalCatchChallenge.Core;
    using NauticalCatchChallenge.Core.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

// In the cozy coastal town of Meridian Bay, the waves carry whispers of the most awaited event of the year – The Nautical Catch Challenge! Eager divers, 
//     both scuba experts and free divers, gear up to plunge into the mysterious depths and shimmering shallow waters. The ocean here is home to various
//     unique fish, each more enticing than the other. Each fish has its value, and the divers aim to fill their bags with the most prized ones. As the
//     sun shines on the glittering sea, the competition heats up. Who will emerge as the champion diver of Meridian Bay? It’s a blend of strategy, skill,
//     and a touch of oceanic luck.
// 
//     You are provided with one interface, which will help you with the correct execution process of your program. The interface is Engine,
//     and the class implementing this interface should read the input, and when the program finishes, this class should print the output.
// Input
// Below, you can see the format in which each command will be given in the input:
// •	DiveIntoCompetition {diverType} { diverName}
// •	SwimIntoCompetition {fishType} { fishName}
// { points}
// •	ChaseFish {diverName} { fishName}
// { isLucky}
// •	HealthRecovery
// •	DiverCatchReport {diverName}
// •	CompetitionStatistics
// •	Exit
// Output
// Print the output from each command when issued. Print the exception message if an exception is thrown during any of the commands' execution.

// Examples in Utilities folder
