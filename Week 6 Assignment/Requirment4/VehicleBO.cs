using System;
using System.Collections.Generic;

namespace Requirment4
{
    // Business logic class for Vehicle operations
    public class VehicleBO
    {
        // Find vehicles based on type
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle v in vehicleList)
            {
                if (v.Type == type)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        // Find vehicles based on parked time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle v in vehicleList)
            {
                if (v.Ticket.ParkedTime == parkedTime)
                {
                    result.Add(v);
                }
            }
            return result;
        }
    }
}
