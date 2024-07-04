using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;
using GuestiaCodingTaskUnitTest.TestData;

namespace GuestiaCodingTaskUnitTest.Helpers
{
    public class CustomExtensionsTest
    {
        [Theory]
        [MemberData(nameof(CustomExtensionsTestData.LastNameCommaFirstNameInitial), MemberType = typeof(CustomExtensionsTestData))]
        public void NameDisplayFormat_LastNameCommaFirstNameInitial(Guest guest, string expectedDisplayName)
        {
            // Arrange
            string actualDisplayName = guest.NameDisplayFormat();

            // Assert
            Assert.Equal(expectedDisplayName, actualDisplayName);
        }

        [Theory]
        [MemberData(nameof(CustomExtensionsTestData.UpperCaseLastNameSpaceFirstName), MemberType = typeof(CustomExtensionsTestData))]
        public void NameDisplayFormat_UpperCaseLastNameSpaceFirstName(Guest guest, string expectedDisplayName)
        {
            // Arrange
            string actualDisplayName = guest.NameDisplayFormat();

            // Assert
            Assert.Equal(expectedDisplayName, actualDisplayName);
        }
    }
}
