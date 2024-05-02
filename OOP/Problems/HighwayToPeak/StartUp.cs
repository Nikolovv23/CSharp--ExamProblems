using HighwayToPeak.Core;

namespace HighwayToPeak
{
    using HighwayToPeak.Core;
    using HighwayToPeak.Core.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

// Welcome to Gorakshep, a village town in the Himalayas. Every year, climbers come here for the Himalayan Heights Challenge. 
//     They aim to climb famous mountains like Mount Everest and K2.
//     These mountains are very high and hard to climb. Climbers need to pick their gear carefully and plan well.
//     Everyone is excited as climbers get ready for their big climbs. 
// 
// 
//     You are provided with one interface, which will help you with the correct execution process of your program. The interface is Engine, and the class implementing this interface should read the input, and when the program finishes, this class should print the output.
// Input
// Below, you can see the format in which each command will be given in the input:
// •	AddPeak {name} { elevation}
// { difficultyLevel}
// •	NewClimberAtCamp {name} { isOxygenUsed}
// •	AttackPeak {climberName} { peakName}
// •	CampRecovery {climberName} { daysToRecover}
// •	BaseCampReport
// •	OverallStatistics
// •	Exit
// Output
// Print the output from each command when issued. Print the exception message if an exception is thrown during any of the commands' execution.

// Examples in Utilities folder

