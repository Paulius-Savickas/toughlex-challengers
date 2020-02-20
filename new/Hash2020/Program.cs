using System;
using System.IO;

namespace Hash2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"a_example.in";
            //var file = @"b_small.in";
            //var file = @"c_medium.in";
            //var file = @"d_quite_big.in";
            //var file = "e_also_big.in";

            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName;
            var input = InputOutputAll.ReadData($"{projectDirectory}/Data/{file}");
        }
    }
}
