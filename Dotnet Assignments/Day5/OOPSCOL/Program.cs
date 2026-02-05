using System.Collections;

namespace OOPSCOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            myList.Add(1);
            myList.Add("Hello");
            myList.Add(35);
            myList.Add(true);
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Using Generics");
            List<int> numbers=new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
