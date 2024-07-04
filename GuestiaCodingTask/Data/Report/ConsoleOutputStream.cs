using System;
using GuestiaCodingTask.Data.Report.Formatter;

namespace GuestiaCodingTask.Data.Report
{
    public class ConsoleOutputStream : ReportStreamBase
    {
        public ConsoleOutputStream(
            IFormatter titleFormatter,
            IFormatter headerFormatter,
            IFormatter lineFormatter) : base(titleFormatter, headerFormatter, lineFormatter)
        {}

        public override void internal_WriteTitle(string title)
        {
            Console.WriteLine(title);
        }

        public override void internal_WriteHeader(string header)
        {
            Console.WriteLine(header);
        }

        public override void internal_WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
