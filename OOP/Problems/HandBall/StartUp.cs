using Handball.Core;
using Handball.Core.Contracts;

namespace Handball
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

// In the world of Handball, a thrilling team sport played by two teams of seven players, strategic gameplay and skilled athletes take center stage.
//     This exam focuses on the exciting realm of Handball, where teams compete to score goals while defending their own nets. Through a series of
//     tasks, you will dive into the realm of object-oriented programming in C#. From creating player and team structures to implementing game logic
//     and player management, this exam provides an opportunity to showcase your understanding of OOP principles and apply them to the dynamic world
//     of Handball. Get ready to unleash your coding skills and take on the challenge of building a robust Handball application.

// You are provided with one interface, which will help you with the correct execution process of your program. The interface is Engine,
//  and the class implementing this interface should read the input, and when the program finishes, this class should print the output.

// Input
// Below, you can see the format in which each command will be given in the input:
// •	NewTeam {name}
// •	NewPlayer {typeName} { name}
// •	NewContract {playerName} { teamName}
// •	NewGame {firstTeamName} { secondTeamName}
// •	PlayerStatistics {teamName}
// •	LeagueStandings
// •	Exit

// Output
// Print the output from each command when issued. Print the exception message if an exception is thrown during any of the commands' execution.

// Examples
//      Input:
// NewTeam FireBall
// NewTeam DribbleDown
// NewTeam NetNavigators
// NewTeam InGoodHands
// NewTeam InGoodHands
// NewPlayer Goalkeeper John Smith
// NewPlayer CenterBack Al Johnson
// NewPlayer CenterBack Bob Thompson
// NewPlayer ForwardWing Charlie Davis
// NewPlayer ForwardWing David Wilson
// NewPlayer Goalkeeper Emil Brown
// NewPlayer CenterBack Fred Clark
// NewPlayer CenterBack Rodrigo Grade
// NewPlayer ForwardWing Henry Lee
// NewPlayer ForwardWing Isaac Mitchell
// NewPlayer Goalkeeper Jack Davis
// NewPlayer CenterBack Kyle Anderson
// NewPlayer CenterBack Liam Taylor
// NewPlayer ForwardWing Matthew Reed
// NewPlayer ForwardWing Nathan Cooper
// NewPlayer Midfielder Oliver Johnson
// NewPlayer CenterBack John Smith
// NewPlayer Goalkeeper Samuel Thompson
// NewContract John Smith FireBall
// NewContract Al Johnson FireBall
// NewContract Bob Thompson FireBall
// NewContract Charlie Davis FireBall
// NewContract David Wilson FireBall
// NewContract Emil Brown DribbleDown
// NewContract Fred Clark DribbleDown
// NewContract Rodrigo Grade DribbleDown
// NewContract Henry Lee DribbleDown
// NewContract Isaac Mitchell DribbleDown
// NewContract Jack Davis NetNavigators
// NewContract Kyle Anderson NetNavigators
// NewContract Liam Taylor NetNavigators
// NewContract Matthew Reed NetNavigators
// NewContract Nathan Cooper NetNavigators
// NewContract Dilan Zee InGoodHands
// NewContract Samuel Thopmson PassFast
// NewContract Matthew Reed NetNavigators
// NewContract Matthew Reed DribbleDown
// NewGame FireBall DribbleDown
// NewGame FireBall NetNavigators
// NewGame NetNavigators DribbleDown
// PlayerStatistics FireBall
// LeagueStandings
// Exit

//      Output:
// FireBall is successfully added to the TeamRepository.
// DribbleDown is successfully added to the TeamRepository.
// NetNavigators is successfully added to the TeamRepository.
// InGoodHands is successfully added to the TeamRepository.
// InGoodHands is already added to the TeamRepository.
// John Smith is filed for the handball league.
// Al Johnson is filed for the handball league.
// Bob Thompson is filed for the handball league.
// Charlie Davis is filed for the handball league.
// David Wilson is filed for the handball league.
// Emil Brown is filed for the handball league.
// Fred Clark is filed for the handball league.
// Rodrigo Grade is filed for the handball league.
// Henry Lee is filed for the handball league.
// Isaac Mitchell is filed for the handball league.
// Jack Davis is filed for the handball league.
// Kyle Anderson is filed for the handball league.
// Liam Taylor is filed for the handball league.
// Matthew Reed is filed for the handball league.
// Nathan Cooper is filed for the handball league.
// Midfielder is invalid position for the application.
// John Smith is already added to the PlayerRepository as Goalkeeper.
// Samuel Thompson is filed for the handball league.
// Player John Smith signed a contract with FireBall.
// Player Al Johnson signed a contract with FireBall.
// Player Bob Thompson signed a contract with FireBall.
// Player Charlie Davis signed a contract with FireBall.
// Player David Wilson signed a contract with FireBall.
// Player Emil Brown signed a contract with DribbleDown.
// Player Fred Clark signed a contract with DribbleDown.
// Player Rodrigo Grade signed a contract with DribbleDown.
// Player Henry Lee signed a contract with DribbleDown.
// Player Isaac Mitchell signed a contract with DribbleDown.
// Player Jack Davis signed a contract with NetNavigators.
// Player Kyle Anderson signed a contract with NetNavigators.
// Player Liam Taylor signed a contract with NetNavigators.
// Player Matthew Reed signed a contract with NetNavigators.
// Player Nathan Cooper signed a contract with NetNavigators.
// Player with the name Dilan Zee does not exist in the PlayerRepository.
// Player with the name Samuel Thopmson does not exist in the PlayerRepository.
// Player Matthew Reed has already signed with NetNavigators.
// Player Matthew Reed has already signed with NetNavigators.
// The game between FireBall and DribbleDown ends in a draw!
// Team FireBall wins the game over NetNavigators!
// Team DribbleDown wins the game over NetNavigators!
// ***FireBall***
// ForwardWing: Charlie Davis
// --Rating: 6.75
// ForwardWing: David Wilson
// --Rating: 6.75
// CenterBack: Al Johnson
// --Rating: 5
// CenterBack: Bob Thompson
// --Rating: 5
// Goalkeeper: John Smith
// --Rating: 4
// * **League Standings***
// Team: DribbleDown Points: 4
// --Overall rating: 5.5
// --Players: Emil Brown, Fred Clark, Rodrigo Grade, Henry Lee, Isaac Mitchell
// Team: FireBall Points: 4
// --Overall rating: 5.5
// --Players: John Smith, Al Johnson, Bob Thompson, Charlie Davis, David Wilson
// Team: NetNavigators Points: 0
// --Overall rating: 2.6
// --Players: Jack Davis, Kyle Anderson, Liam Taylor, Matthew Reed, Nathan Cooper
// Team: InGoodHands Points: 0
// --Overall rating: 0
// --Players: none
