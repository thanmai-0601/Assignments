namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Emp emp = new Emp();
            
            emp.EmpName = (Console.ReadLine());
            Console.WriteLine($"enter id: {emp.EmpName}");
            //Console.WriteLine($"Employee Id:{emp.EmpId}");
            //Console.WriteLine($"Employee Name:{emp.EmpName}");
            //Console.WriteLine($"Employee Salary:{ emp.EmpSalary}");
            emp.Bal = 10000;
            Console.WriteLine(emp.Bal);
            Console.WriteLine(emp);
        }
    }
}
