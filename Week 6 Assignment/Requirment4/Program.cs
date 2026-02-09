using Requirment4;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Requirement4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // -------- NUMBER OF VEHICLES --------
                Console.WriteLine("Enter the number of vehicles:");
                int n = int.Parse(Console.ReadLine());

                // List to store vehicle objects
                List<Vehicle> vehicles = new List<Vehicle>();

                // -------- READ VEHICLE DETAILS --------
                for (int i = 0; i < n; i++)
                {
                    // Each input line contains complete vehicle details
                    string detail = Console.ReadLine();

                    // Create Vehicle object using factory method
                    vehicles.Add(Vehicle.CreateVehicle(detail));
                }

                // Business Object for searching vehicles
                VehicleBO bo = new VehicleBO();

                // -------- SEARCH OPTIONS --------
                Console.WriteLine("Enter a search type:");
                Console.WriteLine("1.By type");
                Console.WriteLine("2.By parked time");

                int choice = int.Parse(Console.ReadLine());
                List<Vehicle> result = null;

                // Search by vehicle type
                if (choice == 1)
                {
                    Console.WriteLine("Enter the vehicle type:");
                    string type = Console.ReadLine();
                    result = bo.FindVehicle(vehicles, type);
                }
                // Search by parked time
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the parked time:");
                    DateTime time = DateTime.ParseExact(
                        Console.ReadLine(),
                        "dd-MM-yyyy HH:mm:ss",
                        CultureInfo.InvariantCulture
                    );
                    result = bo.FindVehicle(vehicles, time);
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

                // -------- RESULT CHECK --------
                if (result.Count == 0)
                {
                    Console.WriteLine("No such vehicle is present");
                    return;
                }

                // -------- DISPLAY RESULT --------
                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                    "Registration No", "Name", "Type", "Weight", "Ticket No");

                foreach (Vehicle vehicle in result)
                {
                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                        vehicle.RegistrationNo,
                        vehicle.Name,
                        vehicle.Type,
                        vehicle.Weight.ToString("0.0"),
                        vehicle.Ticket.TicketNo);
                }
            }
            catch (FormatException)
            {
                // Handles wrong number/date formats
                Console.WriteLine("Invalid input format. Please check the values entered.");
            }
            catch (Exception ex)
            {
                // Handles unexpected runtime errors
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }
    }
}
