using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuestiaCodingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DbInitialiser.CreateDb();
            ReportInitialiser.WriteReport();

            Console.ReadKey();
        }
    }
}
