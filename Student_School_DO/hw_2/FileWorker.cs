using System.Xml.Linq;

namespace hw_2
{
    public class FileWorker
    {
        public string Path =>
            Directory.GetParent(Environment.ProcessPath).Parent.Parent.Parent.FullName + "\\" + Name;

        public int LengthFile => File.ReadAllLines(Path).Length;

        public string Name { get; set; }

        public FileWorker(string name)
        {
            Name = name + ".txt";
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
            try
            {
                var endIndex = count + startIndex;

                if (endIndex > LengthFile)
                {
                    endIndex = LengthFile;
                }

                using (StreamReader? sr = File.OpenText(Path))
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
            catch (FileNotFoundException ex)
            {
                throw ex;
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
            try
            {
                string? html = null;

                using (HttpClient client = new HttpClient())
                {
                    var content = (await client.GetAsync(url)).Content;

                    html = await content.ReadAsStringAsync();

                    CreateFile();

                    StreamWriter? sw = File.CreateText(Path);

                    sw.WriteLine(html);

                    sw.Close();
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}
