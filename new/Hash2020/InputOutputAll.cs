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
                file.WriteLine(output.Libraries.Count);

                output.Libraries.ForEach(lib =>
                {
                    file.WriteLine($"{lib.Index} {lib.BooksToTake}");
                    file.WriteLine(string.Join(" ", lib.Books.Take(lib.BooksToTake).Select(a => a.Item1)));
                });
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

            lines = lines.Skip(2).ToList();

            for (int i = 0; i < input.LibraryCount; i++)
            {
                var libFirstLine = lines[i * 2].Split(' ').Select(int.Parse).ToList();
                var libSecondLine = lines[i * 2 + 1].Split(' ').Select(int.Parse).ToList();

                input.Libraries.Add(new Library
                {
                    Index = i,
                    BookCount = libFirstLine[0],
                    SignupProcessDays = libFirstLine[1],
                    ShipBooksPerDay = libFirstLine[2],
                    Books = libSecondLine.Select(a => new Tuple<int, int>(a, secondLine[a])).OrderByDescending(a => a.Item2).ToList()
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
            public int LibCount { get; set; }

            public List<Library> Libraries { get; set; } = new List<Library>();
        }

        public class Library
        {
            public int Index { get; set; }
            public int BookCount { get; set; }
            public int SignupProcessDays { get; set; }
            public int ShipBooksPerDay { get; set; }
            public int BooksToTake { get;set; }
            public List<Tuple<int,int>> Books { get; set; } = new List<Tuple<int, int>>();

            public double Score { get; set; }

            public double GetScore(int days)
            {
                int daysToProcess = days - SignupProcessDays;

                if (ShipBooksPerDay == 0)
                {
                    Score = 0;
                    return Score;
                }

                int libShipDays = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Books.Count) / Convert.ToDouble(ShipBooksPerDay)));
                
                if (libShipDays <= daysToProcess)
                {
                    Score =  Books.Select(a => a.Item2).Sum();
                    BooksToTake = Books.Count;
                }
                else
                {
                    BooksToTake = ShipBooksPerDay * daysToProcess;
                    Score =  Books.Take(BooksToTake).Select(a => a.Item2).Sum();
                }

                Score = Score / days * daysToProcess;

                return Score;
            }
        }
    }
}

