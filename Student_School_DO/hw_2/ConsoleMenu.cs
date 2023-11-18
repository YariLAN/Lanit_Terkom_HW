using System.Xml.Serialization;

namespace hw_2
{
    public class ConsoleMenu
    {
        public static ConsoleColor ForeColorMenu = ConsoleColor.Yellow;
        public static ConsoleColor ForeColorServices = ConsoleColor.Blue;
        public static ConsoleColor ForeColorErrors = ConsoleColor.Red;
        public static ConsoleColor ForeColorDefault = ConsoleColor.White;

        public void Clear()
        {
            Console.Clear();
        }

        public void SetForeground(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void Show(ConsoleColor color, Action action)
        {
            SetForeground(color);
            Console.WriteLine("\n-----------------------------");

            action();

            Console.WriteLine("-----------------------------\n");
            SetForeground(ForeColorDefault);
        }

        public void Message(ConsoleColor color, string text)
        {
            Show(color, () => Console.WriteLine(text));
        }

        public async virtual Task DisplayMainMenu()
        {
            while (true)
            {
                Clear();

                Show(ForeColorMenu, () =>
                {
                    Console.WriteLine("1. Reading");
                    Console.WriteLine("2. Record");
                    Console.WriteLine("3. Fibonacci number output");
                    Console.WriteLine("4. Exit");
                });

                switch (Console.ReadLine())
                {
                    case "1":
                        ReadingLines();
                        break;

                    case "2":
                        await RecordFile();
                        break;

                    case "3":
                        Fib();
                        break;

                    case "4":
                        SetForeground(ForeColorDefault);
                        return;

                    default:
                        break;
                }
            }
        }

        public void ReadingLines()
        {
            while (true)
            {
                Clear();

                SetForeground(ForeColorServices);

                var formAns = InputTextForm(
                    "Input a fileName: ",
                    "Input a count rows of file: ",
                    "Which line to read from: "
                );

                var fileName = formAns[0];

                int.TryParse(formAns[1], out var count);

                int.TryParse(formAns[2], out var startIndex);

                Show(ForeColorDefault, () =>
                {
                    var file = new FileWorker(fileName);
                    try
                    {
                        file.ReadingFile(count, startIndex - 1);
                    }
                    catch (Exception ex)
                    {
                        Message(ForeColorErrors, ex.Message);
                    }
                });

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

        public int RestartOrExit()
        {
            Show(ForeColorMenu, () =>
            {
                Console.WriteLine("1. Restart");
                Console.WriteLine("2. Exit to menu");
            });

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
                        Message(ForeColorErrors, "Error, repeat!");
                        break;
                }
            }
        }

        public List<string?> InputTextForm(params string[] str)
        {
            var listStr = new List<string?>();

            Show(ForeColorServices, () =>
            {
                foreach (var line in str)
                {
                    Console.Write(line);

                    listStr.Add(Console.ReadLine());
                }
            });

            return listStr;
        }

        public async Task RecordFile()
        {
            while (true)
            {
                Clear();

                SetForeground(ForeColorServices);

                var formAns = InputTextForm(
                    "Input a name of file: ",
                    "Input the URL of site: "
                );

                SetForeground(ForeColorDefault);

                var file = new FileWorker(formAns[0]);

                try
                {
                    await file.RecordHtmlToFile(formAns[1]);

                    Message(ForeColorDefault, "Data is loaded!");
                }
                catch (Exception ex)
                {
                    Message(ForeColorErrors, ex.Message);
                }

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

        public void Fib()
        {
            while (true)
            {
                Clear();

                SetForeground(ForeColorServices);

                var formAns = InputTextForm("Input a serial number of Fibonacci: ");

                int.TryParse(formAns[0], out int n);

                Message(ForeColorDefault, ($"The answer is {n.Fibonacci()}"));

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
