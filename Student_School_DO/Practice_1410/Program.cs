namespace Practice_1410
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FooBar(15));
            Console.WriteLine(FooBar(12));
            Console.WriteLine(FooBar(25));
        }

        public static string FooBar(int num)
        {
            if (num % 5 == 0 && num % 3 == 0)
            {
                return "FooBar";
            }
            else if (num % 5 == 0 && num % 3 != 0)
            {
                return "Foo";
            }
            else if (num % 5 != 0 && num % 3 == 0)
            {
                return "Bar";
            }
            else
                return "";
        }
    }
}