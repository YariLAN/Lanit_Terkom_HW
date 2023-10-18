namespace hw_2
{
    public static class IntExtensions
    {
        public static int Fibonacci(this int th)
        {
            if (th <= 2)
                return 1;

            return (th - 1).Fibonacci() + (th - 2).Fibonacci();
        }
    }
}
