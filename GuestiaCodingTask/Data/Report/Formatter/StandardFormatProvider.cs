using System;

namespace GuestiaCodingTask.Data.Report.Formatter
{
    public class StandardFormatProvider : IFormatProvider, ICustomFormatter
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
                        return $"{arg.ToString()}";

                    case "HEADER":
                        return $"{arg.ToString()}";

                    case "LINE":
                        return $"{arg.ToString()}";
                  
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
