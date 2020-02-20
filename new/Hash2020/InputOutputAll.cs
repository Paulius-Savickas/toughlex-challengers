using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hash2020
{
    public class InputOutputAll
    {
        private static void WriteData(Output output, string path)
        {
            using (var file = new StreamWriter(path, false))
            {
                file.WriteLine(output.TypeCount);
                file.WriteLine(string.Join(" ", output.OrderingPizzas));
            }
        }

        private  Input ReadData(string file)
        {
            var lines = File.ReadAllLines(file);
            var firstLine = lines[0].Split(' ').Select(int.Parse).ToList();
            var secondLine = lines[1].Split(' ').Select(int.Parse).ToList();

            var input = new Input
            {
                Max = firstLine[0],
                TypeCount = firstLine[1],
                SlicesPerType = secondLine
            };
            return input;
        }

        public class Input
        {
            public int Max { get; set; }
            public int TypeCount { get; set; }

            public List<int> SlicesPerType { get; set; }
        }

        public class Output
        {
            public int TypeCount => OrderingPizzas.Count;
            public List<int> OrderingPizzas { get; set; } = new List<int>();
            public int Sum { get; set; }
        }
    }
}

