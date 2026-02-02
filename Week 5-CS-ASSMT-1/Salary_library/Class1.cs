namespace Salary_library
{
    public class Salary
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            if (basicSalary <= 0)
                throw new Exception("Invalid Basic Salary");

            double hra = 0.20 * basicSalary;
            double da = 0.10 * basicSalary;
            double pf = 0;

            if (basicSalary >= 15000)
                pf = 0.12 * basicSalary;

            return basicSalary + hra + da - pf;
        }
    }
}
