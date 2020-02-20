using System;
using System.IO;
using System.Runtime.InteropServices;

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

            var result = new object();
            while (input.DayCount > 0)//kol yra dienu like
            {
                //reikia pereiti per visus libraries ir pasigrazinti su geriausiu score, paduodam likusias dienas
                //library pridedam prie rezultatu, kuriuos piesim
                //istrinam librario knygas ir kitu libraries
                //istrinam library is listo
                //is dienu atitmam signup kieki dienu

                //uztikrinam kad neusiloopinam iki galo
            }

            //print result

        }
    }
}
