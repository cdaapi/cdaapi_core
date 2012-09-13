using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace nhs.itk.hl7v3.datatypes
{

    public enum HL7V3_NullType
    {
        NoInformation,
        Invalid,
        Other,
        Unencoded,
        Derived,
        Unknown,
        AskedNotKnown,
        TemporarilyUnavailable,
        NotAsked,
        Masked,
        NotApplicable
    }

    public static class HL7V3_NullTypeExtensions
    {
        public static string ToFriendlyString(this HL7V3_NullType me)
        {
            switch (me)
            {
                case HL7V3_NullType.NoInformation:
                    return "NI";
                case HL7V3_NullType.Invalid:
                    return "INV";
                case HL7V3_NullType.Other:
                    return "OTH";
                case HL7V3_NullType.Unencoded:
                    return "UNC";
                case HL7V3_NullType.Derived:
                    return "DER";
                case HL7V3_NullType.Unknown:
                    return "UNK";
                case HL7V3_NullType.AskedNotKnown:
                    return "ASKU";
                case HL7V3_NullType.TemporarilyUnavailable:
                    return "NAV";
                case HL7V3_NullType.NotAsked:
                    return "NASK";
                case HL7V3_NullType.Masked:
                    return "MSK";
                case HL7V3_NullType.NotApplicable:
                    return "NA";
                default:
                    return null;
            }
        }
    }

}

