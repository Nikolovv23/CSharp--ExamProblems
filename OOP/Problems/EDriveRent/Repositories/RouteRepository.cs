using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List <IRoute> routesList;
        public RouteRepository()
        {
            routesList = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routesList.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            return routesList.FirstOrDefault(r => r.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return routesList.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            return routesList.Remove(routesList.FirstOrDefault(r => r.RouteId == int.Parse(identifier)));
        }
    }
}
