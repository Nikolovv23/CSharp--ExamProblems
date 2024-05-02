using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private double overallRating;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;
            players = new List<IPlayer>();
           
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set
            {
                pointsEarned = value;
            }
        }

        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                   return overallRating = 0;
                }
                else
                {
                   return overallRating = Math.Round(this.players.Average(p => p.Rating), 2);
                }
            }
        }

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Draw()
        {
            PointsEarned += 1;
            players.First(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }

        public void Lose() => players.ForEach(p => p.DecreaseRating());

        public void SignContract(IPlayer player) => players.Add(player);

        public void Win()
        {
            PointsEarned += 3;
            foreach (IPlayer player in players)
            {
                player.IncreaseRating();
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            if (players.Count == 0)
            {
                sb.AppendLine("--Players: none");
            }
            else
            {
                var names = new List<string>();
                foreach (var player in players)
                {
                    names.Add(player.Name);
                }
                sb.AppendLine($"--Players: {string.Join(", ", names)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
