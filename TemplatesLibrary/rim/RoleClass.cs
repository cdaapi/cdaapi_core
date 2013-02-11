
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;

using nhs.itk.hl7v3.cda;
using nhs.itk.hl7v3.datatypes;
using nhs.itk.hl7v3.xml;


namespace nhs.itk.hl7v3.rim
{
    public class RoleClass
    {
        private string classCode;
        private List<II> id;
        private List<AD> addr;
        private List<TEL> telecom;
        private CV<String> code;
        private CV<String> recipientRoleCode;

        internal RoleClass()
        { }
        internal RoleClass(string classCode)
        {
            this.classCode = classCode;
        }
        internal string ClassCode
        {
            get { return classCode; }
            set { ClassCode = value; }
        }

        #region @id
        internal void SetIdNull(string flavorCode)
        {
            NullFlavor flavorValue;


            switch (flavorCode)
            {
                case "NA":
                    flavorValue = NullFlavor.NotApplicable;
                    break;
                case "NI":
                    flavorValue = NullFlavor.NoInformation;
                    break;
                case "UNK":
                    flavorValue = NullFlavor.Unknown;
                    break;
                default:
                    flavorValue = NullFlavor.NoInformation;
                    break;
            }
            this.id = new List<II>();
            II temp = new II();
            temp.NullFlavor = flavorValue;
         

            this.id = new List<II>();
            this.id.Add(temp);
        }
        internal void AddIdNull(string flavorCode)
        {
            NullFlavor flavorValue;


            switch (flavorCode)
            {
                case "NA":
                    flavorValue = NullFlavor.NotApplicable;
                    break;
                case "NI":
                    flavorValue = NullFlavor.NoInformation;
                    break;
                case "UNK":
                    flavorValue = NullFlavor.Unknown;
                    break;
                default:
                    flavorValue = NullFlavor.NoInformation;
                    break;
            }
            //this.id = new List<II>();
            II temp = new II();
            temp.NullFlavor = flavorValue;

            this.id.Add(temp);
        }

        internal void SetId(II id)
        {
            this.id = new List<II>();
            this.id.Add(id);
        }
        internal void SetId(string root, string extension)
        {
            this.id = new List<II>();
            AddId(root, extension, null);
        }
        internal void SetId(string root, string extension, string assignedAuthorityName)
        {
            this.id = new List<II>();

            II temp = new II();
            temp.Extension = extension;
            temp.Root = root;
            temp.AssigningAuthorityName = assignedAuthorityName;
            
            this.id.Add(temp);
        }

        internal void AddId(II id)
        {
            if (this.id == null)
            {
                this.id = new List<II>();
            }

            this.id.Add(id);
        }
        internal void AddId(string root, string extension)
        {
            AddId(root, extension, null);
        }
        internal void AddId(string root, string extension, string assignedAuthorityName)
        {
            if (this.id == null)
            {
                this.id = new List<II>();
            }

            II temp = new II();
            temp.Extension = extension;
            temp.Root = root;
            temp.AssigningAuthorityName = assignedAuthorityName;
            this.id.Add(temp);
        }
        #endregion

        #region @address

        internal void SetStructuredAddress(AD address)
        {
            this.addr = new List<AD>();
            this.addr.Add(address);
        }
        internal void AddStructuredAddress(AD address)
        {
            if (this.addr == null)
            {
                this.addr = new List<AD>();
            }
            this.addr.Add(address);
        }
        #endregion

        #region @telecom
        internal void SetTelecom(TEL tel)
        {

            this.telecom = new List<TEL>();
            this.AddTelecom(tel);
        }
 
        internal void AddTelecom(TEL tel)
        {
            if (this.telecom == null)
            {
                this.telecom = new List<TEL>();
            }

            this.telecom.Add(tel);
        }
        #endregion

        #region @code
        internal void SetCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            code = new CV<string>(codeValue, codeSystemValue, null, null, displayNameValue, null);
            code.OriginalText = null;
        }
        internal void SetCodeNull(string flavorCode)
        {
            NullFlavor flavorValue;

            code = new CV<string>();
            switch (flavorCode)
            {
                case "NI":
                    flavorValue = NullFlavor.NoInformation;
                    break;
                default:
                    flavorValue = NullFlavor.NoInformation;
                    break;
            }
            code.NullFlavor = new CS<NullFlavor>(flavorValue);
        }
        #endregion

        #region @recipientRoleCode
        internal void SetRecipientRoleCode(string codeSystemValue, string codeValue, string displayNameValue)
        {
            recipientRoleCode = new CV<string>(codeValue, codeSystemValue, null, null, displayNameValue, null);
            recipientRoleCode.OriginalText = null;
        }

        internal void SetRecipientRoleCode(NullFlavor nullType)
        {
            recipientRoleCode = new CV<string>();
            recipientRoleCode.NullFlavor = nullType;
        }
        #endregion

        internal void writeXML(XmlWriter writer)
        {
            FormatterHelper.SerialiseDataType(recipientRoleCode, writer, "recipientRoleCode", "NPFIT:HL7:Localisation");

            // The FormatterHelper should really deal with the SET<II>, but doesn't.
            // So insted we loop around and deal with each II in turn.
            if (id != null)
            {
                foreach (II item in id)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "id");
                }
            }

            FormatterHelper.SerialiseDataType(code, writer, "code");

            if (addr != null)
            {
                foreach (AD item in addr)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "addr");
                }
            }

            if (telecom != null)
            {
                foreach (TEL item in telecom)
                {
                    FormatterHelper.SerialiseDataType(item, writer, "telecom");
                }
            }
        }
    }
}
