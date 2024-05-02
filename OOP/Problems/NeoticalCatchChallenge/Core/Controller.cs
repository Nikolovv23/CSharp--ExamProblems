using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private FishRepository fishes;
        private DiverRepository divers;

        public Controller()
        {
            fishes = new FishRepository();  
            divers = new DiverRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            if (diver != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
            }
            if (nameof(ScubaDiver) == diverType)
            {
                diver = new ScubaDiver(diverName);
            }
            else if (nameof(FreeDiver) == diverType)
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            divers.AddModel(diver);
            return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }
        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish fish = fishes.GetModel(fishName);
            if (fish != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }
            if (nameof(PredatoryFish) == fishType)
            {
                fish = new PredatoryFish(fishName, points);
            }
            else if (nameof(DeepSeaFish) == fishType)
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if (nameof(ReefFish) == fishType)
            {
                fish = new ReefFish(fishName, points);  
            }
            else
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }
            fishes.AddModel(fish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }
        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IFish fish = fishes.GetModel(fishName);
            IDiver diver = divers.GetModel(diverName);
            if ( diver == null)
            {
                return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }
            if (fish == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }
            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }
            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            diver.Hit(fish);
            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
        }
        public string HealthRecovery()
        {
            int counter = 0;
            foreach (var diver in divers.Models.Where(d => d.HasHealthIssues))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                counter++;
            }
            return string.Format(OutputMessages.DiversRecovered, counter);
        }
        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");
            foreach (var fishName in diver.Catch)
            {
                IFish fish = fishes.GetModel(fishName);
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (var diver in divers.Models
                .OrderByDescending(d => d.CompetitionPoints)
                .OrderByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .Where(d => !d.HasHealthIssues))
            {
                sb.AppendLine(diver.ToString());
            }
            return sb.ToString().TrimEnd();
        }  
    }
}
