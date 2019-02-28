namespace TheApp
{
    class Program
    {


        static void Main(string[] args)
        {
            var dataSet = InputOutput.ReadData("data/c_memorable_moments.in");

            var resultSet = new InputOutput.ResultSet();


            dataSet.Pictures.ForEach(p =>
            {
                if (p.Orientation == "H")
                {
                    resultSet.SlideShow.Add(new InputOutput.Slide(p));
                }
            });

            var resultSetV1 = new InputOutput();

            


            InputOutput.OutputData("result.out", resultSet);
        }

    }
}
