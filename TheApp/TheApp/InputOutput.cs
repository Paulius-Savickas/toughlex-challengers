using System.Collections.Generic;
using System.IO;

namespace TheApp
{
    public class InputOutput
    {
        public static DataSet ReadData(string filename)
        {
            var dataSet = new DataSet();

            using (var sr = new StreamReader(filename))
            {
                var line = sr.ReadLine();
                var bits = line.Split(' ');
                dataSet.R = int.Parse(bits[0]);
                dataSet.C = int.Parse(bits[1]);
                dataSet.L = int.Parse(bits[2]);
                dataSet.H = int.Parse(bits[3]);

                dataSet.Data = new string[dataSet.R];

                for (var i = 0; i < dataSet.R; i++)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    dataSet.Data[i] = sr.ReadLine().Trim();
                }

                return dataSet;
            }
        }

        public class CoordinatesSet
        {
            public int r1, c1, r2, c2;

            public CoordinatesSet(int r1, int c1, int r2, int c2)
            {
                this.r1 = r1;
                this.c1 = c1;
                this.r2 = r2;
                this.c2 = c2;
            }
        }

        public class ResultSet
        {
            public List<CoordinatesSet> Results;
        }

        public static void OutputData(string filename, ResultSet results)
        {
            using (var outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(results.Results.Count);
                foreach (var coordinatesSet in results.Results)
                {
                    outputFile.WriteLine($"{coordinatesSet.r1} {coordinatesSet.c1} {coordinatesSet.r2} {coordinatesSet.c2}");
                }
            }
        }

    }
}
