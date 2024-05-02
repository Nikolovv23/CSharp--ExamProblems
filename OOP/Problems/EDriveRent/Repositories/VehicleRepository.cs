using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehiclesList;

        public VehicleRepository()
        {
            this.vehiclesList = new List<IVehicle>();
        }

        public void AddModel(IVehicle model)
        {
            vehiclesList.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return vehiclesList.FirstOrDefault(v => v.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return vehiclesList.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            return vehiclesList.Remove(vehiclesList.FirstOrDefault(v => v.LicensePlateNumber == identifier));
        }
    }
}
