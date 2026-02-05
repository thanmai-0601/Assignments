using InsuranceLibrary.Models;
using InsuranceLibrary.Services;

namespace InsuranceConsoleApp
{
    public class Program
    {
        static PolicyService service = new PolicyService();
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Search Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1: AddPolicy(); break;
                    case 2: ViewPolicies(); break;
                    case 3: SearchPolicy(); break;
                    case 4: UpdatePolicy(); break;
                    case 5: DeletePolicy(); break;
                }
            } while (choice != 0);
        }
        static void AddPolicy()
        {
            Console.WriteLine("Enter the details to add");
            Console.Write("Id: ");
            int id=int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Type: ");
            string type = Console.ReadLine();

            Console.Write("Premium: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Console.Write("Term: ");
            int term = int.Parse(Console.ReadLine());

            service.AddPolicy(new InsurancePolicy(id, name, type, premium, term));
            Console.WriteLine("Policy Added");

        }
        static void ViewPolicies()
        {
            Console.WriteLine("Available Insurance Policies");
            foreach (var p in service.GetAllPolicies())
            {
                Console.Write(p);
                
            }
        }

        static void SearchPolicy()
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            var p = service.GetPolicyById(id);
            Console.WriteLine(p != null ? p.ToString() : "Not Found");
        }
        static void UpdatePolicy()
        {
            Console.Write("Id: ");
            int id =int.Parse(Console.ReadLine());

            Console.Write("New Premium: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Console.Write("New Term: ");
            int term = int.Parse(Console.ReadLine());

            Console.WriteLine(service.UpdatePolicy(id, premium, term)
                ? "Updated" : "Not Found");

        }
        static void DeletePolicy()
        {
            Console.WriteLine("Id: ");
            int id  = int.Parse(Console.ReadLine());

            Console.WriteLine(service.DeletePolicy(id)
                ? "Deleted" : "Not Found");
        }


    }
}
