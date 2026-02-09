using System;

public class Ticket
{
 
    // Properties
    private string _ticketNo;
    public string TicketNo
    {
        get { return _ticketNo; }
        set { _ticketNo = value; }
    }
    private DateTime _parkedTime;
    public DateTime ParkedTime
    {
        get { return _parkedTime; }
        set { _parkedTime = value; }
    }
    private double _cost;
    public double Cost
    {
        get { return _cost; }
        set { _cost = value; }
    }

    // Non-parameterized constructor
    public Ticket()
    {
    }

    // Parameterized constructor
    public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
    {
        TicketNo = _ticketNo;
        ParkedTime = _parkedTime;
        Cost = _cost;
    }

    // ToString()
    public override string ToString()
    {
        return $"Ticket No: {_ticketNo}" +
               $", Parked Time: {_parkedTime}" +
               $", Cost: + {_cost.ToString("0.0")}";
    }
}
