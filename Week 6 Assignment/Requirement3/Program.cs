using System.Text.RegularExpressions;

namespace Requirement3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the registration no. to be validated:");
            string regNo = Console.ReadLine();

            if (ValidateRegistrationNo(regNo))
            {
                Console.WriteLine("Registrtion No. is Valid");
            }

            else
            {
                Console.WriteLine("Registration No. is invalid");
            }

        }

        static bool ValidateRegistrationNo(string registrationNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(registrationNo))
                    return false;
                string[] parts = registrationNo.Split(' ');

                if (parts.Length != 3 && parts.Length != 4)
                    return false;

                if (!Regex.IsMatch(parts[0], "^[A-Z]{2}$"))
                    return false;

                if (!Regex.IsMatch(parts[1], "^[0-9]{1,2}$"))
                    return false;

                if (parts.Length == 4)
                {
                    if (!Regex.IsMatch(parts[2], "^[A-Z]{2}$"))
                        return false;
                    if (!Regex.IsMatch(parts[3], "^[0-9]{1,4}$"))
                        return false;
                }
                else
                {
                    if (!Regex.IsMatch(parts[2], "^[0-9]{1,4}$"))
                        return false;
                }
                return true;
            }
            catch { return false; }
        }
    }
}
