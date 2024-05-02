using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private double rating;
        private string drivingLicenseNumber;
        private bool isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Rating = 0;
            DrivingLicenseNumber = drivingLicenseNumber;
            IsBlocked = false;
        }

        public string FirstName
        {
            get { return firstName; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                lastName = value;
            }
        }

        public double Rating
        {
            get { return rating; }
            private set
            {
                if (value >= 10)
                {
                    value = 10;
                }
                if (value < 0)
                {
                    value = 0;
                    IsBlocked = true;
                }
                rating = value;
            }
        }

        public string DrivingLicenseNumber
        {
            get { return drivingLicenseNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked
        {
            get { return isBlocked; }
            private set
            {
                isBlocked = value;
            }
        }

        public void DecreaseRating()
        {
            Rating -= 0.2;
        }

        public void IncreaseRating()
        {
            Rating += 0.5;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
