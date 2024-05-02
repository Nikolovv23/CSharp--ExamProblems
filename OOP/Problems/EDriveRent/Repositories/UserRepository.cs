using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> usersList;
        public UserRepository() 
        {
            usersList = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            usersList.Add(model);
        }

        public IUser FindById(string identifier)
        {
            return usersList.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return usersList.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            return usersList.Remove(usersList.FirstOrDefault(u => u.DrivingLicenseNumber == identifier));
        }
    }
}
