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
                    var picture = new Slide();
                    picture.Id = i;
                    picture.Orientation = info[0];
                    picture.TagNumber = int.Parse(info[1]);
                    picture.Tags = new HashSet<string>(info.Skip(2).ToArray());
                    dataSet.Slides.Add(picture);
                }

                return dataSet;
            }
        }

        public class CoordinatesSet
        {
            public int FirstPhotoId;
            public int? SecondPhotoId;
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
