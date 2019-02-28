using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;

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
            public Picture Pic1;
            public Picture Pic2;
            public HashSet<string> Tags;
            public bool Used;

            public Slide(Picture pic1)
            {
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
                var left = this.Tags.Count - intersection.Count();
                var right = other.Tags.Count - intersection.Count();
                return Math.Min(Math.Min(intersection.Count(), left), right);

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
