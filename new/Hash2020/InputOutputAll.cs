using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hash2020
{
    public static class InputOutputAll
    {
        public static void WriteData(Output output, string path)
        {
            using (var file = new StreamWriter(path, false))
            {
                file.WriteLine(output.TypeCount);
                file.WriteLine(string.Join(" ", output.OrderingPizzas));
            }
        }

        public static Input ReadData(string file)
        {
            var lines = File.ReadAllLines(file).Where(a => !string.IsNullOrWhiteSpace(a)).ToList();
            var firstLine = lines[0].Split(' ').Select(int.Parse).ToList();
            var secondLine = lines[1].Split(' ').Select(int.Parse).ToList();

            var input = new Input
            {
                BookCount = firstLine[0],
                LibraryCount = firstLine[1],
                DayCount = firstLine[2],

                //SlicesPerType = secondLine
            };
            return input;
        }

        public class Input
        {
           public int BookCount { get; set; }
           public int LibraryCount { get; set; }
           public int DayCount { get; set; }
           public List<int> Scores { get; set; }
        }

        public class Output
        {
            public int TypeCount => OrderingPizzas.Count;
            public List<int> OrderingPizzas { get; set; } = new List<int>();
            public int Sum { get; set; }
        }
    }
}

