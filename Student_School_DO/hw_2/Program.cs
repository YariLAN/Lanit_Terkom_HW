namespace hw_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Clear();

                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Reading");
                Console.WriteLine("2. Record");
                Console.WriteLine("3. Fibonacci number output");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-----------------------------\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        ReadingLine();
                        break;

                    case "2":
                        await RecordFile();
                        break;

                    case "3":
                        ChooseFib();
                        break;

                    case "4":
                        Console.ResetColor();
                        return;

                    default:
                        break;
                }
            }
        }

        public static void ChooseFib()
        {
            while(true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("Input a serial number of Fibonacci: ");

                int.TryParse(Console.ReadLine(), out int n);

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"\nThe answer is {n.Fibonacci()}\n");

                var ans = RestartOrExit();
                switch(ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public static int RestartOrExit()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Restart");
            Console.WriteLine("2. Exit to menu\n");
            Console.WriteLine("-----------------------------\n");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out int ans);

                switch (ans)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    default:
                        IncorrectValue();
                        break;
                }
            }
        }

        public static void IncorrectValue()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Error, repeat!\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void ReadingLine()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Clear();

                Console.Write("Input a fileName: ");
                var fileName = Console.ReadLine();

                Console.Write("Input a count rows of file: ");
                int.TryParse(Console.ReadLine(), out var count);

                Console.Write("Which line to read from: ");
                int.TryParse(Console.ReadLine(), out var startIndex);

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n-----------------------");

                var file = new WorkWithFile(fileName);
                file.ReadingFile(count, startIndex - 1);

                Console.WriteLine("-----------------------\n");

                var ans = RestartOrExit();
                switch(ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }

        public static async Task RecordFile()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Clear();

                Console.Write("Input the URL of site: ");
                var url = Console.ReadLine();

                Console.Write("Input a name of file: ");
                var fileName = Console.ReadLine();

                Console.ResetColor();

                var file = new WorkWithFile(fileName);

                await file.RecordHtmlToFile(url);

                var ans = RestartOrExit();
                switch (ans)
                {
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }
    }
}