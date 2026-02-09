using System;
using System.Collections.Generic;

namespace Requirement5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // -------- NUMBER OF VEHICLES --------
                Console.WriteLine("Enter the number of the vehicles:");
                int n = int.Parse(Console.ReadLine());

                // List to store vehicles
                List<Vehicle> list = new List<Vehicle>();

                // -------- READ VEHICLE DETAILS --------
                for (int i = 0; i < n; i++)
                {
                    string detail = Console.ReadLine();

                    // Create and add vehicle using factory method
                    list.Add(Vehicle.CreateVehicle(detail));
                }

                // -------- SORT OPTIONS --------
                Console.WriteLine("Enter a type to sort:");
                Console.WriteLine("1.Sort by weight");
                Console.WriteLine("2.Sort by parked time");

                int choice = int.Parse(Console.ReadLine());

                // Sort by weight (IComparable)
                if (choice == 1)
                {
                    list.Sort();
                }
                // Sort by parked time (IComparer)
                else if (choice == 2)
                {
                    list.Sort(new ParkedTimeComparer());
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

                // -------- DISPLAY SORTED LIST --------
                Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}",
                    "Registration No", "Name", "Type", "Weight", "Ticket No");

                foreach (Vehicle v in list)
                {
                    Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}",
                        v.RegistrationNo,
                        v.Name,
                        v.Type,
                        v.Weight.ToString("0.0"),
                        v.Ticket.TicketNo);
                }
            }
            catch (FormatException)
            {
                // Handles invalid numeric or date inputs
                Console.WriteLine("Invalid input format. Please check your input.");
            }
            catch (Exception ex)
            {
                // Handles unexpected runtime errors
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }
    }
}
