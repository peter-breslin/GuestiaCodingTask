using GuestiaCodingTask.Data;
using System;
using System.Linq;

namespace GuestiaCodingTask.Helpers
{
    public static class CustomExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string NameDisplayFormat(this Guest guest)
        {
           if(guest == null)
                throw new ArgumentNullException(nameof(guest));

            switch (guest.GuestGroup.NameDisplayFormat)
            {
                case NameDisplayFormatType.LastNameCommaFirstNameInitial:
                    return LastNameCommaFirstNameInitial(guest);

                case NameDisplayFormatType.UpperCaseLastNameSpaceFirstName:
                    return UpperCaseLastNameSpaceFirstName(guest);
      
                default:
                    throw new Exception($"CustomExtensions.NameDisplayFormat - Type '{guest.GuestGroup.NameDisplayFormat}' Not Implemented");
            }
        }

        static string LastNameCommaFirstNameInitial(Guest guest)
        {
            return $"{guest.LastName},{guest.FirstName.ToUpper().FirstOrDefault()}";
        }

        static string UpperCaseLastNameSpaceFirstName(Guest guest)
        {
            return $"{guest.LastName.ToUpper()} {guest.FirstName}";
        }
    }
}
