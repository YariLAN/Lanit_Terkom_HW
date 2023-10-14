namespace Practice_1410
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[10][];

            for (int y = 0; y < arr.Length; y++)
            {
                arr[y] = new int[10];
                for (int x = 0; x < arr[y].Length; x++)
                {
                    arr[y][x] = new Random().Next(0, 4);
                }
            }

            var s = RemakeArray(arr);

            foreach (var line in arr)
            {
                foreach (var c in line)
                    Console.Write(c + " ");
                Console.WriteLine();
            }

        }

        static int[][] RemakeArray(int[][] array)
        {
            foreach(int[] line in array)
            {
                for(int i = 0; i < line.Length; i++)
                {
                    if (line[i] != 0)
                    {
                        line[i] = 1;
                    }
                }
            }
            return array;
        }
    }
}