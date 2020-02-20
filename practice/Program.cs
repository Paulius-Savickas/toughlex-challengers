using System;
using System.IO;
using System.Linq;
using hashcode.Models;

namespace hashcode
{
    class Program
    {
        static void Main(string[] args)
        {
            //var file = @"a_example.in";
            //var file = @"b_small.in";
            //var file = @"c_medium.in";
            //var file = @"d_quite_big.in";
            var file = "e_also_big.in";

            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName;
            var input = ReadData($"{projectDirectory}/Data/{file}");

            var output = PrepareOutputLogic.PrepareOutput(input);
            output.OrderingPizzas.Reverse();

            WriteData(output, $"{projectDirectory}/Result/{file}");
        }

        private static void WriteData(Output output, string path)
        {
            using var file = new StreamWriter(path, false);
            file.WriteLine(output.TypeCount);
            file.WriteLine(string.Join(' ', output.OrderingPizzas));
        }

        private static Input ReadData(string file)
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
    }
}
