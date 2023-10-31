namespace hw_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var console = new ConsoleMenu();

            await console.DisplayMainMenu();
        }
    }
}