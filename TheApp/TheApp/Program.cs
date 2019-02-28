using System.Collections.Generic;
using System.Linq;

namespace TheApp
{
    class Program
    {
        public static List<string> DataFilesList = new List<string>
        {
//            "a_example.in",
            "b_lovely_landscapes.in",
//            "c_memorable_moments.in",
//            "d_pet_pictures.in",
//            "e_shiny_selfies.in"
        };

        static void Main(string[] args)
        {
            foreach (var fileName in DataFilesList)
            {

                var dataSet = InputOutput.ReadData($"data/{fileName}");
                var resultSet = new InputOutput.ResultSet();

                dataSet.Pictures = dataSet.Pictures.Where(p => p.Orientation == "H").ToList();
                var firstPicture = dataSet.Pictures.FirstOrDefault();
                resultSet.SlideShow.Add(new InputOutput.Slide(firstPicture));
                dataSet.Pictures.Remove(firstPicture);

                while (dataSet.Pictures.Count > 0)
                {
                    Picture bestMatch = null;
                    int bestPoints = -1;
                    var lastPicture = resultSet.SlideShow.Last();
                    foreach (var dataSetPicture in dataSet.Pictures)
                    {
                        var slide = new InputOutput.Slide(dataSetPicture);
                        var score = lastPicture.GetScore(slide);
                        if (score > bestPoints)
                        {
                            bestPoints = score;
                            bestMatch = dataSetPicture;
                        }
                    }

                    resultSet.SlideShow.Add(new InputOutput.Slide(bestMatch));
                    dataSet.Pictures.Remove(bestMatch);
                }

                InputOutput.OutputData($"{fileName}-result.out", resultSet);
            }
        }
    }
}
