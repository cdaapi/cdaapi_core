using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

using nhs.itk.hl7v3.xml;

namespace nhs.itk.hl7v3.datatypes
{
    public enum TEL_TelecomUse
    {
        None = -1,
        Home = 0,
        PrimaryHome = 1,
        VacationHome = 2,
        WorkPlace = 3,
        AnsweringService = 8,
        EmergencyContact = 9,
        MobileContact = 10,
        Pager = 11,
    }

    public enum TEL_TelecomType
    {
        Telephone,
        Fax,
        Email
    }

    public  class TEL_Helper
    {
        private TEL tel;
        private TEL_TelecomUse use = TEL_TelecomUse.None;
        private TEL_TelecomType type;
        private string uri;

        public string URI
        {
            set { uri = value; }
            get { return uri; }
        }

        public TEL_TelecomType Type
        {
            set { type = value; }
            get { return type; }
        }

        public TEL_TelecomUse Use
        {
            set { use = value; }
            get { return use; }
        }

        public TEL TEL
        {
            get
            {
                tel = new TEL();

                if (use != TEL_TelecomUse.None)
                {
                    tel.Use = new SET<CS<TelecommunicationAddressUse>>(ConvertUse(use));
                }
                else
                {
                    tel.Use = null;
                }

                switch (type)
                {
                    case TEL_TelecomType.Telephone:
                        tel.Value  = "tel:" + uri;
                        break;
                    case TEL_TelecomType.Fax:
                        tel.Value = "fax:" + uri;
                        break;
                    case TEL_TelecomType.Email:
                        tel.Value = @"mailto:" + uri;
                        break;
                    default:
                        break;
                }

                return tel;
            }

        }

        internal static CS<TelecommunicationAddressUse> ConvertUse(TEL_TelecomUse value)
        {
            CS<TelecommunicationAddressUse> converted = new CS<TelecommunicationAddressUse>();
            switch (value)
            {
                case TEL_TelecomUse.Home:
                    converted.Code = TelecommunicationAddressUse.Home;
                    break;
                case TEL_TelecomUse.PrimaryHome:
                    converted.Code = TelecommunicationAddressUse.PrimaryHome;
                    break;
                case TEL_TelecomUse.VacationHome:
                    converted.Code = TelecommunicationAddressUse.VacationHome;
                    break;
                case TEL_TelecomUse.WorkPlace:
                    converted.Code = TelecommunicationAddressUse.WorkPlace;
                    break;
                case TEL_TelecomUse.AnsweringService:
                    converted.Code = TelecommunicationAddressUse.AnsweringService;
                    break;
                case TEL_TelecomUse.EmergencyContact:
                    converted.Code = TelecommunicationAddressUse.EmergencyContact;
                    break;
                case TEL_TelecomUse.MobileContact:
                    converted.Code = TelecommunicationAddressUse.MobileContact;
                    break;
                case TEL_TelecomUse.Pager:
                    converted.Code = TelecommunicationAddressUse.Pager;
                    break;
                default:
                    converted.Code = TelecommunicationAddressUse.Home; // It should never get this far
                    break;
            }
            return converted;
        }
        internal static string ConvertUseCode(TelecommunicationAddressUse value)
        {
            string code = "";

            switch (value)
            {
                case TelecommunicationAddressUse.AnsweringService:
                    code = "AS";
                    break;
                case TelecommunicationAddressUse.BadAddress:
                    break;
                case TelecommunicationAddressUse.Direct:
                    break;
                case TelecommunicationAddressUse.EmergencyContact:
                    code = "EC";
                    break;
                case TelecommunicationAddressUse.Home:
                    code = "H";
                    break;
                case TelecommunicationAddressUse.MobileContact:
                    code = "MC";
                    break;
                case TelecommunicationAddressUse.Pager:
                    code = "PG";
                    break;
                case TelecommunicationAddressUse.PrimaryHome:
                    code = "HP";
                    break;
                case TelecommunicationAddressUse.Public:
                    break;
                case TelecommunicationAddressUse.TemporaryAddress:
                    code = "TMP";
                    break;
                case TelecommunicationAddressUse.VacationHome:
                    code = "HV";
                    break;
                case TelecommunicationAddressUse.WorkPlace:
                    code = "WP";
                    break;
                default:
                    break;
            }
            return code;
        }
    }
}