using GuestiaCodingTask.Data.Report.Formatter;

namespace GuestiaCodingTask.Data.Report
{
    public abstract class ReportStreamBase : IReportStream
    {
        IFormatter _titleFormatter;
        IFormatter _headerFormatter;
        IFormatter _lineFormatter;

        public ReportStreamBase(
            IFormatter titleFormatter,
            IFormatter headerFormatter,
            IFormatter lineformatter)
        {
            _titleFormatter = titleFormatter;
            _headerFormatter = headerFormatter;
            _lineFormatter = lineformatter;
        }

        public abstract void internal_WriteTitle(string title);
        public abstract void internal_WriteHeader(string header);
        public abstract void internal_WriteLine(string line);

        public void WriteTitle(string title)
        {
            internal_WriteTitle(_titleFormatter.Format(title));
        }

        public void WriteHeader(string header)
        {
            internal_WriteHeader(_headerFormatter.Format(header));
        }
       
        public void WriteLine(string line)
        {
            internal_WriteLine(_lineFormatter.Format(line));
        }
    }
}
