using System;
using System.Collections.Generic;

namespace Requirement5
{
    // Custom comparer to sort vehicles by parked time
    public class ParkedTimeComparer : IComparer<Vehicle>
    {
        // Compares two vehicles based on parked time
        public int Compare(Vehicle x, Vehicle y)
        {
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
    }
}
