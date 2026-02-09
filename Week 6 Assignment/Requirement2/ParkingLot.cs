using System;
using System.Collections.Generic;

namespace Requirement2
{
    // Represents a parking lot
    public class ParkingLot
    {
        // Parking lot name
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // List of vehicles in the parking lot
        private List<Vehicle> _vehicleList;
        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }

        // Default constructor
        public ParkingLot()
        {
            VehicleList = new List<Vehicle>();
        }

        // Parameterized constructor
        public ParkingLot(string name)
        {
            Name = name;
            VehicleList = new List<Vehicle>();
        }

        // Adds a vehicle to the parking lot
        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            VehicleList.Add(vehicle);
        }

        // Removes a vehicle using registration number
        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            foreach (Vehicle v in VehicleList)
            {
                if (v.RegistrationNo == registrationNo)
                {
                    VehicleList.Remove(v);
                    return true;
                }
            }
            return false;
        }

        // Displays all vehicles in the parking lot
        public void DisplayVehicles()
        {
            if (VehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
                return;
            }

            Console.WriteLine($"Vehicles in {Name}");
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}", "Registration No", "Name", "Type", "Weight", "Ticket No");

            foreach (Vehicle v in VehicleList)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                    v.RegistrationNo, v.Name, v.Type,
                    v.Weight.ToString("0.0"), v.Ticket.TicketNo);
            }
        }
    }
}
