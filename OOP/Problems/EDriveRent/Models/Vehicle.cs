using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage
        {
            get => maxMileage;
            private set
            {
                maxMileage = value;
            }
        }

        public string LicensePlateNumber
        {
            get => licensePlateNumber; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get => batteryLevel;
            private set
            {
                batteryLevel = value;
            }
        }

        public bool IsDamaged
        {
            get => isDamaged;
            private set 
            {
                isDamaged = value;
            }
        }

        public void ChangeStatus()
        {
            IsDamaged = !this.IsDamaged;
        }

        public void Drive(double mileage)
        {
            double reduceBattery = Math.Round(100 / (MaxMileage / mileage));
            if (this.GetType().Name == nameof(CargoVan))
            {
                reduceBattery += 5;
            }

            BatteryLevel -= (int)reduceBattery;
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }
        public override string ToString()
        {
            if (this.isDamaged == false)
            {
                return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: OK";
            }
            else
            {
                return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: damaged";
            }
        }
    }
}
