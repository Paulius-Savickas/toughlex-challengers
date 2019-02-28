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
                    picture.Id = i;
                    picture.Orientation = info[0];
                    picture.TagNumber = int.Parse(info[1]);
                    picture.Tags = new HashSet<string>(info.Skip(2).ToArray());
                    dataSet.Pictures.Add(picture);
                }

                return dataSet;
            }
        }

        public class Slide
        {
            public Picture Picture1;
            public Picture Picture2;

            public override string ToString()
            {
                return $"{Picture1.Id}";
            }
        }

        public class ResultSet
        {
            public ResultSet()
            {
                SlideShow = new List<Slide>();
            }
            public List<Slide> SlideShow;
        }

        public static void OutputData(string filename, ResultSet results)
        {
            using (var outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(results.SlideShow.Count);
                foreach (var slide in results.SlideShow)
                {
                    outputFile.WriteLine(slide);
                }
            }
        }

    }
}
