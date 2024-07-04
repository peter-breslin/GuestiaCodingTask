namespace GuestiaCodingTask.Data.Report
{
    public interface IReportStream
    {
        void WriteTitle(string title);
        void WriteHeader(string header);
        void WriteLine(string line);
    }
}
