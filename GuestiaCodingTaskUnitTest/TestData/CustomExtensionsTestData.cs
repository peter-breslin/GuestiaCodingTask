using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestiaCodingTaskUnitTest.TestData
{
    public class CustomExtensionsTestData
    {

        public static IEnumerable<object[]> LastNameCommaFirstNameInitial => new List<object[]>
        {
               new object[]
               {
                    new Guest
                    {
                        FirstName = "Maria",
                        LastName = "Anders",
                        GuestGroup = new GuestGroup { Name = "Standard", NameDisplayFormat = NameDisplayFormatType.LastNameCommaFirstNameInitial},
                        RegistrationDate = DateTime.UtcNow
                     },
                    "Anders,M"
                }
         };

        public static IEnumerable<object[]> UpperCaseLastNameSpaceFirstName => new List<object[]>
        {
               new object[]
               {
                    new Guest
                    {
                        FirstName = "Maria",
                        LastName = "Anders",
                        GuestGroup = new GuestGroup { Name = "VIP", NameDisplayFormat = NameDisplayFormatType.UpperCaseLastNameSpaceFirstName},
                        RegistrationDate = DateTime.UtcNow
                     },
                    "ANDERS Maria"
                }
         };
    }
}

