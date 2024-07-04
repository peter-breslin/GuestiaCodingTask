using System;

namespace GuestiaCodingTask.Data.Report.Formatter
{
    public  class Formatter : IFormatter
    {
        string args;
        IFormatProvider _formatProvider;
     
        public Formatter(IFormatProvider formatProvider, string args)
        {
            _formatProvider = formatProvider;
            this.args = args;
        }

        public string Format(string text)
        {
            return String.Format(_formatProvider, args, text);
        }
    }
}
