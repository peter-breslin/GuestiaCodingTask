using System;
using System.Collections.Generic;
using System.Linq;
using GuestiaCodingTask.Data.GroupFilter;
using GuestiaCodingTask.Data.Report;
using GuestiaCodingTask.Data.Report.Formatter;
using Microsoft.EntityFrameworkCore;

namespace GuestiaCodingTask.Data
{
    internal static class ReportInitialiser
    {
        internal static void WriteReport()
        {
            string reportName = "Non Registered Guests, Grouped By GuestGroup";

            try
            {
                using (var context = new GuestiaContext())
                {
                    List<Guest> guests = context.Guests.Include(g => g.GuestGroup).ToList();

                    CreateGroupFilterReportWritter().Write(reportName, new GroupFilterNonRegisteredGuestsGroupedByGuestGroup().Query(guests));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        internal static GroupFilterReportWritter<Line> CreateGroupFilterReportWritter()
        {
            return new GroupFilterReportWritter<Line>(new ConsoleOutputStream(
                                                new Formatter(new GuestiaFormatProvider(), "{0:TITLE}"),
                                                new Formatter(new GuestiaFormatProvider(), "  {0:HEADER}"),
                                                new Formatter(new GuestiaFormatProvider(), "      {0:LINE}")));
        }
    }
}
