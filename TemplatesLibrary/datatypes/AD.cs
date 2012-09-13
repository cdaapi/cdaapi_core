using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using nhs.itk.hl7v3.xml;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

namespace nhs.itk.hl7v3.datatypes
{

    public enum AD_AddressUse
    {
        HomeAddress,
        PrimaryHome,
        VacationHome,
        WorkPlace,
        Public,
        BadAddress,
        PhysicalVisit,
        PostalAddress,
        TemporaryAddress,
        Alphabetic,
        Ideographic,
        Syllabic
    }

    public class AD_Helper
    {
        private AD address;
        private string postcode;
        private string city;
        private string streetLine1;
        private string streetLine2;
        private string streetLine3;
        private IVLTS_Helper useablePeriod;
        private bool useablePeriodSet;

        private bool useIsSet = false;
        private AD_AddressUse use;

        public AD_Helper()
        {
            useIsSet = false;
            useablePeriodSet = false;


        }
        private void initHelper()
        {
            if (useablePeriod == null)
            {
                useablePeriodSet = true;
                useablePeriod = new IVLTS_Helper();
                useablePeriod.LowPrecision = TS_Precision.Second;
                useablePeriod.HighPrecision = TS_Precision.Second;
            }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string StreetLine1
        {
            get { return streetLine1; }
            set { streetLine1 = value; }
        }
        public string StreetLine2
        {
            get { return streetLine2; }
            set { streetLine2 = value; }
        }
        public string StreetLine3
        {
            get { return streetLine3; }
            set { streetLine3 = value; }
        }

        public IVLTS_Helper UseablePeriod
        {
            set
            {
                useablePeriod = value;
                useablePeriodSet = true;
            }
        }

        public AD_AddressUse Use
        {
            get { return use; }
            set
            {
                use = value;
                useIsSet = true;
            }
        }

        public AD AD
        {
            get
            {
                AD tempAddress = new AD();

                if (useIsSet)
                {
                    tempAddress.Use = new SET<CS<PostalAddressUse>>();
                    tempAddress.Use.Add(ConvertUse(use));
                }

                if (streetLine1 != null) tempAddress.Part.Add(new ADXP(streetLine1, AddressPartType.StreetAddressLine));
                if (streetLine2 != null) tempAddress.Part.Add(new ADXP(streetLine2, AddressPartType.StreetAddressLine));
                if (streetLine3 != null) tempAddress.Part.Add(new ADXP(streetLine3, AddressPartType.StreetAddressLine));
                if (city != null) tempAddress.Part.Add(new ADXP(city, AddressPartType.City));
                if (postcode != null) tempAddress.Part.Add(new ADXP(postcode, AddressPartType.PostalCode));

                if (useablePeriodSet)
                {
                    tempAddress.UseablePeriod = new GTS(useablePeriod.IVLTS);
                }

                return tempAddress;
            }
        }
        internal static CS<PostalAddressUse> ConvertUse(AD_AddressUse value)
        {
            CS<PostalAddressUse> converted = new CS<PostalAddressUse>();

            switch (value)
            {
                case AD_AddressUse.HomeAddress:
                    converted.Code = PostalAddressUse.HomeAddress;
                    break;
                case AD_AddressUse.PrimaryHome:
                    converted.Code = PostalAddressUse.PrimaryHome;
                    break;
                case AD_AddressUse.VacationHome:
                    converted.Code = PostalAddressUse.VacationHome;
                    break;
                case AD_AddressUse.WorkPlace:
                    converted.Code = PostalAddressUse.WorkPlace;
                    break;
                case AD_AddressUse.Public:
                    converted.Code = PostalAddressUse.Public;
                    break;
                case AD_AddressUse.BadAddress:
                    converted.Code = PostalAddressUse.BadAddress;
                    break;
                case AD_AddressUse.PhysicalVisit:
                    converted.Code = PostalAddressUse.PhysicalVisit;
                    break;
                case AD_AddressUse.PostalAddress:
                    converted.Code = PostalAddressUse.PostalAddress;
                    break;
                case AD_AddressUse.TemporaryAddress:
                    converted.Code = PostalAddressUse.TemporaryAddress;
                    break;
                case AD_AddressUse.Alphabetic:
                    converted.Code = PostalAddressUse.Alphabetic;
                    break;
                case AD_AddressUse.Ideographic:
                    converted.Code = PostalAddressUse.Ideographic;
                    break;
                case AD_AddressUse.Syllabic:
                    converted.Code = PostalAddressUse.Syllabic;
                    break;
                default:
                    break;
            }
            return converted;
        }
        private static string ConvertUseCode(AD_AddressUse value)
        {
            string code = "";

            switch (value)
            {
                case AD_AddressUse.HomeAddress:
                    code = "H";
                    break;
                case AD_AddressUse.PrimaryHome:
                    code = "HP";
                    break;
                case AD_AddressUse.VacationHome:
                    code = "HV";
                    break;
                case AD_AddressUse.WorkPlace:
                    code = "DIR";
                    break;
                case AD_AddressUse.Public:
                    code = "PUB";
                    break;
                case AD_AddressUse.BadAddress:
                    code = "BAD";
                    break;
                case AD_AddressUse.PhysicalVisit:
                    code = "PHYS";
                    break;
                case AD_AddressUse.PostalAddress:
                    code = "PST";
                    break;
                case AD_AddressUse.TemporaryAddress:
                    code = "TMP";
                    break;
                case AD_AddressUse.Alphabetic:
                    code = "ABC";
                    break;
                case AD_AddressUse.Ideographic:
                    code = "IDE";
                    break;
                case AD_AddressUse.Syllabic:
                    code = "SYL";
                    break;
                default:
                    break;
            }
            return code;
        }
    }
}