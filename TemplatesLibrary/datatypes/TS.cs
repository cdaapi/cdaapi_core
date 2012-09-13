using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

namespace nhs.itk.hl7v3.datatypes
{
    /// <summary>
    /// Enumeration for precision.
    /// </summary>
    public enum TS_Precision
    {
        Year,
        Month,
        Day,
        Hour,
        Minute,
        Second,
        Full
    }

    internal static class TS_Helper
    {
        internal static DatePrecision ConvertPrecision(TS_Precision precision)
        {
            switch (precision)
            {
                case TS_Precision.Year:
                    return DatePrecision.Year;
                case TS_Precision.Month:
                    return DatePrecision.Month;
                case TS_Precision.Day:
                    return DatePrecision.Day;
                case TS_Precision.Hour:
                    return DatePrecision.Hour;
                case TS_Precision.Minute:
                    return DatePrecision.Minute;
                case TS_Precision.Second:
                    return DatePrecision.Second;
                case TS_Precision.Full:
                    return DatePrecision.Full;
                default:
                    return DatePrecision.Second;
            }
        }
    }
}