using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TheApp
{
    class Program
    {
        public static List<string> DataFilesList = new List<string>
        {
//            "a_example.in",
//            "b_lovely_landscapes.in",
//            "c_memorable_moments.in",
            "d_pet_pictures.in",
//            "e_shiny_selfies.in"
        };

        static void Main(string[] args)
        {
            foreach (var fileName in DataFilesList)
            {

                var dataSet = InputOutput.ReadData($"data/{fileName}");
                var resultSet = new InputOutput.ResultSet();

                var horizontalSlidesList = dataSet.Pictures.Where(p => p.Orientation == "H").ToList().Select(x => new InputOutput.Slide(x)).ToList();
                var verticalSlidesList = VerticalSlides.GetVSlidesList(dataSet.Pictures.ToArray().ToList());

                horizontalSlidesList.AddRange(verticalSlidesList);
                var allSlides = horizontalSlidesList;

                var firstSlide = allSlides.FirstOrDefault();
                allSlides.Remove(firstSlide);
                resultSet.SlideShow.Add(firstSlide);

                while (allSlides.Count > 0)
                {
                    InputOutput.Slide bestMatch = null;
                    int bestPoints = -1;
                    var lastPicture = resultSet.SlideShow.Last();
                    foreach (var slide in allSlides)
                    {
                        var score = lastPicture.GetScore(slide);
                        if (score > bestPoints)
                        {
                            bestPoints = score;
                            bestMatch = slide;
                        }

                        if (bestPoints > 5)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Pictures Left: " + dataSet.Pictures.Count.ToString() + " Best score: " + bestPoints);

                    resultSet.SlideShow.Add(bestMatch);
                    allSlides.Remove(bestMatch);
                }

                InputOutput.OutputData($"{fileName}-result.out", resultSet);
            }
        }
    }
}
