using System;
using System.IO;

namespace hw_2
{
    public class WorkWithFile
    {
        public string Path =>
            Directory.GetParent(Environment.ProcessPath).Parent.Parent.Parent.FullName + "\\" + Name;

        public int LengthFile => File.ReadAllLines(Path).Length;

        public string Name { get; set; } = "dafault.txt";

        public WorkWithFile() { }

        public WorkWithFile(string name)
        {
            if (name != "")
            {
                Name = name + ".txt";
            }
            CreateFile();
        }

        public void CreateFile()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
            }
        }

        public void ReadingFile(int count, int startIndex = 0)
        {
            var endIndex = count + startIndex;

            if (endIndex > LengthFile)
            {
                endIndex = LengthFile;
            }

            StreamReader? sr = null;
            try
            {
                using (sr = File.OpenText(Path))
                {
                    for (int skip = 0; skip < startIndex; skip++)
                    {
                        sr.ReadLine();
                    }

                    for (int k = startIndex; k < endIndex; k++)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new FileNotFoundException();
            }
            finally
            {
                sr?.Dispose();
            }
        }

        public void ReadWholeFile()
        {
            var allLines = File.ReadAllLines(Path);

            foreach (var line in allLines)
            {
                Console.WriteLine(line);
            }
        }

        public async Task RecordHtmlToFile(string url)
        {
            StreamWriter? sw = null;

            try
            {
                string? html = null;

                using (HttpClient client = new HttpClient())
                {
                    var content = (await client.GetAsync(url)).Content;

                    html = await content.ReadAsStringAsync();

                    sw = File.CreateText(Path);

                    sw.WriteLine(html);
                }
                Console.WriteLine("\nData is loaded!\n");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw?.Dispose();
            }
        }
    }
}
