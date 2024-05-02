using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }
        public bool RemoveVehicle(string vin) => Vehicles.Remove(Vehicles.FirstOrDefault(v => v.VIN == vin));
        public int GetCount() => Vehicles.Count; 
        public Vehicle GetLowestMileage() => Vehicles.OrderBy( v => v.Mileage).FirstOrDefault();
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (Vehicle vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
