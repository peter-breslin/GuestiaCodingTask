using System.Collections.Generic;

namespace GuestiaCodingTask.Data.GroupFilter
{
    public class QueryGroup<T> : IQueryGroup<T> where T : class
    {
        public string Name { get; set; }

        public List<T> Items { get; set; }
    }
}
