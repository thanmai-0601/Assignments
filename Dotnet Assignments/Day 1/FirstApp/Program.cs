namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int res = p.sum(5, 1);
            Console.WriteLine("Sum is "+res);
            p.swapping(4, 8);
            p.table(5);
            p.pattern(4, 3);
            p.convert("Thanmai");
          


        }
        int sum(int x, int y)
        {
            return x + y;
        }
        void swapping(int a, int b)
        {
            Console.WriteLine("Swapping");
            Console.WriteLine("Before Swap " + a + "and" + b);
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After Swap " + a + "and" + b);
        }
        void table(int num)
        {
            Console.WriteLine("Multiplication Table");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
            }
        }
        void pattern(int x, int y)
        {
            Console.WriteLine("Pattern");
            int rows = x;
            int cols = y;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (i == 1 || i == rows || j == 1 || j == cols)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        void convert(string str)
        {
            int l = (str.Length);
            Console.WriteLine("First 4 Chars Lowercase, Rest Uppercase");
            if (l < 4)
                Console.WriteLine(str.ToUpper());
            else

                Console.WriteLine(str.Substring(0, 4).ToLower() + str.Substring(4, l - 4).ToUpper());

        }

    }
}