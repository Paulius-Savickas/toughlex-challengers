using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                dataSet.RowNumber = int.Parse(line.Trim());


                for (var i = 0; i < dataSet.RowNumber; i++)
                {
                    // ReSharper disable once PossibleNullReferenceException

                    var info = sr.ReadLine().Trim().Split(' ');
                    var picture = new Picture();
                    picture.Orientation = info[0];
                    picture.TagNumber = int.Parse(info[1]);
                    picture.Tags = new HashSet<string>(info.Skip(2).ToArray());
                    dataSet.Pictures.Add(picture);
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
