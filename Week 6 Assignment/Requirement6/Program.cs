using System;
using System.Collections.Generic;

namespace Requirement6
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // -------- NUMBER OF VEHICLES --------
                Console.WriteLine("Enter the number of vehicles");
                int n = int.Parse(Console.ReadLine());

                // List to store all vehicle objects
                List<Vehicle> vehicleList = new List<Vehicle>();

                // -------- READ VEHICLE DETAILS --------
                for (int i = 0; i < n; i++)
                {
                    string detail = Console.ReadLine();

                    // Create vehicle using factory method
                    vehicleList.Add(Vehicle.CreateVehicle(detail));
                }

                // -------- TYPE-WISE COUNT --------
                SortedDictionary<string, int> result =
                    Vehicle.TypeWiseCount(vehicleList);

                // -------- DISPLAY RESULT --------
                Console.WriteLine("{0,-15} {1}", "Type", "No. of Vehicles");

                foreach (var item in result)
                {
                    Console.WriteLine("{0,-15} {1}", item.Key, item.Value);
                }
            }
            catch (FormatException)
            {
                // Handles invalid number or date format
                Console.WriteLine("Invalid input format. Please check the input values.");
            }
            catch (Exception ex)
            {
                // Handles unexpected runtime errors
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }
    }
}
