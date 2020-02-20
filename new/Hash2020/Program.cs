using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Hash2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //var file = "a_example.txt";
            //var file = "b_read_on.txt";
            //var file = "c_incunabula.txt";
            var file = "d_tough_choices.txt";
            //var file = "e_so_many_books.txt";
            //var file = "f_libraries_of_the_world.txt";

            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.FullName;
            var input = InputOutputAll.ReadData($"{projectDirectory}/Hash2020/Data/{file}");

            var result = new InputOutputAll.Output();
            while (input.DayCount > 0)//kol yra dienu like
            {
                Console.WriteLine(input.DayCount);
                //reikia pereiti per visus libraries ir pasigrazinti su geriausiu score, paduodam likusias dienas

                var maxScore = input.Libraries.Max(b => b.GetScore(input.DayCount));
                if (maxScore == 0)
                    break;

                var resultLib = input.Libraries.First(z => z.Score == maxScore);
                result.Libraries.Add(resultLib);
                input.Libraries.Remove(resultLib);

                if(input.Libraries.Count == 0)
                    break;

                input.Libraries.ForEach(lib =>
                {
                    resultLib.Books.ForEach(book => lib.Books.RemoveAll(a => a.Item1 == book.Item1));

                    //lib.Books.Where();
                });

                input.DayCount -= resultLib.SignupProcessDays;


                //library pridedam prie rezultatu, kuriuos piesim
                //istrinam librario knygas ir kitu libraries
                //istrinam library is listo
                //is dienu atitmam signup kieki dienu

                //uztikrinam kad neusiloopinam iki galo
            }

            InputOutputAll.WriteData(result, $"{projectDirectory}/Hash2020/Result/{file}");

            //print result

        }
    }
}
