using System;
using System.IO;

namespace Hash2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "a_example.txt";
            //var file = "b_read_on.txt";
            //var file = "c_incunabula.txt";
            //var file = "d_tough_choices.txt";
            //var file = "e_so_many_books.txt";

            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName;
            var input = InputOutputAll.ReadData($"{projectDirectory}/Hash2020/Data/{file}");
        }
    }
}
