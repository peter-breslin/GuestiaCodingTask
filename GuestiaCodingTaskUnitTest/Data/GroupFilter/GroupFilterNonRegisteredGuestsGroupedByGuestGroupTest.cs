using GuestiaCodingTask.Data;
using GuestiaCodingTask.Data.GroupFilter;
using GuestiaCodingTaskUnitTest.TestData;

namespace GuestiaCodingTaskUnitTest.Data.GroupFilter
{
    public class GroupFilterNonRegisteredGuestsGroupedByGuestGroupTest
    {
        [Theory]
        [MemberData(nameof(GroupFilterNonRegisteredGuestsGroupedByGuestGroupTestData.Query_NonRegisteredGuestsGroupedByGuestGroup_IQueryGroup), MemberType = typeof(GroupFilterNonRegisteredGuestsGroupedByGuestGroupTestData))]
        public void Query_NonRegisteredGuestsGroupedByGuestGroup_IQueryGroup(List<Guest> guests, int expectedGuestCount, int expectedGroupCount)
        {
            // Arange
            IGroupFilter<Guest,Line> groupFilter = new GroupFilterNonRegisteredGuestsGroupedByGuestGroup();

            // Act
            IEnumerable<IQueryGroup<Line>> actualResults = groupFilter.Query(guests);

            //Assert
            Assert.True(actualResults.Count() == expectedGroupCount);
            Assert.True(actualResults.SelectMany(o => o.Items).Count() == expectedGuestCount);
        }

        [Theory]
        [MemberData(nameof(GroupFilterNonRegisteredGuestsGroupedByGuestGroupTestData.Query_NonRegisteredGuestsGroupedByGuestGroup_EmptyIQueryGroup), MemberType = typeof(GroupFilterNonRegisteredGuestsGroupedByGuestGroupTestData))]
        public void Query_NonRegisteredGuestsGroupedByGuestGroup_EmptyIQueryGroup(List<Guest> guests, int expectedGuestCount, int expectedGroupCount)
        {
            // Arange
            IGroupFilter<Guest,Line> groupFilter = new GroupFilterNonRegisteredGuestsGroupedByGuestGroup();

            // Act
            IEnumerable<IQueryGroup<Line>> actualResults = groupFilter.Query(guests);

            //Assert
            Assert.True(actualResults.Count() == expectedGroupCount);
            Assert.True(actualResults.SelectMany(o => o.Items).Count() == expectedGuestCount);
        }
    }
}