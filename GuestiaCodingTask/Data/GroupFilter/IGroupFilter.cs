using System.Collections.Generic;

namespace GuestiaCodingTask.Data.GroupFilter
{
    public interface IGroupFilter<LT, QG> where LT : class
    {
        IEnumerable<IQueryGroup<QG>> Query(List<LT> guests);
    }
}
