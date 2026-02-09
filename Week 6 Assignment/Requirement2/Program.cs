using Requirement2;
using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Read parking lot name
            Console.WriteLine("Enter the name of the Parking Lot:");
            string name = Console.ReadLine();

            // Create ParkingLot object
            ParkingLot parkingLot = new ParkingLot(name);

            // Menu-driven program
            while (true)
            {
                Console.WriteLine("1.Add Vehicle");
                Console.WriteLine("2.Delete Vehicle");
                Console.WriteLine("3.Display Vehicles");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice:");

                // Read user choice
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add Vehicle
                        string details = Console.ReadLine();

                        // Create Vehicle object using factory method
                        Vehicle vehicle = Vehicle.CreateVehicle(details);

                        // Add vehicle to parking lot
                        parkingLot.AddVehicleToParkingLot(vehicle);

                        Console.WriteLine("Vehicle successfully added");
                        break;

                    case 2:
                        // Delete Vehicle
                        Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                        string regNo = Console.ReadLine();

                        bool removed = parkingLot.RemoveVehicleFromParkingLot(regNo);

                        if (removed)
                            Console.WriteLine("Vehicle successfully deleted");
                        else
                            Console.WriteLine("Vehicle not found in parkinglot");
                        break;

                    case 3:
                        // Display all vehicles
                        parkingLot.DisplayVehicles();
                        break;

                    case 4:
                        // Exit the program
                        return;

                    default:
                        // Invalid menu choice
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        catch (FormatException)
        {
            // Handles invalid number input (choice, parsing errors)
            Console.WriteLine("Invalid input format. Please enter correct values.");
        }
        catch (Exception ex)
        {
            // Handles any unexpected runtime errors
            Console.WriteLine(ex.Message);
        }
    }
}
