using System;
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
                Scores = secondLine
            };

            for (int i = 2; i < lines.Count; i = i + 2)
            {
                var libFirstLine = lines[i].Split(' ').Select(int.Parse).ToList();
                var libSecondLine = lines[i + 1].Split(' ').Select(int.Parse).ToList();

                input.Libraries.Add(new Library
                {
                    Index = i - 2,
                    BookCount = libFirstLine[0],
                    SignupProcessDays = libFirstLine[1],
                    ShipBooksPerDay = libSecondLine[2],
                    Books = libSecondLine.Select(a => new Tuple<int, int>(a, secondLine[a])).ToList()
                });
            }

            return input;
        }

        public class Input
        {
           public int BookCount { get; set; }
           public int LibraryCount { get; set; }
           public int DayCount { get; set; }
           public List<int> Scores { get; set; } = new List<int>();

           public List<Library> Libraries { get; set; } = new List<Library>();
        }

        public class Output
        {
            public int TypeCount => OrderingPizzas.Count;
            public List<int> OrderingPizzas { get; set; } = new List<int>();
            public int Sum { get; set; }
        }

        public class Library
        {
            public int Index { get; set; }
            public int BookCount { get; set; }
            public int SignupProcessDays { get; set; }
            public int ShipBooksPerDay { get; set; }
            public List<Tuple<int,int>> Books { get; set; } = new List<Tuple<int, int>>();

            public int GetScore(int days, Input input)
            {
                Books = Books.OrderBy(a => a.Item2).ToList();
                int daysToProcess = days - SignupProcessDays;
                if (Books.Count / ShipBooksPerDay < daysToProcess)
                {

                }
                return 0;
            }
        }
    }
}

