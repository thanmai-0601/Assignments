
using System;

public class Vehicle
{
    // Properties
    private string _registrationNo;
    public string RegistrationNo
    {
        get { return _registrationNo; }
        set { _registrationNo = value; }
    }
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    private string _type;
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }
    private double _weight;
    public double Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }
    private Ticket _ticket;
    public Ticket Ticket
    {
        get { return _ticket; }
        set { _ticket = value; }
    }

    // Non-parameterized constructor
    public Vehicle()
    {
    }

    // Parameterized constructor
    public Vehicle(string _registrationNo, string _name,
                   string _type, double _weight, Ticket _ticket)
    {
        RegistrationNo = _registrationNo;
        Name = _name;
        Type = _type;
        Weight = _weight;
        Ticket = _ticket;
    }

    //Static Method
    public static Vehicle CreateVehicle(string detail)
    {
        string[] v= detail.Split(',');
        Ticket t = new Ticket(v[4], DateTime.ParseExact(v[5], "dd-MM-yyyy HH:mm:ss", null), double.Parse(v[6]));
        return new Vehicle(v[0], v[1], v[2],double.Parse(v[3]),t);

    }

    // ToString()
    public override string ToString()
    {
        return $"Registration No: {_registrationNo}\n" +
               $"Name: {_name}\n" +
               $"Type: {_type}\n" +
               $"Weight: {_weight:0.0}\n" +
               $"Ticket No: {_ticket.TicketNo}";
    }

    // Equals()
    public override bool Equals(object? obj)
    {
        Vehicle v = obj as Vehicle;

        return RegistrationNo.Equals(v.RegistrationNo) && Name.Equals(v.Name);
    }
}
