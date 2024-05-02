namespace EDriveRent
{
    using EDriveRent.Core;
    using EDriveRent.Core.Contracts;
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

// You are chosen to take part in a Start-up company, which is developing an electric vehicles rent-a-car application. 
// Your task is to create the classes needed for the application and implement the logic, standing behind some 
// important buttons. The application must have support for User, Vehicle and Route. The project will consist of 
// model classes and a controller class, which manages the interaction between the users, vehicles and routes. 

//     You are provided with one interface, which will help with the correct execution process of your program. The interface
// is Engine and the class implementing this interface should read the input and when the program finishes, this class
// should print the output. 

// Input 
// Below, you can see the format in which each command will be given in the input: 
// RegisterUser {firstName} {lastName} {drivingLicenseNumber} 
// UploadVehicle {vehicleType} { brand} { model} { licensePlateNumber} 
// AllowRoute {startPoint} { endPoint} { length} 
// MakeTrip
// {drivingLicenseNumber} { licensePlateNumber} { routeId} { isAccidentHappened} 
// RepairVehicles {count} 
// UsersReport
// End

// Output 
// Print the output from each command when issued. If an exception is thrown during any of the commands' 
// execution, print the exception message. 

// Examples 
//           Input:
// RegisterUser Tisha Reenie 7246506 
// RegisterUser Bernard Remy CDYHVSR68661 
// RegisterUser Mack Cindi 7246506 
// UploadVehicle PassengerCar Chevrolet Volt CWP8032 
// UploadVehicle PassengerCar Volkswagen e-Up! COUN199728 
// UploadVehicle PassengerCar Mercedes-Benz EQS 5UNM315 
// UploadVehicle CargoVan Ford e-Transit 726QOA 
// UploadVehicle CargoVan BrightDrop Zevo400 SC39690 
// UploadVehicle EcoTruck Mercedes-Benz eActros SC39690 
// UploadVehicle PassengerCar Tesla CyberTruck 726QOA 
// AllowRoute SOF PLD 144 
// AllowRoute BUR VAR 87 
// AllowRoute BUR VAR 87 
// AllowRoute SOF PLD 184 
// AllowRoute BUR VAR 86.999 
// MakeTrip CDYHVSR68661 5UNM315 3 false 
// MakeTrip 7246506 CWP8032 1 true 
// MakeTrip 7246506 COUN199728 1 false 
// MakeTrip CDYHVSR68661 CWP8032 3 false 
// MakeTrip CDYHVSR68661 5UNM315 2 false 
// RepairVehicles 2 
// UsersReport
// 
//          Output:
// Tisha Reenie is registered successfully with DLN-7246506 
// Bernard Remy is registered successfully with DLN-CDYHVSR68661 
// 7246506 is already registered in our platform. 
// Chevrolet Volt is uploaded successfully with LPN-CWP8032 
// Volkswagen e-Up! is uploaded successfully with LPN-COUN199728 
// Mercedes-Benz EQS is uploaded successfully with LPN-5UNM315 
// Ford e-Transit is uploaded successfully with LPN-726QOA 
// BrightDrop Zevo400 is uploaded successfully with LPN-SC39690 
// EcoTruck is not accessible in our platform. 
// 726QOA belongs to another vehicle. 
// SOF/PLD - 144 km is unlocked in our platform. 
// BUR/VAR - 87 km is unlocked in our platform. 
// BUR/VAR - 87 km is already added in our platform. 
// SOF/PLD shorter route is already added in our platform. 
// BUR/VAR - 86.999 km is unlocked in our platform. 
// Mercedes-Benz EQS License plate: 5UNM315 Battery: 81 % Status: OK
// Chevrolet Volt License plate: CWP8032 Battery: 68 % Status: damaged
// User 7246506 is blocked in the platform! Trip is not allowed. 
// Vehicle CWP8032 is damaged! Trip is not allowed. 
// Route 2 is locked! Trip is not allowed. 
// 1 vehicles are successfully repaired! 
// *** E-Drive-Rent *** 
// Bernard Remy Driving license: CDYHVSR68661 Rating: 0.5
// Tisha Reenie Driving license: 7246506 Rating: 0

