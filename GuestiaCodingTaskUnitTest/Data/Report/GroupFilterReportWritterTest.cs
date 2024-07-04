using GuestiaCodingTask.Data.Report;
using GuestiaCodingTask.Data;
using GuestiaCodingTaskUnitTest.TestData;
using System.Text;
using GuestiaCodingTask.Data.GroupFilter;
using GuestiaCodingTask.Data.Report.Formatter;
using System.Diagnostics;


namespace GuestiaCodingTaskUnitTest.Data.Report
{
    public class GroupFilterReportWritterTest
    {
        #region MockReportStream
        internal class MockReportStream : ReportStreamBase
        {
            StringBuilder _stringBuilder;

            public MockReportStream(
                StringBuilder stringBuilder,
                IFormatter titleFormatter,
                IFormatter headerFormatter,
                IFormatter lineFormatter) : base(titleFormatter, headerFormatter, lineFormatter)
            {
                _stringBuilder = stringBuilder;
            }

            public override void internal_WriteTitle(string title)
            {
                _stringBuilder.AppendLine(title);
            }

            public override void internal_WriteHeader(string header)
            {
                _stringBuilder.AppendLine(header);
            }

            public override void internal_WriteLine(string line)
            {
                _stringBuilder.AppendLine(line);
            }
        }

        #endregion

        #region MockDebugOutputReportStream
        internal class MockDebugOutputReportStream : ReportStreamBase
        {
            public MockDebugOutputReportStream(
                IFormatter titleFormatter,
                IFormatter headerFormatter,
                IFormatter lineFormatter) : base(titleFormatter, headerFormatter, lineFormatter)
            { }

            public override void internal_WriteTitle(string title)
            {
                Debug.WriteLine(title);
            }

            public override void internal_WriteHeader(string header)
            {
                Debug.WriteLine(header);
            }

            public override void internal_WriteLine(string line)
            {
                Debug.WriteLine(line);
            }
        }

        #endregion

        [Theory]
        [MemberData(nameof(GroupFilterReportWriterTestData.Write_UseStandardFormatProvider_FormattedReport), MemberType = typeof(GroupFilterReportWriterTestData))]
        public void Write_UseStandardFormatProvider_FormattedReport(string reportName, List<Guest> guests, string expectedFormattedReport)
        {
            // Arrange
            IGroupFilter<Guest,Line> groupFilter = new GroupFilterNonRegisteredGuestsGroupedByGuestGroup();

            StringBuilder stringBuilder = new StringBuilder();

            IReportStream reportStream = new MockReportStream(stringBuilder,
                new Formatter(new StandardFormatProvider(), "{0:TITLE}"),
                new Formatter(new StandardFormatProvider(), "{0:HEADER}"),
                new Formatter(new StandardFormatProvider(), "{0:LINE}")
            );

            // Act
            GroupFilterReportWritter<Line> groupFilterReportWriter = new GroupFilterReportWritter<Line>(reportStream);
            groupFilterReportWriter.Write(reportName, groupFilter.Query(guests));

            // Assert
            Assert.Equal(expectedFormattedReport, stringBuilder.ToString());
        }

        [Theory(Skip ="Only used for visually checking report format in Debug > Windows > Output")]
        //[Theory]
        [MemberData(nameof(GroupFilterReportWritterTest.Write_GuestiaFormatProvider_FormattedReportInDebugWindow), MemberType = typeof(GroupFilterReportWriterTestData))]
        public void Write_GuestiaFormatProvider_FormattedReportInDebugWindow(string reportName, List<Guest>? guests = null)
        {
            IReportStream reportStream = new MockDebugOutputReportStream(
              new Formatter(new GuestiaFormatProvider(), "{0:TITLE}"),
              new Formatter(new GuestiaFormatProvider(), "  {0:HEADER}"),
              new Formatter(new GuestiaFormatProvider(), "      {0:LINE}"));

            GroupFilterReportWritter<Line> groupFilterReportWriter = new GroupFilterReportWritter<Line>(reportStream);

            IGroupFilter<Guest,Line> groupFilter = new GroupFilterNonRegisteredGuestsGroupedByGuestGroup();

            groupFilterReportWriter.Write(reportName, groupFilter.Query(guests));

            Console.ReadKey();
        }
    }
}
