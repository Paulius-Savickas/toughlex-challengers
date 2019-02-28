using System.IO;

namespace TheApp
{
    class Program
    {
        public class DataSet
        {
            public int R;
            public int C;
            //minimum number of each ingredient in slice
            public int L;
            //maximum number of slice cells
            public int H;
            public int Hadjusted;

            public string[] Data;
        }

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
        static void Main(string[] args)
        {
            var dataSet = ReadData("a_example.in"); 
        }
    }
}
