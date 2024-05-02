using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
     public class FishRepository : IRepository<IFish>
     {
        private List<IFish> models;
        public FishRepository() 
        {
           models = new List<IFish>();
        }
        public IReadOnlyCollection<IFish> Models => models.AsReadOnly();

        public void AddModel(IFish model) => models.Add(model);

        public IFish GetModel(string name) => Models.FirstOrDefault(f => f.Name == name);
    }
}
