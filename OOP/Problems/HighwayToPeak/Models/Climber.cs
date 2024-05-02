using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string _name;
        private int _stamina;
        private List<string> _conqueredPeaks;

        public Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            _conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get { return _name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public int Stamina
        {
            get => _stamina;
            protected set
            {
                if (value > 10)
                {
                    value = 10;
                }
                if (value < 0)
                {
                    value = 0;
                }
                _stamina = value;
            }
        }
        public IReadOnlyCollection<string> ConqueredPeaks => _conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (!ConqueredPeaks.Contains(peak.Name))
            {
               _conqueredPeaks.Add(peak.Name);
            }
            switch (peak.DifficultyLevel)
            {
                case "Extreme": Stamina -= 6; break;
                case "Hard": Stamina -= 4; break;
                case "Moderate": Stamina -= 2; break;
            }
        }
        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            if (ConqueredPeaks.Count == 0)
            {
                sb.AppendLine($"Peaks conquered: no peaks conquered");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: {ConqueredPeaks.Count}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
