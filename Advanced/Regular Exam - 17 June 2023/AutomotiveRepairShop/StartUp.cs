// Your task is to create a repository that stores vehicles by creating the classes described below.
// Vehicle
// You are given a class Vehicle with the following properties:
// •	VIN – string
// •	Mileage - int
// •	Damage - string
// The class constructor should receive vin, mileage and damage. 
// Override the ToString() method in the following format:
// "Damage: {damage}, Vehicle: {vin} ({mileage} km)"
// RepairShop
// Next, you are given a class RepairShop that has Vehicles (a List that stores Vehicles). All entities inside the repository have the same properties.
// The RepairShop class should have the following properties:
// •	Capacity – int
// •	Vehicles – List<Vehicle>
// The class constructor should receive capacity, also it should initialize the Vehicles with a new instance of the collection. Implement the following features:
// •	Method AddVehicle(Vehicle vehicle) – adds an entity to the collection of Vehicles, if the Capacity allows it.
// •	Method RemoveVehicle(string vin) – removes a vehicle by given vin, if such exists, and returns boolean (true if it is removed, otherwise – false)
// •	Method GetCount() – returns the number of vehicles, registered in the RepairShop
// •	Method GetLowestMileage() – returns the Vehicle with the lowest value of Mileage property.
// •	Method Report() – returns a string in the following format:
// o   "Vehicles in the preparatory:
// {Vehicle1}
// { Vehicle2}
// (…)"
// Constraints
// •	The VIN of the vehicles will be always unique.
// •	You will always have vehicles added before receiving methods manipulating the vehicles in the RepairShop.

namespace AutomotiveRepairShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize the repository (RepairShop)
            RepairShop repairShop = new RepairShop(5);

            //Initialize entity (Vehicle)
            Vehicle vehicle1 = new Vehicle("1HGCM82633A123456", 50000, "Oil leakage");

            //Print Vehicle
            Console.WriteLine(vehicle1); // Damage: Oil leakage, Vehicle: 1HGCM82633A123456 (50000 km)

            //Add Vehicle
            repairShop.AddVehicle(vehicle1);

            //Remove Vehicle
            Console.WriteLine(repairShop.RemoveVehicle("1HGCM82633A123459")); //False
            Console.WriteLine(repairShop.RemoveVehicle("1HGCM82633A123456")); //True

            Vehicle vehicle2 = new Vehicle("5YJSA1CN7DFP12345", 80000, "Overheating issue");
            Vehicle vehicle3 = new Vehicle("JM1GJ1W56F1234567", 120000, "Coolant leakage");
            Vehicle vehicle4 = new Vehicle("2C3CDXAT4CH123456", 95000, "Timing belt failure");
            Vehicle vehicle5 = new Vehicle("WAUZZZ8K9FA123456", 66000, "Cylinder misfire");
            Vehicle vehicle6 = new Vehicle("1G1BL52P3RR123456", 150000, "Transmission failure");
            Vehicle vehicle7 = new Vehicle("JTDKB20U993123456", 65000, "Piston damage");


            //Add More Vehicles
            repairShop.AddVehicle(vehicle2);
            repairShop.AddVehicle(vehicle3);
            repairShop.AddVehicle(vehicle4);
            repairShop.AddVehicle(vehicle5);

            //Get Count
            Console.WriteLine(repairShop.GetCount()); //4

            repairShop.AddVehicle(vehicle6);
            repairShop.AddVehicle(vehicle7);

            //Get Count
            Console.WriteLine(repairShop.GetCount()); //5


            //Get LowestMileage
            Console.WriteLine(repairShop.GetLowestMileage()); //Damage: Cylinder misfire, Vehicle: WAUZZZ8K9FA123456 (66000 km)

            //Report
            Console.WriteLine(repairShop.Report());
            //Vehicles in the preparatory:
            //Damage: Overheating issue, Vehicle: 5YJSA1CN7DFP12345 (80000 km)
            //Damage: Coolant leakage, Vehicle: JM1GJ1W56F1234567 (120000 km)
            //Damage: Timing belt failure, Vehicle: 2C3CDXAT4CH123456 (95000 km)
            //Damage: Cylinder misfire, Vehicle: WAUZZZ8K9FA123456 (66000 km)
            //Damage: Transmission failure, Vehicle: 1G1BL52P3RR123456 (150000 km)

        }
    }
}