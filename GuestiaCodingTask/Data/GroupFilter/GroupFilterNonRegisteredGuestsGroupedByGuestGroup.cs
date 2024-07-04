using GuestiaCodingTask.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace GuestiaCodingTask.Data.GroupFilter
{
    public class GroupFilterNonRegisteredGuestsGroupedByGuestGroup : IGroupFilter<Guest,Line>
    {
        public IEnumerable<IQueryGroup<Line>> Query(List<Guest> guests)
        {
            if(guests == null)
                return Enumerable.Empty<IQueryGroup<Line>>();
            
            return guests
                .Where(o => o.RegistrationDate == null)
                .GroupBy(o => o.GuestGroup.Name)
                .OrderBy(o => o.Key)
                .Select(o => new QueryGroup<Line>()
                 {
                     Name = o.Key,
                     Items = o.Select(guest => new Line() { Value = guest.NameDisplayFormat() }).OrderBy(o => o.Value).ToList()
                 });
        }
    }
}
