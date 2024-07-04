using System.Collections.Generic;

namespace GuestiaCodingTask.Data.GroupFilter
{
    public interface IQueryGroup<T>
    {
        string Name { get; }

        List<T> Items { get; }
    }
}
