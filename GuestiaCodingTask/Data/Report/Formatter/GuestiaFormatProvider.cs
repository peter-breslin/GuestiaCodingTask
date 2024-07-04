using System;

namespace GuestiaCodingTask.Data.Report.Formatter
{
    public class GuestiaFormatProvider : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }
            else
            {
                switch (format)
                {
                    case "TITLE":
                        return $"Report > {arg.ToString()}"; 

                    case "HEADER":
                        return $"{arg.ToString(),-10}";

                    case "LINE":
                        return $"{arg.ToString(),-10}";

                    default:
                        throw new FormatException(
                                  String.Format("The '{0}' format specifier is not supported.", format));
                }
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
}
