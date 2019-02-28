using System.Linq;

namespace TheApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSet = InputOutput.ReadData("c_memorable_moments.in");
            var resultSet = new InputOutput.ResultSet();
            dataSet.Pictures.ForEach(p =>
            {
                if (p.Orientation == "H")
                {
                    resultSet.SlideShow.Add(new InputOutput.Slide{Picture1 = p});
                }
            });

            InputOutput.OutputData("result.out", resultSet);
        }

    }
}
