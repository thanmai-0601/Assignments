namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of matches: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int term = i * (i - 1) * (i + 1);
                Console.Write(term + " ");
            }
        }
    }
}
