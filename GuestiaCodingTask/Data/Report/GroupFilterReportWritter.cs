using System.Collections.Generic;
using GuestiaCodingTask.Data.GroupFilter;

namespace GuestiaCodingTask.Data.Report
{
    public class GroupFilterReportWritter<T> where T : ILine, new()
    {
        IReportStream _reportStream;

        public GroupFilterReportWritter(IReportStream reportStreamm)
        {
            _reportStream = reportStreamm;
        }

        public void Write(string name, IEnumerable<IQueryGroup<T>> groupFilter)
        {
            if (_reportStream != null && groupFilter != null)
            {
                _reportStream.WriteTitle(name);

                foreach (var group in groupFilter)
                {
                    _reportStream.WriteHeader(group.Name);

                    foreach (ILine line in group.Items)
                    {
                        _reportStream.WriteLine(line.Value);
                    }
                }
            }
        }
    }
}
