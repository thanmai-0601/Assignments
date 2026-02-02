using Salary_library;

namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Basic Salary: ");
                double basic = double.Parse(Console.ReadLine());

                double netSalary = Salary.CalculateNetSalary(basic);
                Console.WriteLine("Net Salary: " + netSalary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
