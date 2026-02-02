using System.Text;

namespace Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Previous Reading: ");
            int prev = int.Parse(Console.ReadLine());

            Console.Write("Current Reading: ");
            int curr = int.Parse(Console.ReadLine());

            Console.Write("Connection Type: ");
            string type = Console.ReadLine();

            int units = curr - prev;
            double bill = 0;

            if (units <= 100)
                bill = units * 1.5;
            else if (units <= 250)
                bill = 100 * 1.5 + (units - 100) * 2.5;
            else if (units <= 550)
                bill = 100 * 1.5 + 150 * 2.5 + (units - 250) * 4.5;
            else
                bill = 100 * 1.5 + 150 * 2.5 + 300 * 4.5 + (units - 550) * 7.5;

            int meterRent = 0;

            if (type == "Industrial")
                meterRent = 2500;
            else if (type == "Business")
                meterRent = 1500;
            else if (type == "Domestic")
                meterRent = 1000;
            else if (type == "Agricultural")
                meterRent = 0;

            Console.WriteLine("Units Consumed: " + units);
            Console.WriteLine("Total Bill Amount: ₹" + (bill + meterRent));
        }
    }
}
