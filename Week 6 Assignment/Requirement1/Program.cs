using System;
using System.Globalization;

namespace Requirement1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // -------- VEHICLE 1 INPUT --------
                Console.WriteLine("Enter Vehicle 1 details:");
                // Expected format:
                // regNo,name,type,weight,ticketNo,entryDateTime,amount
                string[] v1 = Console.ReadLine().Split(',');

                // Create Ticket object for Vehicle 1
                Ticket t1 = new Ticket(
                    v1[4], // Ticket number
                    DateTime.ParseExact(
                        v1[5],                     // Entry date & time
                        "dd-MM-yyyy HH:mm:ss",     // Expected format
                        CultureInfo.InvariantCulture),
                    double.Parse(v1[6])          // Parking amount
                );

                // Create Vehicle object for Vehicle 1
                Vehicle vehicle1 = new Vehicle(
                    v1[0],                       // Registration number
                    v1[1],                       // Vehicle name
                    v1[2],                       // Vehicle type
                    double.Parse(v1[3]),         // Vehicle weight
                    t1                            // Ticket object
                );

                // -------- VEHICLE 2 INPUT --------
                Console.WriteLine("Enter Vehicle 2 details:");
                string[] v2 = Console.ReadLine().Split(',');

                // Create Ticket object for Vehicle 2
                Ticket t2 = new Ticket(
                    v2[4], // Ticket number
                    DateTime.ParseExact(
                        v2[5],                     // ✅ FIXED (was v1[5])
                        "dd-MM-yyyy HH:mm:ss",
                        CultureInfo.InvariantCulture),
                    double.Parse(v2[6])
                );

                // Create Vehicle object for Vehicle 2
                Vehicle vehicle2 = new Vehicle(
                    v2[0],
                    v2[1],
                    v2[2],
                    double.Parse(v2[3]),
                    t2
                );

                // -------- DISPLAY VEHICLE DETAILS --------
                Console.WriteLine("\nVehicle 1");
                Console.WriteLine(vehicle1); // Calls overridden ToString()

                Console.WriteLine("\nVehicle 2");
                Console.WriteLine(vehicle2);

                // -------- COMPARISON --------
                if (vehicle1.Equals(vehicle2))
                    Console.WriteLine("\nVehicle 1 is same as Vehicle 2");
                else
                    Console.WriteLine("\nVehicle 1 and Vehicle 2 are different");
            }
            catch (FormatException)
            {
                // Handles invalid number or date formats
                Console.WriteLine("Input format is incorrect. Please check numbers and date format.");
            }
            catch (IndexOutOfRangeException)
            {
                // Handles missing input values
                Console.WriteLine("Insufficient input values provided.");
            }
            catch (Exception ex)
            {
                // Handles any other unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
