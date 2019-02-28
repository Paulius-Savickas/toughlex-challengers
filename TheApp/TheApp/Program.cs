using System.Collections.Generic;

namespace TheApp
{
    class Program
    {
        public static List<string> DataFilesList = new List<string>
        {
            "a_example.in",
            "b_lovely_landscapes.in",
            "c_memorable_moments.in",
            "d_pet_pictures.in",
            "e_shiny_selfies.in"
        };

        static void Main(string[] args)
        {
            foreach (var fileName in DataFilesList)
            {

                var dataSet = InputOutput.ReadData($"data/{fileName}");
                var resultSet = new InputOutput.ResultSet();
                dataSet.Pictures.ForEach(p =>
                {
                    if (p.Orientation == "H")
                    {
                        resultSet.SlideShow.Add(new InputOutput.Slide { Picture1 = p });
                    }
                });

                InputOutput.OutputData($"{fileName}-result.out", resultSet);
            }
        }
    }
}
