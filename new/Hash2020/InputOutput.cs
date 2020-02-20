using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hash2020
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
                    picture.Used = false;
                    picture.Orientation = info[0];
                    picture.TagNumber = int.Parse(info[1]);
                    picture.Tags = new HashSet<string>(info.Skip(2).ToArray());
                    dataSet.Pictures.AddLast(picture);
                }

                return dataSet;
            }
        }

        public class Slide
        {
            public Picture Pic1;
            public Picture Pic2;
            public HashSet<string> Tags;
            public bool Used;

            public Slide(Picture pic1)
            {
                Pic1 = pic1;
               Tags = new HashSet<string>();
               Tags.UnionWith(pic1.Tags);
            }

            public override string ToString()
            {
                var result = string.Empty;
                if (Pic1.Orientation == "H")
                {

                    return Pic1.Id.ToString();
                }

                return $"{Pic1.Id} {Pic2.Id}";
            }

            public int GetScore(Slide other)
            {
                var intersection = this.Tags.Intersect(other.Tags);
                var count = intersection.Count();
                var left = this.Tags.Count - count;
                var right = other.Tags.Count - count;
                return Math.Min(Math.Min(count, left), right);

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

        public class Picture
        {
            public int Id;
            public string Orientation;
            public int TagNumber;
            public HashSet<string> Tags;
            public bool Used;
        }

        public class DataSet
        {
            public DataSet()
            {
                Pictures = new LinkedList<Picture>();
            }
            public int RowNumber;
            public LinkedList<Picture> Pictures;
        }

    }
}
