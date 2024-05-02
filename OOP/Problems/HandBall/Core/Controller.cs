using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Handball.Core
{
    public class Controller : IController
    {
        private TeamRepository teams;
        private PlayerRepository players;

        public Controller()
        {
            teams = new TeamRepository();
            players = new PlayerRepository();
        }
        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }
            ITeam team = new Team(name);
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));
        }
        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = players.GetModel(name);
            if (player != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name
                    , nameof(PlayerRepository), player.GetType().Name);
            }
            if (nameof(Goalkeeper) == typeName)
            {
                player = new Goalkeeper(name);
            }
            else if (nameof(CenterBack) == typeName)
            {
                player = new CenterBack(name);
            }
            else if (nameof(ForwardWing) == typeName)
            {
                player = new ForwardWing(name);
            }
            else
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }
        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);
            if (player == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }
            if (team == null)
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            if (player.Team != string.Empty)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract,playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract,playerName,teamName);
        }
        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeam.Name, secondTeam.Name);
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                firstTeam.Lose();
                secondTeam.Win();
                return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw,firstTeam.Name,secondTeam.Name);
            }
        }
        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            ITeam team = teams.GetModel(teamName);
            sb.AppendLine($"***{teamName}***");
            foreach (var player in team
                .Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p=> p.Name))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");
            foreach (var team in teams
                .Models
                .OrderByDescending(t => t.PointsEarned)
                .OrderByDescending(t => t.OverallRating)
                .ThenBy(t =>t.Name))
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
